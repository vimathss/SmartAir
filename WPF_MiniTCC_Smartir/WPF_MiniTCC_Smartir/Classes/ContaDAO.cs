using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_MiniTCC_Smartir.Classes
{
    internal class ContaDAO
    {
        //função para cadastrar contas admin
        public static void admincadastro(Conta admincadastrando)
        {
            //abre a conexão
            using (MySqlConnection connection = connectionfactory.GetConnection())
            {
                //comando insert para o banco de dados
                string insert = "INSERT INTO Usuario Values (@Idusuario, @Nome, @Email, @Senha)";

                //criação do comando insert
                MySqlCommand commandindert = new MySqlCommand(insert, connection);

                commandindert.Parameters.AddWithValue("@Idusuario", admincadastrando.Idusuario);
                commandindert.Parameters.AddWithValue("@Nome", admincadastrando.Nome);
                commandindert.Parameters.AddWithValue("@Email", admincadastrando.Email);
                commandindert.Parameters.AddWithValue("@Senha", admincadastrando.Senha);

                //execução do comando
                commandindert.ExecuteNonQuery();

                //fim da conexão
                connection.Close();
            }
        }


        public static bool adminlogar(Conta adminlogando)
        {
            MySqlConnection connection = connectionfactory.GetConnection();
            string query = "SELECT * FROM Usuario WHERE ID_Usuario = @Idusuario AND Senha = @senha";
            MySqlCommand busca = new MySqlCommand(query, connection);

            busca.Parameters.AddWithValue("@Idusuario", adminlogando.Idusuario);
            busca.Parameters.AddWithValue("@senha" , adminlogando.Senha);

            MySqlDataReader reader = busca.ExecuteReader();

            if(reader.HasRows)
            {
                return true;
            }
            else
            {
                return false;
            }


        }

        public static bool verificarAdm(string idADM)
        {
            bool idExistente = false;
            using (MySqlConnection connection = connectionfactory.GetConnection())
            {
                string query = "SELECT COUNT(*) FROM Usuario WHERE ID_Usuario = @ID_Usuario";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID_Usuario", idADM);
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
