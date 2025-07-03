using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Media;
using MySql.Data.MySqlClient;

namespace WPF_MiniTCC_Smartir.Classes
{
    internal class Comandos
    {
        public static string NomeLaboratorio { get; private set; }
        public static string EspId { get; private set; }
        public static string EstadoEsp { get; private set; }
        public static string TempLab { get; private set; }

        public static void AtualizarDados(string nomeLaboratorio, string espId, string estadoEsp) // adicione as variaveis os valores referentes ao lab clicado
        {
            NomeLaboratorio = nomeLaboratorio;
            EspId = espId;
            EstadoEsp = estadoEsp;

        }

        public static void AdicionarComando(int idEsp32, string tipoComando, string valorComando) // função para facilitar o inserimento do comando feito no banco de dados
        {
            using (MySqlConnection connection = connectionfactory.GetConnection())
            {

                string query = @"
            INSERT INTO Comando (ID_ESP32, Tipo_Comando, Valor_Comando, Data_Hora_Envio)
            VALUES (@ID_ESP32, @Tipo_Comando, @Valor_Comando, NOW())";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID_ESP32", idEsp32);
                    cmd.Parameters.AddWithValue("@Tipo_Comando", tipoComando);
                    cmd.Parameters.AddWithValue("@Valor_Comando", valorComando);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string ObterEstadoEsp(string espId) // Função que verifica no banco o status do esp p/ realizar a configuração da interface
        {
            string estado = "Indefinido"; // Valor padrão

            using (MySqlConnection connection = connectionfactory.GetConnection())
            {
                string query = "SELECT Estado FROM ESP32 WHERE ID_ESP32 = @ID";
                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@ID", espId);
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        estado = result.ToString();
                    }
                }
            }

            return estado;
        }

        public bool GridVisible = false; // Estado inicial do grid

        public void ConfigurarInterface(Grid grid, Button btnLigar) // Configura a interface, a visibilidasde do grid e os botões de acordo com o status do esp
        {
            // Obtém o estado do ESP
            string estadoEsp = ObterEstadoEsp(EspId);

            // Ajusta a interface com base no estado
            if (estadoEsp == "online")
            {
                grid.Visibility = Visibility.Visible;
                btnLigar.Visibility = Visibility.Visible;
                btnLigar.Content = "Off";
                btnLigar.Background = new SolidColorBrush(Colors.Red);
            }
            else if (estadoEsp == "offline")
            {
                grid.Visibility = Visibility.Collapsed;
                btnLigar.Visibility = Visibility.Visible;
                btnLigar.Content = "On";
                btnLigar.Background = new SolidColorBrush(Colors.Green);
            }
            else // Estado "Indefinido"
            {
                grid.Visibility = Visibility.Collapsed;
                btnLigar.Visibility = Visibility.Collapsed;
            }
        }

        public static void AumentarTemperatura()
        {
            MessageBox.Show( NomeLaboratorio + EspId + EstadoEsp);
        }

    }
}
