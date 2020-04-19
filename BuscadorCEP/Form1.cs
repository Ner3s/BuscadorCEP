using Refit;
using System;
using System.Windows.Forms;

namespace BuscadorCEP
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public async void resultApi()
        {
            try
            {
                if (txtCep.MaskCompleted == true)
                {
                    var cepClient = RestService.For<ICepApiService>("http://viacep.com.br");
                    var address = await cepClient.GetAddressAsync(txtCep.Text);
                    lblLogradouro.Text = address.Logradouro;
                    lblBairro.Text = address.Bairro;
                    lblCidade.Text = address.Localidade;
                    lblEstado.Text = address.Uf;
                }
                else
                {
                    MessageBox.Show("Digite um CEP Válido!");
                }

            }
            catch (Exception Ex)
            {
                Console.WriteLine("Deu o seguinte error: " + Ex);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            resultApi();
        }

        private void txtCep_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Se a tecla digitada não for número
            if (!char.IsDigit(e.KeyChar))
            {
                //Atribui True no Handled para cancelar o evento
                e.Handled = true;
            }

            if (e.KeyChar == (char)13)
            {
                resultApi();
            }
        }
    }
}
