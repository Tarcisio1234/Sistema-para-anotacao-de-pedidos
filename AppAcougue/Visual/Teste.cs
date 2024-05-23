using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AppAcougue.Conexao;

namespace AppAcougue
{
    public partial class Teste : Form
    {
        public Teste()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Menu novo = new Menu();
            novo.Show();
            this.Close();
        }

        private void btnTeste_Click(object sender, EventArgs e)
        {

            MySqlConnectionManager connectionManager = new MySqlConnectionManager();

            if (connectionManager.OpenConnection())
            {
                MessageBox.Show("O teste foi feito com sucesso!!!");
                connectionManager.CloseConnection();
            }
            else
            {
                MessageBox.Show("O teste de conexão falhou :( ");
            }
        }
    }
}
