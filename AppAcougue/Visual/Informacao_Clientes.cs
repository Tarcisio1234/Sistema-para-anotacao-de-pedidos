using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppAcougue.Visual
{
    public partial class Exibir_Cliente : Form
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Idcliente { get; set; }

        public Exibir_Cliente()
        {
            InitializeComponent();
        }

        private void Exibir_Cliente_Load(object sender, EventArgs e)
        {
            txtNome.Text = Nome;
            txtEndereco.Text = Endereco;
            txtTelefone.Text = Telefone;
            txtIdcliente.Text = Idcliente;
            btnSalvar.Visible = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente();
            cliente.Nome = txtNome.Text;
            cliente.Endereco = txtEndereco.Text;
            cliente.Telefone = txtTelefone.Text;
            cliente.Idcliente = int.Parse(txtIdcliente.Text);
            cliente.EditarCadastroCliente();

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            BuscarCliente novo = new BuscarCliente();
            novo.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtNome.Enabled = true;
                txtEndereco.Enabled = true;
                txtTelefone.Enabled = true;
                btnSalvar.Visible = true;
            }
            else
            {
                txtNome.Enabled = false;
                txtEndereco.Enabled = false;
                txtTelefone.Enabled = false;
                btnSalvar.Visible=false;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Esse codigo faz com que o txtNome aceite apenas numero
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
