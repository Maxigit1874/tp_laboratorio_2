using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FormCalculadora
{
    public partial class FormCalculadora : Form
    {
        int DecAbin = 0;
        int BinAdec = 0;

        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            if (DecAbin == 0)
            {
                DecAbin = 1;
                BinAdec = 0;

                if (lblResultado.Text != " ")
                {
                    string numero = lblResultado.Text;
                    string control;

                    Numero num1 = new Numero();
                    control = num1.DecimalBinario(numero);
                    
                    if (control == null)
                    {
                        MessageBox.Show("Valor invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        lblResultado.Text = control;
                    }
                }
            }else if (lblResultado.Text == " ")
            {
                MessageBox.Show("Valor invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("El numero no es decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {

            if (lblResultado.Text == " ")
            {
                MessageBox.Show("Valor invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                if (BinAdec == 0 && DecAbin == 1)
                {
                    BinAdec = 1;
                    DecAbin = 0;

                    string numero = lblResultado.Text;
                    string control;
                    Numero num1 = new Numero();

                    control = num1.BinarioDecimal(numero);
                   
                    if (control == null)
                    {
                        MessageBox.Show("Valor invalido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        lblResultado.Text = control;
                    }
                }
                else 
                {
                    MessageBox.Show("El numero no es binario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            DecAbin = 0;
            BinAdec = 0;
            Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            DecAbin = 0;
            BinAdec = 0;

            if (cmbOperador.SelectedItem == null)
            {
                cmbOperador.SelectedItem = "+";
            }
            
            resultado = Operar(txtNumero1.Text, txtNumero2.Text, cmbOperador.SelectedItem.ToString());
            lblResultado.Text = (resultado).ToString();
        }
                
        
        static double Operar(string numero1, string numero2, string operador)
        {
            double rta;

            Numero num1 = new Numero();
            Numero num2 = new Numero();

            num1.SetNumero = numero1;
            num2.SetNumero = numero2;
            
            rta = Calculadora.Operar(num1, num2, operador);

            return rta;
        }

        private void Limpiar()
        {
            txtNumero2.Clear();
            txtNumero1.Clear();
            lblResultado.Text = " ";
            cmbOperador.SelectedIndex = -1;
        }
    }
}
