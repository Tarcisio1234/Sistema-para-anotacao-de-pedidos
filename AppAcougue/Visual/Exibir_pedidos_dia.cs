using iText.IO.Font.Constants;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
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
using System.Diagnostics;
using System.IO;


namespace AppAcougue.Visual
{
    public partial class Exibir_pedidos_dia : Form
    {
        public Exibir_pedidos_dia()
        {
            InitializeComponent();
        }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Pedido { get; set; }
        public string Idpedidos { get; set; }
        public string Pagamento { get; set; }

        private void Exibir_pedidos_dia_Load(object sender, EventArgs e)
        {
            txtNome.Text = Nome;
            txtEndereco.Text = Endereco;
            txtTelefone.Text = Telefone;
            txtPedido.Text = Pedido;
            txtPagamento.Text = Pagamento;
            txtId2.Text = Idpedidos;
            txtPagamento.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {// botão voltar
            Historico novo = new Historico();
            novo.Show();
            this.Close();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
            {
                txtNome.Enabled = true;
                txtEndereco.Enabled = true;
                txtTelefone.Enabled = true;
                txtPedido.Enabled = true;
                txtPagamento.Enabled = true;
                btnEditar.Visible = true;
            }
            else
            {
                txtNome.Enabled = false;
                txtEndereco.Enabled = false;
                txtTelefone.Enabled = false;
                txtPedido.Enabled = false;
                txtPagamento.Enabled = false;
                btnEditar.Visible = false;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Pedidos editar = new Pedidos();
            {
                editar.Nome = txtNome.Text;
                editar.Endereco = txtEndereco.Text;
                editar.Telefone = txtTelefone.Text;
                editar.Pedido = txtPedido.Text;
                editar.Pagamento = txtPagamento.Text;
                editar.Idpedidos = int.Parse(txtId2.Text);
            }
            editar.EditarPedido();
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
