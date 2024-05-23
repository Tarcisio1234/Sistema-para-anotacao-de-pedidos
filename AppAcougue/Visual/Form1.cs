using System;
/*using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;*/
using System.Windows.Forms;

namespace AppAcougue
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            CadastroClientecs novo = new CadastroClientecs();
            novo.Show();
            this.Hide();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            AnotarPedido novo = new AnotarPedido();
            novo.Show();
            this.Hide();
        }

        private void btnVerCadastro_Click(object sender, EventArgs e)
        {
            BuscarCliente novo = new BuscarCliente();
            novo.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Teste novo = new Teste();
            novo.Show();
            this.Hide();
        }

        private void btnPedidosAnotados_Click(object sender, EventArgs e)
        {
            PedidosAgendados novo = new PedidosAgendados();
            novo.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Historico novo = new Historico();
            novo.Show();
            this.Hide();
        }
    }
}
