using AppAcougue.Visual;
using Google.Protobuf.WellKnownTypes;
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
    public partial class PedidosAgendados : Form
    {
        public PedidosAgendados()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        { // botão voltar
            Menu novo = new Menu();
            novo.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {//Buscar Cliente
            string data = txtDate.Text;
            try
            {
                List<Agendados> cliente = new Agendados().DataPedidos(data);
                gridPedidosAgendados.DataSource = cliente;
                gridPedidosAgendados.Columns["idpedidosagendados"].Visible = false;
                gridPedidosAgendados.Columns["Pagamento"].Visible = false;
                gridPedidosAgendados.Columns["Telefone"].DisplayIndex = 4;
            }
            catch
            {
                MessageBox.Show("Não foi encontrado nenhum pedido nessa data", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }

        }

        private void PedidosAgendados_Load(object sender, EventArgs e)
        {
            List<Agendados> registros = Agendados.Carregar2();
            gridPedidosAgendados.DataSource = registros;
            gridPedidosAgendados.Columns["Idpedidosagendados"].Visible = false;
            gridPedidosAgendados.Columns["pedido"].Visible = false;
            gridPedidosAgendados.Columns["Pagamento"].Visible = false;
            gridPedidosAgendados.Columns["Telefone"].DisplayIndex = 4;
        }

        private void xuxa22_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == gridPedidosAgendados.Columns["Apaga"].Index)
            {
                int idPedido = (int)gridPedidosAgendados.Rows[e.RowIndex].Cells["Idpedidosagendados"].Value;
                Agendados registro = new Agendados();
                registro.Deletar(idPedido);

                List<Agendados> registros = Agendados.Carregar2();
                gridPedidosAgendados.DataSource = registros;
                gridPedidosAgendados.Columns["pedido"].Visible = false;
                gridPedidosAgendados.Columns["Telefone"].DisplayIndex = 4;
                gridPedidosAgendados.Columns["Pagamento"].Visible = false;
                gridPedidosAgendados.Columns["Idpedidosagendados"].Visible = false;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == gridPedidosAgendados.Columns["Exibir"].Index)
            {
                Exibir_Pedidos_Agendados propriedades = new Exibir_Pedidos_Agendados();
                propriedades.Nome = gridPedidosAgendados.SelectedCells[0].OwningRow.Cells["nome"].Value.ToString();
                propriedades.Endereco = gridPedidosAgendados.SelectedCells[0].OwningRow.Cells["endereco"].Value.ToString();
                propriedades.Telefone = gridPedidosAgendados.SelectedCells[0].OwningRow.Cells["telefone"].Value.ToString();
                propriedades.Pedido = gridPedidosAgendados.SelectedCells[0].OwningRow.Cells["pedido"].Value.ToString();
                propriedades.Idpedidosagendados = gridPedidosAgendados.SelectedCells[0].OwningRow.Cells["idpedidosagendados"].Value.ToString();
                propriedades.Pagamento = gridPedidosAgendados.SelectedCells[0].OwningRow.Cells["Pagamento"].Value.ToString();
                propriedades.Show();
                this.Hide();
            }
        }
    }
}
