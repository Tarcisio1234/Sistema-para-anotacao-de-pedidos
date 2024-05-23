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
    public partial class BuscarCliente : Form
    {
        public BuscarCliente()
        {
            InitializeComponent();
        }

        private void buttonbtnVoltar_Click(object sender, EventArgs e)
        {
            Menu novo = new Menu();
            novo.Show();
            this.Close();
        }
    }
}
