using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo01.Fretes
{
    public partial class FretesForm : Form
    {
        public FretesForm()
        {
            InitializeComponent();
        }

        private void calcularButton_Click(object sender, EventArgs e)
        {
            var erros = ValidarFormulario();

            //if (!erros.Any())
            if (erros.Count == 0)
            {
                Calcular();
            }
            else
            {
                MessageBox.Show(string.Join(Environment.NewLine, erros),
                    "Validação",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void Calcular()
        {
            var percentual = 0m;
            var valor = Convert.ToDecimal(valorTextBox.Text);
            var nordeste = new List<string> { "BA", "PE", "AL" };

            switch (ufComboBox.Text.ToUpper())
            {
                case "SP":
                    percentual = 0.2m;
                    break;
                case "ES":
                case "RJ":
                    percentual = 0.3m;
                    break;
                case "MG":
                    percentual = 0.35m;
                    break;
                case var uf when nordeste.Contains(uf):
                    percentual = 0.4m;
                    break;
                case "AM":
                    percentual = 0.6m;
                    break;
                case null:
                    throw new NullReferenceException("A UF não pode ser nula.");
                default:
                    percentual = 0.75m;
                    break;
            }

            freteTextBox.Text = percentual.ToString("P2");
            totalTextBox.Text = (valor * (1 + percentual)).ToString("C");
        }

        /// <summary>
        /// Realiza a validação do formulário.
        /// </summary>
        /// <returns></returns>
        private List<string> ValidarFormulario()
        {
            var erros = new List<string>();

            if (clienteTextBox.Text.Trim() == string.Empty)
            {
                erros.Add("O campo Cliente é obrigatório.");
            }

            if (string.IsNullOrEmpty(valorTextBox.Text.Trim()))
            {
                erros.Add("O campo Valor é obrigatório.");
            }
            else
            {
                //decimal valor;
                //if (decimal.TryParse(valorTextBox.Text.Trim(), out valor))
                if (!decimal.TryParse(valorTextBox.Text.Trim(), out decimal valor))
                {
                    erros.Add("O campo Valor está com formato inválido.");
                }
            }

            if (ufComboBox.SelectedIndex == -1)
            {
                erros.Add("Selecione a UF de destino.");
            }

            return erros;
        }

        private void limparButton_Click(object sender, EventArgs e)
        {
            clienteTextBox.Text = string.Empty;
            ufComboBox.SelectedIndex = -1;
            valorTextBox.Clear();
            freteTextBox.Text = null;
            totalTextBox.Text = "";

            clienteTextBox.Focus();
        }
    }
}
