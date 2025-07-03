using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WPF_MiniTCC_Smartir.Classes;

namespace WPF_MiniTCC_Smartir
{
    /// <summary>
    /// Lógica interna para UpdateEsp.xaml
    /// </summary>
    public partial class UpdateEsp : Window
    {

        private string _espId;

        public UpdateEsp(string espId)
        {
            InitializeComponent();
            _espId = espId;

        }


        private void VoltarBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
 
            this.Close();
        } // fechar pagina

        private void IdTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Permitir apenas numeros
            e.Handled = !Regex.IsMatch(e.Text, @"^\d{0,3}$");
        } // permitir apenas numeros

        private void AtualizarEsp(object sender, MouseButtonEventArgs e) // função para atualizar o id de lab relacionado com o esp
        {
            string idLab;
            idLab = txtid.Text;
            if (LabDAO.verificarLab(idLab) && !EspDAO.ExisteEspNoLaboratorio(idLab))
            {
                using (MySqlConnection connection = connectionfactory.GetConnection())
                {
                    string query = "UPDATE ESP32 SET ID_Lab = @ID_Lab WHERE ID_ESP32 = @ID_ESP32";
                    using (MySqlCommand cmdComando = new MySqlCommand(query, connection))
                    {
                        cmdComando.Parameters.AddWithValue("@ID_ESP32", _espId);
                        cmdComando.Parameters.AddWithValue("@ID_Lab", idLab);
                        cmdComando.ExecuteNonQuery();
                    }

                }

                CustomMessageBox.Show("Id atualizado com sucesso!", "Aviso: Atualização Concluída");
                this.Close();
            }

            else if (EspDAO.ExisteEspNoLaboratorio(idLab)){
                CustomMessageBox.Show("Esse lab já esta associado a um Esp!", "Erro: Lab já associado");
            }

            else
            {
                CustomMessageBox.Show("Id de Laboratório Inválido!", "Aviso: ID não Existente");
            }
        }
    }
}
