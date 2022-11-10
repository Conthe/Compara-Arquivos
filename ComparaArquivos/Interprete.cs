using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ComparaArquivos
{
    internal class Interprete
    {
        public Dictionary<string, string> Instrucao { get; set; }
        public char Separador { get; set; }
        public bool Header { get; set; }

        public void ValidaEstrutura(string arquivo)
        {
            var estruturaDado = arquivo.Split(Separador);

            if (estruturaDado.Length != Instrucao.Count)
                throw new Exception("Estrutura inválida.");

            TestaTipoCampo(estruturaDado);
        }

        public void TestaTipoCampo(string[] arquivo)
        {
            try
            {
                List<string> tipos = new List<string>();
                foreach (var key in Instrucao.Keys)
                    tipos.Add(key);
                
                for (int i = 0; i < Instrucao.Count; i++)
                {
                    var tipo = Instrucao[tipos[i]];
                    object result = new object();
                    DateTime rslt;
                    bool success = false;
                    double valor = 0;
                    int numero = 0;
                    switch (tipo)
                    {
                        case "string":

                            break;
                        case "datetime":
                            success = DateTime.TryParse(arquivo[i], out rslt);
                            if (success)
                                break;
                            else
                                throw new Exception();
                        case "double":
                            var valorComVirgula = arquivo[i].Replace('.', ',');
                            success = double.TryParse(valorComVirgula, out valor);
                            if (success)
                                break;
                            else
                                throw new Exception();
                        case "int":
                            success = int.TryParse(arquivo[i], out numero);
                            if (success)
                                break;
                            else
                                throw new Exception();
                        case "bool":
                            if (arquivo[i].Equals("true") || arquivo[i].Equals("false"))
                                break;
                            else
                                throw new Exception();
                        case "lista":

                            break;
                        default:

                            break;
                    }
                }
            }
            catch (Exception)
            {
                throw new Exception("Tipo inválido.");
            }
        }
    }
}
