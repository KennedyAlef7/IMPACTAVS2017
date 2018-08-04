using System;
using System.Windows.Forms;

namespace AspNetVS2017.Capitulo01.Tabuada
{
    public partial class TabuadaForm : Form
    {
        public TabuadaForm()
        {
            InitializeComponent();
        }

        private void tabuadaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar >= '0' && e.KeyChar <= '9' 
                || e.KeyChar == '\b' || e.KeyChar == '\r' )
            {
                if (e.KeyChar == 13)
                {
                    Calcular();
                }
            }
            else
            {
                //e.Handled = true;
                e.KeyChar = '\0';
            }
        }

        private void Calcular()
        {
            tabuadaListBox.Items.Clear();

            var tabuada = Convert.ToInt32(tabuadaTextBox.Text);

            for (int i = 0; i <= 10; i++)
            {
                tabuadaListBox.Items.Add($"{tabuada} x {i} = {tabuada * i}");
            }

            tabuadaTextBox.Focus();
            tabuadaTextBox.SelectAll();
        }
    }
}