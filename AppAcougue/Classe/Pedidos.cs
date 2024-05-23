using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppAcougue.Conexao;
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;

namespace AppAcougue
{
    public class Pedidos
    {
        public int Idpedidos { get; set; }
        public string Pedido { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Pagamento { get; set; }
        public DateTime Data { get; set; }

        public void Salvar()
        {
            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "INSERT INTO `pedidos`(`pedido`,`nome`,`telefone`,`endereco`,`data`,`pagamento`)VALUES(@pedido,@nome,@telefone,@endereco,@data,@pagamento)";
                cmd.Parameters.AddWithValue("@pedido", Pedido);
                cmd.Parameters.AddWithValue("@nome", Nome);
                cmd.Parameters.AddWithValue("@telefone", Telefone);
                cmd.Parameters.AddWithValue("@endereco", Endereco);
                cmd.Parameters.AddWithValue("@data", Data);
                cmd.Parameters.AddWithValue("@pagamento", Pagamento);
                cmd.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel salvar o pedido" + ex.Message);
                //MessageBox.Show("Não foi possivel salvar o pedido", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public static List<Pedidos> CarregarPedido()
        {// Buscar os dados do pedido para ser carregados na grid

            List<Pedidos> pedidos = new List<Pedidos>();

            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM pedidos";
                using (MySqlDataReader reder = cmd.ExecuteReader())
                {
                    while (reder.Read())
                    {
                        Pedidos objeto = new Pedidos();
                        objeto.Idpedidos = reder.GetInt32("idpedidos");
                        objeto.Nome = reder.GetString("nome");
                        objeto.Telefone = reder.GetString("telefone");
                        objeto.Endereco = reder.GetString("endereco");
                        objeto.Data = reder.GetDateTime("data");
                        objeto.Pedido = reder.GetString("pedido");
                        objeto.Pagamento = reder.GetString("pagamento");
                        pedidos.Add(objeto);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar as informaçoes " + ex.Message);
            }
            return pedidos;
        }
        /*public List<Pedidos> DataPedidosDoDia(string data)
        {   //Função para buscar os pedidos baseados na data

            DateTime data2 = Convert.ToDateTime(data);
            List<Pedidos> lista = new List<Pedidos>();

            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM pedidos WHERE data LIKE CONCAT  ('%',@data,'%');";
                cmd.Parameters.AddWithValue("@data", data2);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pedidos objeto = new Pedidos();
                        objeto.Nome = reader.GetString("nome");
                        objeto.Pedido = reader.GetString("pedido");
                        objeto.Telefone = reader.GetString("telefone");
                        objeto.Endereco = reader.GetString("endereco");
                        objeto.Data = reader.GetDateTime("data");
                        objeto.Pagamento = reader.GetString("pagamento");

                        lista.Add(objeto);
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Pedido não localizado" + ex.Message);
            }
            return lista;
        }*/
        public static List<Pedidos> Carregar()
        {//Função para carregar os dados de pedidos

            List<Pedidos> registros = new List<Pedidos>();

            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM acougue.pedidos;";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pedidos objeto = new Pedidos();
                        objeto.Idpedidos = reader.GetInt32("idpedidos");
                        objeto.Nome = reader.GetString("nome");
                        objeto.Endereco = reader.GetString("endereco");
                        objeto.Telefone = reader.GetString("telefone");
                        objeto.Pedido = reader.GetString("pedido");
                        objeto.Pagamento = reader.GetString("pagamento");
                        registros.Add(objeto);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Não foi possivel carregar a grid " + ex.Message);
            }
            return registros;
        }
        public void Deletar(int Idpedido)
        {// Função para deletar os dados do pedido

            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();

                DialogResult cliqueD = MessageBox.Show("Deseja apagar os dados do pedido ?", "Confirmação", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (cliqueD == DialogResult.OK)
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    cmd.CommandText = "DELETE FROM `pedidos` WHERE idpedidos = @idpedidos";
                    cmd.Parameters.AddWithValue("@idpedidos", Idpedido);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Deletado com sucesso!", "Excluir!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("O pedido não foi apagado!", "Dados", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Não localizado" + ex.Message);
            }
        
        }
        public void EditarPedido()
        {
            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE `pedidos` SET `pedido` =@pedidos ,`nome` =@nome ,`endereco` =@endereco ,`telefone` =@telefone, `pagamento`= @pagamento WHERE `idpedidos` = @idpedidos;";
                cmd.Parameters.AddWithValue("@pedidos", Pedido);
                cmd.Parameters.AddWithValue("@nome", Nome);
                cmd.Parameters.AddWithValue("@endereco", Endereco);
                cmd.Parameters.AddWithValue("@telefone", Telefone);
                cmd.Parameters.AddWithValue("@idpedidos", Idpedidos);
                cmd.Parameters.AddWithValue("@pagamento", Pagamento);
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
    }
}

