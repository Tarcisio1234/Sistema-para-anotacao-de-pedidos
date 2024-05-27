using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AppAcougue.Conexao;

namespace AppAcougue
{
    public class Cliente
    {
        public int Idcliente { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public void Salvar()
        {
            MySqlConnectionManager connectionManager = new MySqlConnectionManager();
            MySqlConnection connection = connectionManager.GetConnect();
            connection.Open();
            MySqlCommand cmd = new MySqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = "INSERT INTO `cadastrocliente`(`nome`,`endereco`,`telefone`)VALUES(@nome,@endereco,@telefone);";
            cmd.Parameters.AddWithValue("@nome", Nome);
            cmd.Parameters.AddWithValue("@endereco", Endereco);
            cmd.Parameters.AddWithValue("@telefone", Telefone);
            cmd.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show($"Os dados do cliente {Nome} foram salvos", "Salvo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }
        public List<Cliente> BuscarCliente(string Nome)
        { //Função para buscar os dados do cliente 

            List<Cliente> clientes = new List<Cliente>();

            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM cadastrocliente WHERE nome LIKE CONCAT ('%',@nome,'%');";
                cmd.Parameters.AddWithValue("@nome", Nome);
                using (MySqlDataReader reder = cmd.ExecuteReader())
                {
                    while (reder.Read())
                    {
                        Cliente objeto = new Cliente();
                        objeto.Idcliente = reder.GetInt32("idcliente");
                        objeto.Nome = reder.GetString("nome");
                        objeto.Endereco = reder.GetString("endereco");
                        objeto.Telefone = reder.GetString("telefone");

                        clientes.Add(objeto);
                    }
                }
                connection.Close();
            }
            catch (SystemException ex)
            {
                MessageBox.Show("Os dados do cliente não foram localizado ", ex.Message);
            }
            return clientes;
        }
        public static List<Cliente> CarregarPedido()
        {// Buscar os dados do paciente para ser carregados na grid

            List<Cliente> pedidos = new List<Cliente>();

            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM cadastrocliente";
                using (MySqlDataReader reder = cmd.ExecuteReader())
                {
                    while (reder.Read())
                    {
                        Cliente objeto = new Cliente();
                        objeto.Idcliente = reder.GetInt32("idcliente");
                        objeto.Nome = reder.GetString("nome");
                        objeto.Endereco = reder.GetString("endereco");
                        objeto.Telefone = reder.GetString("telefone");
                        pedidos.Add(objeto);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Erro ao carregar as imformaçoes");
            }
            return pedidos;
        }
        public void EditarCadastroCliente()
        { // editar os dados dos clientes
            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE `cadastrocliente` SET `nome` = @nome, `endereco` = @endereco, `telefone` =@telefone WHERE `idcliente` = @idcliente;";
                cmd.Parameters.AddWithValue("@nome", Nome);
                cmd.Parameters.AddWithValue("@endereco", Endereco);
                cmd.Parameters.AddWithValue("@telefone", Telefone);
                cmd.Parameters.AddWithValue("@idcliente", Idcliente);
                cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("As alterações foram feitas com sucesso", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro" + ex.Message);
            }
        }
        public void DeletarCliente()
        {
            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();

                DialogResult cliqueD = MessageBox.Show("Deseja apagar os dados do cliente ?", "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (cliqueD == DialogResult.OK)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM `cadastrocliente` WHERE idcliente = @idcliente";
                    cmd.Parameters.AddWithValue("@idcliente", Idcliente);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Deletado com sucesso!", "Excluir!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                }
                else
                {
                    MessageBox.Show("O cliente não foi apagado!", "Dados", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Não localizado" + ex.Message);
            }
        }
    }
}
