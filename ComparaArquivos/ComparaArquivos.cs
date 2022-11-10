using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;
using File = System.IO.File;

namespace ComparaArquivos
{
    public partial class ComparaArquivos : Form
    {
        public ComparaArquivos()
        {
            InitializeComponent();
            CriaTemplates();
        }

        Interprete inter = new Interprete();
        int contador = 0;
        public System.Threading.ManualResetEvent _busy = new System.Threading.ManualResetEvent(false);
        private void cmbTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtArq1.Enabled = false;
            txtArq2.Enabled = false;
            txtValidaArq.Enabled = false;
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\Templates";
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var template in dir.GetFiles())
            {
                var nomeArquivo = Path.GetFileNameWithoutExtension(template.Name);
                if (nomeArquivo.Equals(cmbTemplate.SelectedItem))
                {
                    var instrucao = File.ReadAllText(template.FullName);
                    JObject jsonResponse = JObject.Parse(instrucao);
                    Dictionary<string, string> camposTemplate = JsonConvert.DeserializeObject<Dictionary<string, string>>(instrucao);
                    inter.Instrucao = camposTemplate;
                    btnSelecionaArq1.Enabled = true;
                    btnSelecionaArq2.Enabled = true;
                    btnSelecionaArqValida.Enabled = true;

                    txtArq1.Text = string.Empty;
                    txtArq2.Text = string.Empty;
                    txtValidaArq.Text = string.Empty;
                    arquivo1 = string.Empty;
                    arquivo2 = string.Empty;
                    arquivoValida = string.Empty;
                    break;
                }
            }
        }

        string arquivo1 = string.Empty;
        string arquivo2 = string.Empty;
        private void btnSelecionaArquivo_Click(object sender, EventArgs e)
        {
            txtOutputStatus.Text = String.Empty;
            SelecionarArquivos(ref arquivo1);
        }
        private void SelecionarArquivos(ref string fileName)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Filter = "CSV Files|*.csv";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fileName = dlg.FileName;
                    FileInfo fi = new FileInfo(fileName);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }

        private void btnValidaEstrutura_Click(object sender, EventArgs e)
        {
            try
            {
                var fileName = string.Empty;

                OpenFileDialog dlg = new OpenFileDialog();
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fileName = dlg.FileName;
                    FileInfo fi = new FileInfo(fileName);
                    StreamReader sr = new StreamReader(fileName);

                    while (!sr.EndOfStream)
                    {
                        var linhaArq = sr.ReadLine();
                        inter.ValidaEstrutura(linhaArq);
                    }
                }

                if (string.IsNullOrEmpty(fileName))
                    throw new Exception("Selecione um arquivo.");
                else
                    MessageBox.Show("Validação concluída com sucesso.");
            }
            catch (Exception err)
            {
                this.Invoke(new Action(() =>
                {
                    txtOutputStatus.AppendText(err.Message + Environment.NewLine);
                }));
            }
        }

        private void cmbSeparador_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSeparador.SelectedItem.ToString() == "Ponto e Vírgula")
            {
                inter.Separador = ';';
                cmbTemplate.Enabled = true;
            }
            else if (cmbSeparador.SelectedItem.ToString() == "Vírgula")
            {
                inter.Separador = ',';
                cmbTemplate.Enabled = true;
            }
        }

        private void chckHeader_CheckedChanged(object sender, EventArgs e)
        {
            if (chckHeader.Checked)
                inter.Header = true;
            else
                inter.Header = false;
        }

        private void btnAtualizaTemplate_Click(object sender, EventArgs e)
        {
            txtArq1.Enabled = false;
            txtArq2.Enabled = false;
            txtValidaArq.Enabled = false;
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\Templates";
            DirectoryInfo dir = new DirectoryInfo(path);
            cmbTemplate.Items.Clear();
            foreach (var template in dir.GetFiles())
            {
                var nomeTemplate = Path.GetFileNameWithoutExtension(template.Name);
                cmbTemplate.Items.Add(nomeTemplate);
            }
            ResetFields();
        }

        private void ResetFields()
        {
            btnSelecionaArq1.Enabled = false;
            btnSelecionaArq2.Enabled = false;
            txtArq1.Text = string.Empty;
            txtArq2.Text = string.Empty;
            txtValidaArq.Text = string.Empty;
            txtArq1.Enabled = false;
            txtArq2.Enabled = false;
            btnIniciar.Enabled = false;
            btnSelecionaArqValida.Enabled = false;
            pauseresume = false;

            arquivo1 = string.Empty;
            arquivo2 = string.Empty;
            arquivoValida = string.Empty;
        }

        private void btnIncluirTemplate_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\Templates";
            Process.Start("explorer.exe", path);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                Stopwatch stopwatch = Stopwatch.StartNew();
                object thisLock = new object();

                string[] arquivos = (string[])e.Argument;

                if (arquivos.Length == 2)
                {
                    var arquivo1 = arquivos[0];
                    var arquivo2 = arquivos[1];


                    using (StreamReader sr1 = new StreamReader(arquivo1))
                    {
                        using (StreamReader sr2 = new StreamReader(arquivo2))
                        {
                            try
                            {
                                var linhaArq1 = string.Empty;
                                contador = 1;
                                while (!sr1.EndOfStream)
                                {
                                    lock (thisLock)
                                    {
                                        if (backgroundWorker1.CancellationPending)
                                        {
                                            e.Cancel = true;
                                            break;
                                        }
                                        else
                                        {
                                            if (pauseresume == true)
                                                PauseWorker();
                                            else
                                            {
                                                ResumeWorker();
                                                if (inter.Header)
                                                {
                                                    var header = sr1.ReadLine();
                                                    inter.Header = false;
                                                }
                                                else
                                                {
                                                    linhaArq1 = sr1.ReadLine();
                                                    if (!backgroundWorker2.IsBusy)
                                                    {
                                                        Thread.Sleep(2);
                                                        var segundoJob = new string[] { linhaArq1, arquivo2 };
                                                        backgroundWorker2.RunWorkerAsync(segundoJob);
                                                    }
                                                    else if (!backgroundWorker3.IsBusy)
                                                    {
                                                        Thread.Sleep(2);
                                                        var segundoJob = new string[] { linhaArq1, arquivo2 };
                                                        backgroundWorker3.RunWorkerAsync(segundoJob);
                                                    }
                                                    else
                                                    {
                                                        Thread.Sleep(2);
                                                        var segundoJob = new string[] { linhaArq1, arquivo2 };
                                                        VerificaAuxiliar(segundoJob);
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            catch (Exception err)
                            {
                                this.Invoke(new Action(() =>
                                {
                                    txtOutputStatus.AppendText(err.Message + Environment.NewLine);
                                }));
                            }
                        }
                        Thread.Sleep(1000);
                    }
                    stopwatch.Stop();

                    MessageBox.Show("Validação efetuada com sucesso. Tempo Total: " + stopwatch.Elapsed.ToString((@"hh\:mm\:ss")));
                }
                else if (arquivos.Length == 1)
                {
                    var arquivo1 = arquivos[0];
                    using (StreamReader sr1 = new StreamReader(arquivo1))
                    {
                        try
                        {
                            var linhaArq1 = string.Empty;
                            contador = 1;
                            while (!sr1.EndOfStream)
                            {
                                lock (thisLock)
                                {
                                    if (backgroundWorker1.CancellationPending)
                                    {
                                        e.Cancel = true;
                                        break;
                                    }
                                    else
                                    {
                                        if (pauseresume == true)
                                            PauseWorker();
                                        else
                                        {
                                            ResumeWorker();
                                            if (inter.Header)
                                            {
                                                var header = sr1.ReadLine();
                                                inter.Header = false;
                                            }
                                            else
                                            {
                                                linhaArq1 = sr1.ReadLine();
                                                if (!backgroundWorker2.IsBusy)
                                                {
                                                    Thread.Sleep(2);
                                                    var segundoJob = new string[] { linhaArq1 };
                                                    backgroundWorker2.RunWorkerAsync(segundoJob);
                                                }
                                                else if (!backgroundWorker3.IsBusy)
                                                {
                                                    Thread.Sleep(2);
                                                    var segundoJob = new string[] { linhaArq1 };
                                                    backgroundWorker3.RunWorkerAsync(segundoJob);
                                                }
                                                else
                                                {
                                                    Thread.Sleep(2);
                                                    var segundoJob = new string[] { linhaArq1 };
                                                    VerificaAuxiliar(segundoJob);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception err)
                        {
                            this.Invoke(new Action(() =>
                            {
                                txtOutputStatus.AppendText(err.Message + Environment.NewLine);
                            }));
                        }
                    }

                }
            }
            catch (Exception err)
            {
                this.Invoke(new Action(() =>
                {
                    txtOutputStatus.AppendText(err.Message + Environment.NewLine);
                }));
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.Invoke(new Action(() =>
                {
                    txtOutputStatus.AppendText("Operação cancelada." + Environment.NewLine);
                }));
            }
            else
            {
                this.cmbSeparador.Enabled = true;
                this.chckHeader.Enabled = true;
                this.btnAtualizaTemplate.Enabled = true;
                this.cmbTemplate.Enabled = true;

                this.btnPauseResume.Enabled = false;
                this.btnReset.Enabled = false;
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] arquivos = (string[])e.Argument;
            if (arquivos.Length == 2)
                VerificaAuxiliar(arquivos);
            else
            {
                inter.ValidaEstrutura(arquivos[0]);
                this.Invoke(new Action(() =>
                {
                    txtOutputStatus.AppendText("Linha validada com sucesso. " + contador + Environment.NewLine);
                    contador++;
                }));
            }

        }

        private void VerificaAuxiliar(string[] arquivos)
        {
            try
            {
                var linhaArq1 = arquivos[0];
                inter.ValidaEstrutura(linhaArq1);
                using (StreamReader sr2 = new StreamReader(arquivos[1]))
                {
                    var linhaEncontrada = false;
                    if (!linhaArq1.Contains(inter.Separador))
                        throw new Exception("Estrutura inválida.");

                    while (!sr2.EndOfStream)
                    {
                        var linhaArq2 = sr2.ReadLine();

                        if (!linhaArq2.Contains(inter.Separador))
                            throw new Exception("Estrutura inválida.");

                        if (linhaArq1.Equals(linhaArq2))
                        {
                            linhaEncontrada = true;
                            this.Invoke(new Action(() =>
                            {
                                txtOutputStatus.AppendText("Linha comparada com sucesso. " + contador + Environment.NewLine);
                            }));
                            contador++;
                            break;
                        }
                    }
                    if (!linhaEncontrada)
                        throw new Exception("Linha não encontrada.");
                }
            }
            catch (Exception err)
            {
                this.Invoke(new Action(() =>
                {
                    txtOutputStatus.AppendText(err.Message + Environment.NewLine);
                }));
            }
        }

        private void backgroundWorker3_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] arquivos = (string[])e.Argument;
            if (arquivos.Length == 2)
                VerificaAuxiliar(arquivos);
            else
            {
                inter.ValidaEstrutura(arquivos[0]);
                this.Invoke(new Action(() =>
                {
                    txtOutputStatus.AppendText("Linha validada com sucesso. " + contador + Environment.NewLine);
                    contador++;
                }));
            }
        }

        public static bool pauseresume = false;
        private void btnPauseResume_Click(object sender, EventArgs e)
        {
            if (!pauseresume)
                pauseresume = true;
            else
                pauseresume = false;
        }

        void ResumeWorker()
        {
            _busy.Set();
        }

        void PauseWorker()
        {
            _busy.Reset();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            Thread.Sleep(2000);
            btnIniciar.Enabled = true;
            btnPauseResume.Enabled = false;
            this.btnAtualizaTemplate.Enabled = true;
            this.cmbSeparador.Enabled = true;
            this.chckHeader.Enabled = true;
            this.cmbTemplate.Enabled = true;
            this.btnReset.Enabled = false;
            if (!string.IsNullOrEmpty(arquivo1) && !string.IsNullOrEmpty(arquivo2))
            {
                this.btnSelecionaArq1.Enabled = true;
                this.btnSelecionaArq2.Enabled = true;
            }
            else if (!string.IsNullOrEmpty(arquivoValida))
                this.btnSelecionaArqValida.Enabled = true;
        }

        private void btnSelecionaArq1_Click(object sender, EventArgs e)
        {
            SelecionarArquivos(ref arquivo1);
            if (!string.IsNullOrEmpty(arquivo1) && !string.IsNullOrEmpty(arquivo2))
            {
                this.btnIniciar.Enabled = true;
                this.btnSelecionaArqValida.Enabled = false;
            }
            if (!string.IsNullOrEmpty(arquivo1))
            {
                txtArq1.Text = arquivo1;
                this.txtArq1.Enabled = true;
            }
        }

        private void btnSelecionaArq2_Click(object sender, EventArgs e)
        {
            SelecionarArquivos(ref arquivo2);
            if (!string.IsNullOrEmpty(arquivo1) && !string.IsNullOrEmpty(arquivo2))
            {
                this.btnIniciar.Enabled = true;
                this.btnSelecionaArqValida.Enabled = false;
            }
            if (!string.IsNullOrEmpty(arquivo2))
            {
                txtArq2.Text = arquivo2;
                this.txtArq2.Enabled = true;
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(arquivo1) && !string.IsNullOrEmpty(arquivo2))
            {
                this.cmbSeparador.Enabled = false;
                this.chckHeader.Enabled = false;
                this.btnAtualizaTemplate.Enabled = false;
                this.cmbTemplate.Enabled = false;
                this.btnPauseResume.Enabled = true;
                this.btnReset.Enabled = true;
                this.btnIniciar.Enabled = false;
                this.btnLimparLog.Enabled = true;
                this.btnSelecionaArq1.Enabled = false;
                this.btnSelecionaArq2.Enabled = false;
                pauseresume = false;



                if (chckHeader.Checked)
                    inter.Header = true;

                var arquivos = new string[] { arquivo1, arquivo2 };
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync(arquivos);
                }
            }
            else if (!string.IsNullOrEmpty(arquivoValida))
            {
                this.cmbSeparador.Enabled = false;
                this.chckHeader.Enabled = false;
                this.btnAtualizaTemplate.Enabled = false;
                this.cmbTemplate.Enabled = false;
                this.btnPauseResume.Enabled = true;
                this.btnReset.Enabled = true;
                this.btnIniciar.Enabled = false;
                this.btnLimparLog.Enabled = true;
                this.btnSelecionaArq1.Enabled = false;
                this.btnSelecionaArq2.Enabled = false;
                pauseresume = false;

                if (chckHeader.Checked)
                    inter.Header = true;

                var arquivo = new string[] { arquivoValida };
                if (!backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.RunWorkerAsync(arquivo);
                }
            }
            else
            {
                this.Invoke(new Action(() =>
                {
                    txtOutputStatus.AppendText("Necessário escolher dois arquivos para comparação." + Environment.NewLine);
                }));
            }
        }

        private void btnLimparLog_Click(object sender, EventArgs e)
        {
            txtOutputStatus.Text = String.Empty;
        }
        string arquivoValida = string.Empty;
        private void btnSelecionaArqValida_Click(object sender, EventArgs e)
        {
            SelecionarArquivos(ref arquivoValida);
            if (!string.IsNullOrEmpty(arquivoValida))
            {
                this.btnIniciar.Enabled = true;
                this.btnSelecionaArq1.Enabled = false;
                this.btnSelecionaArq2.Enabled = false;
            }
            if (!string.IsNullOrEmpty(arquivoValida))
            {
                txtValidaArq.Text = arquivoValida;
                this.txtValidaArq.Enabled = true;
            }
        }

    }
}
