using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppAcougue
{
    public partial class CadastroClientecs : Form
    {
        public CadastroClientecs()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Menu novo = new Menu();
            novo.Show();
            this.Close();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            DialogResult resposta = MessageBox.Show("Deseja limpar todos os campos ?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resposta == DialogResult.Yes)
            {
                txtNome.Clear();
                txtEndereco.Clear();
                txtTelefone.Clear();
            }
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            DialogResult cliqueS =
                MessageBox.Show("Deseja confirmar o salvamento dos seus dados de usuário?", "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            Cliente usuarios = new Cliente();
                if (cliqueS == DialogResult.OK)
                {
                if (txtNome.Text.Length > 3)
                {
                    Cliente usuario = new Cliente();
                    usuario.Nome = txtNome.Text;
                    usuario.Endereco = txtEndereco.Text;
                    usuario.Telefone = txtTelefone.Text;
                    usuario.Salvar();
                    txtTelefone.Clear() ;
                    txtNome.Clear() ;
                    txtEndereco.Clear() ;
                }
                else
                {
                    MessageBox.Show("O campo nome esta vazio ou insuficiente","Erro",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

                }
            
                else
                {
                MessageBox.Show("Não foi possivel salvar os dados dos cliente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        { // O txt nome aceita apenas letras
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtTelefone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
