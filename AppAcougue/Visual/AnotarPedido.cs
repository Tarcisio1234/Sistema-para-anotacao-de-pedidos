using iText.IO.Font.Constants;
//using iText.Kernel.Colors;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
//using iText.Layout.Properties;
using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
using System.Diagnostics;
//using System.Drawing;
using System.IO;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppAcougue
{
    public partial class AnotarPedido : Form
    {
        public AnotarPedido()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {// Botão de voltar
            Menu novo = new Menu();
            novo.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {//botão de cadastrar na tela de anotar o pedido
            DialogResult cliqueS =
                   MessageBox.Show("Deseja confirmar o salvamento dos seus dados de usuário?", "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            Cliente usuarios = new Cliente();
            if (cliqueS == DialogResult.OK)
            {
                if (txtNome.Text.Length > 3 && txtEndereco.Text.Length>3)
                {
                    Cliente usuario = new Cliente();
                    usuario.Nome = txtNome.Text;
                    usuario.Endereco = txtEndereco.Text;
                    usuario.Telefone = txtTelefone.Text;
                    usuario.Salvar();
                    txtTelefone.Clear();
                    txtNome.Clear();
                    txtEndereco.Clear();
                }
                else
                {
                    MessageBox.Show("Os campo nome, endereço ou telefone esta vazio ou insuficiente", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {//imprimir pedido

            bool verdade;
            if (checkBox1.Checked == true)
            {
                verdade = true;
                Agendados usuario = new Agendados();
                usuario.Nome = txtNome.Text;
                usuario.Endereco = txtEndereco.Text;
                usuario.Telefone = txtTelefone.Text;
                usuario.Pedido = txtPedido.Text;
                usuario.Data = Convert.ToDateTime(dataTime.Text);
                usuario.Pagamento = txtPagamento.Text;
                usuario.Salvar();
                checkBox1.Checked = false;
            }
            else
            {
                verdade = false;
                Pedidos usuario = new Pedidos();
                usuario.Nome = txtNome.Text;
                usuario.Endereco = txtEndereco.Text;
                usuario.Telefone = txtTelefone.Text;
                usuario.Pedido = txtPedido.Text;
                usuario.Data = Convert.ToDateTime(dataTime.Text);
                usuario.Pagamento = txtPagamento.Text;
                usuario.Salvar();
                checkBox1.Checked = false;
            }
            GerarPdf(verdade);
            txtTelefone.Clear();
            txtNome.Clear();
            txtEndereco.Clear();
            txtPedido.Clear();

            string caminhoDoArquivoPdf = @"c:\dados\pedido.pdf";
            ExibirPdfNoNavegador(caminhoDoArquivoPdf);
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

        private void GerarPdf(bool verdade)
        {
            var arquivo = @"C:\dados\pedido.pdf";
            using (PdfWriter wPdf = new PdfWriter(arquivo, new WriterProperties().SetPdfVersion(PdfVersion.PDF_2_0)))
            {
                if (verdade == true)
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
                    document.Add(new Paragraph(dataTime.Text));

                    document.Close();
                    pdfDocument.Close();
                }
                else
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
                    document.Close();
                    pdfDocument.Close();
                }
                
            }
        }


        private void AnotarPedido_Load(object sender, EventArgs e)
        {
            dataTime.MinDate = DateTime.Today;
            dataTime.Enabled = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked== true)
            {
                dataTime.Enabled = true;
            }
            else
            {
                dataTime.Enabled = false;
            }
        }

        private void txtNome_KeyPress(object sender, KeyPressEventArgs e)
        { // Esse codigo faz com que o txtNome aceite apenas numero
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
