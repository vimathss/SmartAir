using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static WPF_MiniTCC_Smartir.Painel;

namespace WPF_MiniTCC_Smartir.Classes
{
    internal class LabDAO
    {
        //função para cadastrar lab
        public static void cadastrolab(Lab cadastrolab)
        {
            //abre a conexão
            using (MySqlConnection connection = connectionfactory.GetConnection())
            {
                //comando insert para o banco de dados
                string insert = "INSERT INTO Lab Values (@ID_Lab, @Nome, @Localizacao, @Descricao)";

                //criação do comando insert
                MySqlCommand commandindert = new MySqlCommand(insert, connection);

                commandindert.Parameters.AddWithValue("@ID_Lab", cadastrolab.Idlab);
                commandindert.Parameters.AddWithValue("@Nome", cadastrolab.Nome);
                commandindert.Parameters.AddWithValue("@Localizacao", cadastrolab.Localizacao);
                commandindert.Parameters.AddWithValue("@Descricao", cadastrolab.Descricao);

                //execução do comando
                commandindert.ExecuteNonQuery();

                //fim da conexão
                connection.Close();
            }
        }

        public static List<Laboratorio> BuscarLaboratorios()
        {
            var laboratorios = new List<Laboratorio>();

            using (MySqlConnection connection = connectionfactory.GetConnection())
            {
                string query = @"SELECT l.ID_Lab, l.Nome, l.Localizacao, l.Descricao, e.ID_ESP32, e.Endereço_IP, e.Estado 
                         FROM Lab l 
                         LEFT JOIN ESP32 e ON l.ID_Lab = e.ID_Lab";

                MySqlCommand command = new MySqlCommand(query, connection);

                // Executa a consulta e lê os resultados
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Verifica se o laboratório já foi adicionado à lista
                        var laboratorioExistente = laboratorios.FirstOrDefault(l => l.Id == reader.GetInt32("ID_Lab"));

                        if (laboratorioExistente == null)
                        {
                            // Se o laboratório ainda não existe na lista, adiciona-o
                            var laboratorio = new Laboratorio
                            {
                                Id = reader.GetInt32("ID_Lab"),
                                Nome = reader.GetString("Nome"),
                                Localizacao = reader.GetString("Localizacao"),
                                Esps = new List<ESP>()
                            };

                            if (!reader.IsDBNull(reader.GetOrdinal("ID_ESP32")))
                            {
                                // Adiciona o ESP se estiver disponível
                                laboratorio.Esps.Add(new ESP
                                {
                                    Id = reader.GetInt32("ID_ESP32"),
                                    Estado = reader.GetString("Estado")
                                });
                            }

                            laboratorios.Add(laboratorio);
                        }
                        else
                        {
                            // Se o laboratório já está na lista, apenas adiciona o ESP
                            if (!reader.IsDBNull(reader.GetOrdinal("ID_ESP32")))
                            {
                                laboratorioExistente.Esps.Add(new ESP
                                {
                                    Id = reader.GetInt32("ID_ESP32"),
                                    Estado = reader.GetString("Estado")
                                });
                            }
                        }
                    }
                }

                connection.Close();
            }

            return laboratorios;
        }
        
        // Função P/ Buscar os Laboratórios Cadastrados
        public static bool verificarLab(string idLAB)
        {
            bool idExistente = false;
            using (MySqlConnection connection = connectionfactory.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Lab WHERE ID_LAB = @ID_LAB";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID_LAB", idLAB);
                    // Executa o comando e verifica se o resultado é maior que 0 (ou seja, o ID já existe)
                    int resultado = Convert.ToInt32(cmd.ExecuteScalar());
                    idExistente = resultado > 0;
                }
                connection.Close();
            }
            return idExistente;
        }
    }
}
