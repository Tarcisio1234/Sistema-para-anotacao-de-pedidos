using AppAcougue.Visual;
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string nome = txtNome.Text;
            if (txtNome.Text.Length >= 3)
            {
                List<Cliente> cliente = new Cliente().BuscarCliente(nome);
                gridClientes.DataSource = cliente;
                gridClientes.Columns["idcliente"].Visible = false;
            }
            else
            {
                MessageBox.Show("Campo nome incompleto","Aviso",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }

        private void gridClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BuscarCliente_Load(object sender, EventArgs e)
        {
            List<Cliente> registros = Cliente.CarregarPedido();
            gridClientes.DataSource = registros;
            gridClientes.Columns["idcliente"].Visible = false;
        }

        private void gridClientes_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == gridClientes.Columns["Exibir"].Index)
            {
                Exibir_pedidos_dia propriedades = new Exibir_pedidos_dia();
                propriedades.Nome = gridClientes.SelectedCells[0].OwningRow.Cells["nome"].Value.ToString();
                propriedades.Endereco = gridClientes.SelectedCells[0].OwningRow.Cells["endereco"].Value.ToString();
                propriedades.Telefone = gridClientes.SelectedCells[0].OwningRow.Cells["telefone"].Value.ToString();
                propriedades.Pagamento = gridClientes.SelectedCells[0].OwningRow.Cells["pagamento"].Value.ToString();
                propriedades.Show();
                this.Hide();
            }
        }
    }
}

