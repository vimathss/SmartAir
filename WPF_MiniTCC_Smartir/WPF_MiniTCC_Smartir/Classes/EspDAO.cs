using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using static WPF_MiniTCC_Smartir.BDAccesWindow;

namespace WPF_MiniTCC_Smartir.Classes
{

    public class EspLabModel
    {
        public string ID { get; set; }
        public string Nome { get; set; }
        public string Localizacao { get; set; }
        public string LabId { get; set; }
    }

    internal class EspDAO
    {
        //função para cadastrar lab
        public static void cadastroesp(Esp32 cadastroesp)
        {
            //abre a conexão
            using (MySqlConnection connection = connectionfactory.GetConnection())
            {
                //comando insert para o banco de dados
                string insert = "INSERT INTO ESP32 (ID_ESP32, Endereço_IP, Estado) Values (@ID_ESP32, @Endereço_IP, @Estado)";

                //criação do comando insert
                MySqlCommand commandindert = new MySqlCommand(insert, connection);

                commandindert.Parameters.AddWithValue("@ID_ESP32", cadastroesp.Idesp32);
                commandindert.Parameters.AddWithValue("@Endereço_IP", cadastroesp.Ip);
                commandindert.Parameters.AddWithValue("@Estado", cadastroesp.Estado);

                //execução do comando
                commandindert.ExecuteNonQuery();

                //fim da conexão
                connection.Close();
            }
        }

        public static bool verificarIdEsp(string idESP)
        {
            bool idExistente = false;
            using (MySqlConnection connection = connectionfactory.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM ESP32 WHERE ID_ESP32 = @ID_ESP32";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID_ESP32", idESP);
                    // Executa o comando e verifica se o resultado é maior que 0 (ou seja, o ID já existe)
                    int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                    idExistente = resultado > 0;
                }
                connection.Close();
            }
            return idExistente;
        }

        public static List<EspLabModel> CarregarEspLabData()
        {
            var espLabList = new List<EspLabModel>();

            using (MySqlConnection connection = connectionfactory.GetConnection())
            {
                string query = @"
                SELECT ESP32.ID_ESP32, ESP32.Endereço_IP, ESP32.Estado, Lab.ID_Lab 
                FROM ESP32
                LEFT JOIN Lab ON ESP32.ID_Lab = Lab.ID_Lab";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    espLabList.Add(new EspLabModel
                    {
                        ID = reader["ID_ESP32"].ToString(),
                        Nome = reader["Endereço_IP"].ToString(),
                        LabId = reader["ID_Lab"] != DBNull.Value ? reader["ID_Lab"].ToString() : "Nenhum ID de laboratório associado"
                    });
                }
            }

            return espLabList;
        }

        public static void ExcluirEsp32(string id)
        {
            using (MySqlConnection connection = connectionfactory.GetConnection())
            {
                // Exclua da tabela Comando
                string deleteComandoQuery = "DELETE FROM Comando WHERE ID_ESP32 = @ID";
                using (MySqlCommand cmdComando = new MySqlCommand(deleteComandoQuery, connection))
                {
                    cmdComando.Parameters.AddWithValue("@ID", id);
                    cmdComando.ExecuteNonQuery();
                }

                // Exclua da tabela ESP32
                string deleteEsp32Query = "DELETE FROM ESP32 WHERE ID_ESP32 = @ID";
                using (MySqlCommand cmdEsp32 = new MySqlCommand(deleteEsp32Query, connection))
                {
                    cmdEsp32.Parameters.AddWithValue("@ID", id);
                    cmdEsp32.ExecuteNonQuery();
                }
            }
        }

        public static bool ExisteEspNoLaboratorio(string idLab)
        {
            using (MySqlConnection connection = connectionfactory.GetConnection())
            {

                // Consulta para verificar se o ESP32 está integrado a um laboratório
                string query = "SELECT COUNT(*) FROM ESP32 WHERE ID_Lab = @IDLab";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@IDLab", idLab);

                    // Executa o comando e obtém o resultado
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // Retorna true se encontrar um ESP32 associado a um laboratório
                    return count > 0;
                }
            }
        }

        public void AtualizarEstadoEsp(string espId, string novoEstado, Label lblStatusEsp) // Atualiza o estado do Esp no banco de dados
        {
            using (MySqlConnection connection = connectionfactory.GetConnection())
            {
                string query = "UPDATE ESP32 SET Estado = @Estado WHERE ID_ESP32 = @ID";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Estado", novoEstado);
                    cmd.Parameters.AddWithValue("@ID", espId);
                    cmd.ExecuteNonQuery();
                }
            }

            lblStatusEsp.Content = novoEstado; // atualiza o label do estado do esp com o novo estado do banco

        }

    }


}
