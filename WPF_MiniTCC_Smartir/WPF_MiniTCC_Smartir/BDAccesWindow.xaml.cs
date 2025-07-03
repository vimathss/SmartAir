using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
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
    /// Lógica interna para BDAccesWindow.xaml
    /// </summary>
    public partial class BDAccesWindow : Window
    {
        public BDAccesWindow()
        {
            InitializeComponent();
            AtualizarDataGrid();
        }




        private void Excluir_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn && btn.CommandParameter is string id)
            {
                // Mostra a mensagem de confirmação
                var resultado = MessageBox.Show("Deseja realmente excluir o item selecionado?",
                                                 "Confirmar Exclusão", MessageBoxButton.YesNo);

                if (resultado == MessageBoxResult.Yes)
                {
                    try
                    {
                        // Chama o DAO para excluir
                        EspDAO.ExcluirEsp32(id);

                        // Atualiza o DataGrid
                        AtualizarDataGrid();

                        // Mostra mensagem de sucesso
                        CustomMessageBox.Show("Item excluído com sucesso.", "Aviso: Esp32 Deletado");
                    }
                    catch (Exception ex)
                    {
                        // Trata erros e informa ao usuário
                        MessageBox.Show($"Erro ao excluir o item: {ex.Message}", "Erro", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }



        private void Update_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is string espId)
            {
                // Abra a nova janela e passe o ID do ESP como parâmetro
                UpdateEsp updateEspWin = new UpdateEsp(espId);
                updateEspWin.Show();


                updateEspWin.Closed += (s, args) =>
                {
                    // Atualiza o DataGrid quando a janela for fechada
                    AtualizarDataGrid();
                };
            }
        }



        private void dataGridEspLab_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void VoltarBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Painel painel = new Painel();
            painel.Show();
            this.Close();
        }

        public void AtualizarDataGrid()
        {
            // Busca os dados usando o DAO
            List<EspLabModel> espLabList = EspDAO.CarregarEspLabData();

            // Atualiza o DataGrid com a lista retornada
            dataGridEspLab.ItemsSource = espLabList;
        }
    }
}



