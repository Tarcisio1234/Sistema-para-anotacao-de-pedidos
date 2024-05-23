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
            DialogResult resposta = MessageBox.Show("Deseja limpar todos os campos ?","Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (resposta == DialogResult.Yes)
            {
                txtNome.Clear();
                txtEndereco.Clear();
                txtCelular.Clear();
            }
        }
    }
}
