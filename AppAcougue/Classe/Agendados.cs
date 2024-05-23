using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AppAcougue.Conexao;
using System.Windows.Forms;
using AppAcougue.Visual;

namespace AppAcougue
{
    public class Agendados
    {
        public int Idpedidosagendados { get; set; }
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
                cmd.CommandText = "INSERT INTO `pedidosagendados`(`pedido`,`nome`,`endereco`,`telefone`,`data`,`pagamento`)VALUES(@pedido,@nome,@endereco,@telefone,@data,@pagamento)";
                cmd.Parameters.AddWithValue("@pedido", Pedido);
                cmd.Parameters.AddWithValue("@nome", Nome);
                cmd.Parameters.AddWithValue("@endereco", Endereco);
                cmd.Parameters.AddWithValue("@telefone", Telefone);
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
        public List<Agendados> DataPedidos(string data)
        {   //Função para buscar os pedidos baseados na data

            DateTime data2 = Convert.ToDateTime(data);
            List<Agendados> lista = new List<Agendados>();

            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM pedidosagendados WHERE data LIKE CONCAT  ('%',@data,'%');";
                cmd.Parameters.AddWithValue("@data", data2);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Agendados objeto = new Agendados();
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
        }
        public static List<Agendados> Carregar2()
        {//Função para carregar os dados de pedidos

            List<Agendados> registros = new List<Agendados>();

            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();

                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "SELECT * FROM pedidosagendados";
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Agendados objeto = new Agendados();
                        objeto.Idpedidosagendados = reader.GetInt32("idpedidosagendados");
                        objeto.Nome = reader.GetString("nome");
                        objeto.Endereco = reader.GetString("endereco");
                        objeto.Telefone = reader.GetString("telefone");
                        objeto.Pedido = reader.GetString("pedido");
                        objeto.Data = reader.GetDateTime("data");
                        objeto.Pagamento = reader.GetString("pagamento");
                        registros.Add(objeto);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Não foi possivel carregar a grid"+ex.Message);
            }
            return registros;
        }
        public void Deletar(int Idpedido)
        {// Função para deletar os dados do profissional

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
                    cmd.CommandText = "DELETE FROM `pedidosagendados` WHERE idpedidosagendados = @idpedidosagendados";
                    cmd.Parameters.AddWithValue("@idpedidosagendados", Idpedido);
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
        public void AtualizarPedidoAgendado()
        { // editar os dados dos pedidos
            try
            {
                MySqlConnectionManager connectionManager = new MySqlConnectionManager();
                MySqlConnection connection = connectionManager.GetConnect();
                connection.Open();
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = connection;
                cmd.CommandText = "UPDATE `pedidosagendados` SET `pedido` = @pedido ,`nome` = @nome,`endereco` = @endereco ,`telefone` = @telefone ,`data` =@data,`pagamento` =@pagamento  WHERE `idpedidosagendados` = @idpedidosagendados ;";
                cmd.Parameters.AddWithValue("@pedido", Pedido);
                cmd.Parameters.AddWithValue("@nome", Nome);
                cmd.Parameters.AddWithValue("@endereco", Endereco);
                cmd.Parameters.AddWithValue("@telefone", Telefone);
                cmd.Parameters.AddWithValue("@data", Data);
                cmd.Parameters.AddWithValue("@idpedidosagendados", Idpedidosagendados);
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
