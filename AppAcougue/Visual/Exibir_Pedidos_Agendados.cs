using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using System;
//using System.Collections.Generic;
//using System.ComponentModel;
using System.Data;
using System.Diagnostics;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
//using iText.Kernel.Font;
//using iText.Kernel.Geom;
//using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
//using System.Diagnostics;
using System.IO;

namespace AppAcougue.Visual
{
    public partial class Exibir_Pedidos_Agendados : Form
    {
        public Exibir_Pedidos_Agendados()
        {
            InitializeComponent();
        }

        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Pedido { get; set; }
        public string Idpedidosagendados { get; set; }
        public string Pagamento { get; set; }


        private void button2_Click(object sender, EventArgs e)
        {
            PedidosAgendados novo = new PedidosAgendados();
            novo.Show();
            this.Close();
        }

        private void Exibir_Pedidos_Agendados_Load(object sender, EventArgs e)
        {

            txtNome.Text = Nome;
            txtEndereco.Text = Endereco;
            txtTelefone.Text = Telefone;
            txtPedido.Text = Pedido;
            txtPagamento.Text = Pagamento;
            txtId2.Text = Idpedidosagendados;

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                btnEditar.Visible = true;
                txtNome.Enabled = true;
                txtEndereco.Enabled = true;
                txtTelefone.Enabled = true;
                dataAgenda.Enabled = true;
                txtPedido.Enabled = true;
                txtPagamento.Enabled = true;
            }
            else
            {
                btnEditar.Visible = false;
                txtNome.Enabled = false;
                txtEndereco.Enabled = false;
                txtTelefone.Enabled = false;
                dataAgenda.Enabled = false;
                txtPedido.Enabled = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {// Botão de salvar as alterações
            Agendados editar = new Agendados();
            {
                DateTime data = DateTime.Parse(dataAgenda.Text);

                editar.Nome = txtNome.Text;
                editar.Endereco = txtEndereco.Text;
                editar.Telefone = txtTelefone.Text;
                editar.Data = data;
                editar.Pedido = txtPedido.Text;
                editar.Idpedidosagendados = int.Parse(txtId2.Text);
                editar.Pagamento = txtPagamento.Text;
            }
            editar.AtualizarPedidoAgendado();
        }

        private void btn_Imprimir_Click(object sender, EventArgs e)
        {
            GerarPdf();
            string caminhoDoArquivoPdf = @"c:\dados\pedido.pdf";
            ExibirPdfNoNavegador(caminhoDoArquivoPdf);

        }
        private void GerarPdf()
        {
            var arquivo = @"C:\dados\pedido.pdf";
            using (PdfWriter wPdf = new PdfWriter(arquivo, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                var pageSize = new PageSize(226.772f, 844.7207f);
                var pdfDocument = new PdfDocument(wPdf);
                var document = new Document(pdfDocument, pageSize);
                document.SetMargins(15, 15, 15, 15);
                var helvetica = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);
                document.SetFont(helvetica);
                document.SetFontSize(18);

                document.Add(new Paragraph(txtPedido.Text));
                document.Add(new Paragraph(txtEndereco.Text));
                document.Add(new Paragraph(txtNome.Text));
                document.Add(new Paragraph(txtPagamento.Text));
                document.Add(new Paragraph(txtTelefone.Text));
                // ajustando a impressão 

                document.Close();
                pdfDocument.Close();
            }
        }
        private void ExibirPdfNoNavegador(string caminhoDoArquivoPdf)
        {
            if (File.Exists(caminhoDoArquivoPdf))
            {
                try
                {
                    ProcessStartInfo startInfo = new ProcessStartInfo
                    {
                        FileName = caminhoDoArquivoPdf,
                        UseShellExecute = true
                    };
                    Process.Start(startInfo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Não foi possível abrir o arquivo PDF: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Arquivo PDF não encontrado: " + caminhoDoArquivoPdf);
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
