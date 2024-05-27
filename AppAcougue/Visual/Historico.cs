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
    public partial class Historico : Form
    {
        public Historico()
        {
            InitializeComponent();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Menu novo = new Menu();
            novo.Show();
            this.Close();
        }

        private void Historico_Load(object sender, EventArgs e)
        {   Pedidos pedidos = new Pedidos();
            pedidos.DeletarPedidosDoDia();
            List<Pedidos> registros = Pedidos.CarregarPedido();
            gridHistorico.DataSource = registros;
            gridHistorico.Columns["Idpedidos"].Visible=false;
            gridHistorico.Columns["Data"].Visible = false;
            gridHistorico.Columns["pedido"].Visible = false;
            gridHistorico.Columns["Pagamento"].Visible = false;
            gridHistorico.Columns["Apagar"].DisplayIndex = 7;
            gridHistorico.Columns["Exibir"].DisplayIndex = 6;
        }

        private void dataHistorico_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == gridHistorico.Columns["Apagar"].Index)
            {
                int idpedido = (int)gridHistorico.Rows[e.RowIndex].Cells["Idpedidos"].Value;
                Pedidos registro = new Pedidos();
                registro.Deletar(idpedido);

                List<Pedidos> registros = Pedidos.Carregar();
                gridHistorico.DataSource = registros;
                gridHistorico.Columns["Idpedidos"].Visible = false;
                gridHistorico.Columns["Data"].Visible = false;
                gridHistorico.Columns["Apagar"].DisplayIndex = 7;
                gridHistorico.Columns["Exibir"].DisplayIndex = 6;
                gridHistorico.Columns["pedido"].Visible = false;
            }
            if (e.RowIndex >= 0 && e.ColumnIndex == gridHistorico.Columns["Exibir"].Index)
            {
                    Exibir_pedidos_dia propriedades = new Exibir_pedidos_dia();
                    propriedades.Nome = gridHistorico.SelectedCells[0].OwningRow.Cells["nome"].Value.ToString();
                    propriedades.Endereco = gridHistorico.SelectedCells[0].OwningRow.Cells["endereco"].Value.ToString();
                    propriedades.Telefone = gridHistorico.SelectedCells[0].OwningRow.Cells["telefone"].Value.ToString();
                    propriedades.Pedido = gridHistorico.SelectedCells[0].OwningRow.Cells["pedido"].Value.ToString();
                    propriedades.Idpedidos = gridHistorico.SelectedCells[0].OwningRow.Cells["idpedidos"].Value.ToString();
                    propriedades.Pagamento = gridHistorico.SelectedCells[0].OwningRow.Cells["pagamento"].Value.ToString();
                    propriedades.Show();
                    this.Hide();
            }
        }
    }
}
