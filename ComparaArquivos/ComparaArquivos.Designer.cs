using System.IO;
using System;
using System.Windows.Forms;

namespace ComparaArquivos
{
    partial class ComparaArquivos
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtOutputStatus = new System.Windows.Forms.TextBox();
            this.cmbTemplate = new System.Windows.Forms.ComboBox();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.lblValidaEstrutura = new System.Windows.Forms.Label();
            this.cmbSeparador = new System.Windows.Forms.ComboBox();
            this.chckHeader = new System.Windows.Forms.CheckBox();
            this.grpBConfig = new System.Windows.Forms.GroupBox();
            this.lblIncluirTemp = new System.Windows.Forms.Label();
            this.btnIncluirTemplate = new System.Windows.Forms.Button();
            this.lblSeparador = new System.Windows.Forms.Label();
            this.lblComparaArquivo = new System.Windows.Forms.Label();
            this.grpBArquivo = new System.Windows.Forms.GroupBox();
            this.btnSelecionaArqValida = new System.Windows.Forms.Button();
            this.txtValidaArq = new System.Windows.Forms.TextBox();
            this.btnSelecionaArq2 = new System.Windows.Forms.Button();
            this.btnSelecionaArq1 = new System.Windows.Forms.Button();
            this.txtArq2 = new System.Windows.Forms.TextBox();
            this.btnAtualizaTemplate = new System.Windows.Forms.Button();
            this.txtArq1 = new System.Windows.Forms.TextBox();
            this.btnPauseResume = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            this.backgroundWorker3 = new System.ComponentModel.BackgroundWorker();
            this.grpBBotoes = new System.Windows.Forms.GroupBox();
            this.btnLimparLog = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnIniciar = new System.Windows.Forms.Button();
            this.grpBConfig.SuspendLayout();
            this.grpBArquivo.SuspendLayout();
            this.grpBBotoes.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOutputStatus
            // 
            this.txtOutputStatus.Location = new System.Drawing.Point(27, 25);
            this.txtOutputStatus.Multiline = true;
            this.txtOutputStatus.Name = "txtOutputStatus";
            this.txtOutputStatus.ReadOnly = true;
            this.txtOutputStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutputStatus.Size = new System.Drawing.Size(418, 476);
            this.txtOutputStatus.TabIndex = 0;
            // 
            // cmbTemplate
            // 
            this.cmbTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTemplate.Enabled = false;
            this.cmbTemplate.FormattingEnabled = true;
            this.cmbTemplate.Location = new System.Drawing.Point(13, 47);
            this.cmbTemplate.Name = "cmbTemplate";
            this.cmbTemplate.Size = new System.Drawing.Size(126, 21);
            this.cmbTemplate.TabIndex = 2;
            this.cmbTemplate.SelectedIndexChanged += new System.EventHandler(this.cmbTemplate_SelectedIndexChanged);
            // 
            // lblTemplate
            // 
            this.lblTemplate.AutoSize = true;
            this.lblTemplate.Location = new System.Drawing.Point(7, 31);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(54, 13);
            this.lblTemplate.TabIndex = 4;
            this.lblTemplate.Text = "Template:";
            // 
            // lblValidaEstrutura
            // 
            this.lblValidaEstrutura.AutoSize = true;
            this.lblValidaEstrutura.Location = new System.Drawing.Point(7, 179);
            this.lblValidaEstrutura.Name = "lblValidaEstrutura";
            this.lblValidaEstrutura.Size = new System.Drawing.Size(84, 13);
            this.lblValidaEstrutura.TabIndex = 6;
            this.lblValidaEstrutura.Text = "Valida Estrutura:";
            // 
            // cmbSeparador
            // 
            this.cmbSeparador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeparador.FormattingEnabled = true;
            this.cmbSeparador.Items.AddRange(new object[] {
            "Ponto e Vírgula",
            "Vírgula"});
            this.cmbSeparador.Location = new System.Drawing.Point(6, 34);
            this.cmbSeparador.Name = "cmbSeparador";
            this.cmbSeparador.Size = new System.Drawing.Size(97, 21);
            this.cmbSeparador.TabIndex = 7;
            this.cmbSeparador.SelectedIndexChanged += new System.EventHandler(this.cmbSeparador_SelectedIndexChanged);
            // 
            // chckHeader
            // 
            this.chckHeader.AutoSize = true;
            this.chckHeader.Location = new System.Drawing.Point(6, 74);
            this.chckHeader.Name = "chckHeader";
            this.chckHeader.Size = new System.Drawing.Size(97, 17);
            this.chckHeader.TabIndex = 8;
            this.chckHeader.Text = "Ignorar Header";
            this.chckHeader.UseVisualStyleBackColor = true;
            this.chckHeader.CheckedChanged += new System.EventHandler(this.chckHeader_CheckedChanged);
            // 
            // grpBConfig
            // 
            this.grpBConfig.Controls.Add(this.lblIncluirTemp);
            this.grpBConfig.Controls.Add(this.btnIncluirTemplate);
            this.grpBConfig.Controls.Add(this.lblSeparador);
            this.grpBConfig.Controls.Add(this.cmbSeparador);
            this.grpBConfig.Controls.Add(this.chckHeader);
            this.grpBConfig.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grpBConfig.Location = new System.Drawing.Point(474, 36);
            this.grpBConfig.Name = "grpBConfig";
            this.grpBConfig.Size = new System.Drawing.Size(225, 100);
            this.grpBConfig.TabIndex = 9;
            this.grpBConfig.TabStop = false;
            this.grpBConfig.Text = "Configuração do Arquivo";
            // 
            // lblIncluirTemp
            // 
            this.lblIncluirTemp.AutoSize = true;
            this.lblIncluirTemp.Location = new System.Drawing.Point(128, 19);
            this.lblIncluirTemp.Name = "lblIncluirTemp";
            this.lblIncluirTemp.Size = new System.Drawing.Size(85, 13);
            this.lblIncluirTemp.TabIndex = 11;
            this.lblIncluirTemp.Text = "Incluir Template:";
            // 
            // btnIncluirTemplate
            // 
            this.btnIncluirTemplate.Location = new System.Drawing.Point(138, 34);
            this.btnIncluirTemplate.Name = "btnIncluirTemplate";
            this.btnIncluirTemplate.Size = new System.Drawing.Size(75, 23);
            this.btnIncluirTemplate.TabIndex = 10;
            this.btnIncluirTemplate.Text = "Pasta..";
            this.btnIncluirTemplate.UseVisualStyleBackColor = true;
            this.btnIncluirTemplate.Click += new System.EventHandler(this.btnIncluirTemplate_Click);
            // 
            // lblSeparador
            // 
            this.lblSeparador.AutoSize = true;
            this.lblSeparador.Location = new System.Drawing.Point(7, 20);
            this.lblSeparador.Name = "lblSeparador";
            this.lblSeparador.Size = new System.Drawing.Size(59, 13);
            this.lblSeparador.TabIndex = 9;
            this.lblSeparador.Text = "Separador:";
            // 
            // lblComparaArquivo
            // 
            this.lblComparaArquivo.AutoSize = true;
            this.lblComparaArquivo.Location = new System.Drawing.Point(6, 80);
            this.lblComparaArquivo.Name = "lblComparaArquivo";
            this.lblComparaArquivo.Size = new System.Drawing.Size(129, 13);
            this.lblComparaArquivo.TabIndex = 10;
            this.lblComparaArquivo.Text = "Comparação de Arquivos:";
            // 
            // grpBArquivo
            // 
            this.grpBArquivo.Controls.Add(this.btnSelecionaArqValida);
            this.grpBArquivo.Controls.Add(this.txtValidaArq);
            this.grpBArquivo.Controls.Add(this.btnSelecionaArq2);
            this.grpBArquivo.Controls.Add(this.btnSelecionaArq1);
            this.grpBArquivo.Controls.Add(this.txtArq2);
            this.grpBArquivo.Controls.Add(this.btnAtualizaTemplate);
            this.grpBArquivo.Controls.Add(this.txtArq1);
            this.grpBArquivo.Controls.Add(this.lblComparaArquivo);
            this.grpBArquivo.Controls.Add(this.cmbTemplate);
            this.grpBArquivo.Controls.Add(this.lblValidaEstrutura);
            this.grpBArquivo.Controls.Add(this.lblTemplate);
            this.grpBArquivo.Location = new System.Drawing.Point(474, 155);
            this.grpBArquivo.Name = "grpBArquivo";
            this.grpBArquivo.Size = new System.Drawing.Size(335, 260);
            this.grpBArquivo.TabIndex = 11;
            this.grpBArquivo.TabStop = false;
            this.grpBArquivo.Text = "Seleção de Arquivo";
            // 
            // btnSelecionaArqValida
            // 
            this.btnSelecionaArqValida.Enabled = false;
            this.btnSelecionaArqValida.Location = new System.Drawing.Point(246, 201);
            this.btnSelecionaArqValida.Name = "btnSelecionaArqValida";
            this.btnSelecionaArqValida.Size = new System.Drawing.Size(76, 23);
            this.btnSelecionaArqValida.TabIndex = 17;
            this.btnSelecionaArqValida.Text = "Selecionar...";
            this.btnSelecionaArqValida.UseVisualStyleBackColor = true;
            this.btnSelecionaArqValida.Click += new System.EventHandler(this.btnSelecionaArqValida_Click);
            // 
            // txtValidaArq
            // 
            this.txtValidaArq.Enabled = false;
            this.txtValidaArq.Location = new System.Drawing.Point(6, 204);
            this.txtValidaArq.Name = "txtValidaArq";
            this.txtValidaArq.ReadOnly = true;
            this.txtValidaArq.Size = new System.Drawing.Size(226, 20);
            this.txtValidaArq.TabIndex = 16;
            // 
            // btnSelecionaArq2
            // 
            this.btnSelecionaArq2.Enabled = false;
            this.btnSelecionaArq2.Location = new System.Drawing.Point(246, 137);
            this.btnSelecionaArq2.Name = "btnSelecionaArq2";
            this.btnSelecionaArq2.Size = new System.Drawing.Size(76, 23);
            this.btnSelecionaArq2.TabIndex = 15;
            this.btnSelecionaArq2.Text = "Selecionar...";
            this.btnSelecionaArq2.UseVisualStyleBackColor = true;
            this.btnSelecionaArq2.Click += new System.EventHandler(this.btnSelecionaArq2_Click);
            // 
            // btnSelecionaArq1
            // 
            this.btnSelecionaArq1.Enabled = false;
            this.btnSelecionaArq1.Location = new System.Drawing.Point(246, 103);
            this.btnSelecionaArq1.Name = "btnSelecionaArq1";
            this.btnSelecionaArq1.Size = new System.Drawing.Size(76, 23);
            this.btnSelecionaArq1.TabIndex = 14;
            this.btnSelecionaArq1.Text = "Selecionar...";
            this.btnSelecionaArq1.UseVisualStyleBackColor = true;
            this.btnSelecionaArq1.Click += new System.EventHandler(this.btnSelecionaArq1_Click);
            // 
            // txtArq2
            // 
            this.txtArq2.Enabled = false;
            this.txtArq2.Location = new System.Drawing.Point(9, 137);
            this.txtArq2.Name = "txtArq2";
            this.txtArq2.ReadOnly = true;
            this.txtArq2.Size = new System.Drawing.Size(223, 20);
            this.txtArq2.TabIndex = 13;
            // 
            // btnAtualizaTemplate
            // 
            this.btnAtualizaTemplate.Location = new System.Drawing.Point(150, 47);
            this.btnAtualizaTemplate.Name = "btnAtualizaTemplate";
            this.btnAtualizaTemplate.Size = new System.Drawing.Size(63, 23);
            this.btnAtualizaTemplate.TabIndex = 11;
            this.btnAtualizaTemplate.Text = "Atualizar";
            this.btnAtualizaTemplate.UseVisualStyleBackColor = true;
            this.btnAtualizaTemplate.Click += new System.EventHandler(this.btnAtualizaTemplate_Click);
            // 
            // txtArq1
            // 
            this.txtArq1.Enabled = false;
            this.txtArq1.Location = new System.Drawing.Point(9, 106);
            this.txtArq1.Name = "txtArq1";
            this.txtArq1.ReadOnly = true;
            this.txtArq1.Size = new System.Drawing.Size(223, 20);
            this.txtArq1.TabIndex = 12;
            // 
            // btnPauseResume
            // 
            this.btnPauseResume.Enabled = false;
            this.btnPauseResume.Location = new System.Drawing.Point(87, 19);
            this.btnPauseResume.Name = "btnPauseResume";
            this.btnPauseResume.Size = new System.Drawing.Size(89, 23);
            this.btnPauseResume.TabIndex = 12;
            this.btnPauseResume.Text = "Pause/Resume";
            this.btnPauseResume.UseVisualStyleBackColor = true;
            this.btnPauseResume.Click += new System.EventHandler(this.btnPauseResume_Click);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // backgroundWorker2
            // 
            this.backgroundWorker2.WorkerReportsProgress = true;
            this.backgroundWorker2.WorkerSupportsCancellation = true;
            this.backgroundWorker2.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker2_DoWork);
            // 
            // backgroundWorker3
            // 
            this.backgroundWorker3.WorkerReportsProgress = true;
            this.backgroundWorker3.WorkerSupportsCancellation = true;
            this.backgroundWorker3.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker3_DoWork);
            // 
            // grpBBotoes
            // 
            this.grpBBotoes.Controls.Add(this.btnLimparLog);
            this.grpBBotoes.Controls.Add(this.btnReset);
            this.grpBBotoes.Controls.Add(this.btnIniciar);
            this.grpBBotoes.Controls.Add(this.btnPauseResume);
            this.grpBBotoes.Location = new System.Drawing.Point(474, 421);
            this.grpBBotoes.Name = "grpBBotoes";
            this.grpBBotoes.Size = new System.Drawing.Size(186, 80);
            this.grpBBotoes.TabIndex = 13;
            this.grpBBotoes.TabStop = false;
            this.grpBBotoes.Text = "Controles";
            // 
            // btnLimparLog
            // 
            this.btnLimparLog.Location = new System.Drawing.Point(89, 47);
            this.btnLimparLog.Name = "btnLimparLog";
            this.btnLimparLog.Size = new System.Drawing.Size(87, 23);
            this.btnLimparLog.TabIndex = 15;
            this.btnLimparLog.Text = "Limpar Log";
            this.btnLimparLog.UseVisualStyleBackColor = true;
            this.btnLimparLog.Click += new System.EventHandler(this.btnLimparLog_Click);
            // 
            // btnReset
            // 
            this.btnReset.Enabled = false;
            this.btnReset.Location = new System.Drawing.Point(7, 48);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 14;
            this.btnReset.Text = "Parar";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnIniciar
            // 
            this.btnIniciar.Enabled = false;
            this.btnIniciar.Location = new System.Drawing.Point(6, 19);
            this.btnIniciar.Name = "btnIniciar";
            this.btnIniciar.Size = new System.Drawing.Size(75, 23);
            this.btnIniciar.TabIndex = 13;
            this.btnIniciar.Text = "Iniciar";
            this.btnIniciar.UseVisualStyleBackColor = true;
            this.btnIniciar.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // ComparaArquivos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 513);
            this.Controls.Add(this.grpBBotoes);
            this.Controls.Add(this.grpBArquivo);
            this.Controls.Add(this.grpBConfig);
            this.Controls.Add(this.txtOutputStatus);
            this.Name = "ComparaArquivos";
            this.Text = "Compara Arquivos";
            this.grpBConfig.ResumeLayout(false);
            this.grpBConfig.PerformLayout();
            this.grpBArquivo.ResumeLayout(false);
            this.grpBArquivo.PerformLayout();
            this.grpBBotoes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtOutputStatus;
        private System.Windows.Forms.ComboBox cmbTemplate;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.Label lblValidaEstrutura;

        private void CriaTemplates()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + @"\Templates";
            bool exists = System.IO.Directory.Exists(path);
            if (!exists)
            {
                System.IO.Directory.CreateDirectory(path);
                string templatePadrao = path + @"\Exemplo.json";
                File.Create(templatePadrao).Close();
                using (StreamWriter writer = new StreamWriter(templatePadrao))
                    writer.WriteLine("{\r\n\t\"campo01\": \"string\",\r\n\t\"campo02\": \"int\",\r\n\t\"campo03\": \"double\",\r\n\t\"campo04\": \"datetime\",\r\n\t\"campo05\": \"bool\"\r\n}");
                cmbTemplate.Items.Add("Exemplo");
            }
            else
            {
                PopulaTemplates(path);
            }

        }

        private void PopulaTemplates(string path)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            foreach (var file in dir.GetFiles())
            {
                var nomeTemplate = Path.GetFileNameWithoutExtension(file.Name);
                if (!cmbTemplate.Items.Contains(nomeTemplate))
                    cmbTemplate.Items.Add(nomeTemplate);
            }
        }

        private ComboBox cmbSeparador;
        private CheckBox chckHeader;
        private GroupBox grpBConfig;
        private Label lblSeparador;
        private Label lblComparaArquivo;
        private GroupBox grpBArquivo;
        private Label lblIncluirTemp;
        private Button btnIncluirTemplate;
        private Button btnAtualizaTemplate;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private System.ComponentModel.BackgroundWorker backgroundWorker3;
        private Button btnPauseResume;
        private Button btnSelecionaArqValida;
        private TextBox txtValidaArq;
        private Button btnSelecionaArq2;
        private Button btnSelecionaArq1;
        private TextBox txtArq2;
        private TextBox txtArq1;
        private GroupBox grpBBotoes;
        private Button btnReset;
        private Button btnIniciar;
        private Button btnLimparLog;
    }
}

