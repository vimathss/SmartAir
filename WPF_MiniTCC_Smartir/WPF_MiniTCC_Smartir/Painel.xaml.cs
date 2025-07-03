using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WPF_MiniTCC_Smartir.Classes;
using static WPF_MiniTCC_Smartir.Painel;

namespace WPF_MiniTCC_Smartir
{
    /// <summary>
    /// Lógica interna para Painel.xaml
    /// </summary>
    public partial class Painel : Window
    {
        private Comandos comandos;
        private EspDAO espDao;

        public Painel()
        {
            InitializeComponent();
            CarregarLaboratorios();
            comandos = new Comandos();
            espDao = new EspDAO();
        }

        public void CarregarLaboratorios() // Inicia e carrega a busca dos laboratorios cadastrados quando a pagina carregar
        {
            var laboratorios = LabDAO.BuscarLaboratorios();
            LaboratoriosList.ItemsSource = laboratorios;
        }

        public class Laboratorio // Classes List dos Labs e Esps Cadastrados
        {
            public int Id { get; set; }
            public string Nome { get; set; }
            public string Localizacao { get; set; }
            public List<ESP> Esps { get; set; }
        }
        public class ESP
        {
            public int Id { get; set; }
            public int LaboratorioId { get; set; }
            public string Estado { get; set; }
        }


        private void icnAddUser_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) //vai para a pagina para adicionar admin
        {
            adicionaradmin adicionaradmin = new adicionaradmin();
            adicionaradmin.Show();
            this.Close();
        }

        private void icnAddLab_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // vai p/ pagina de adicionar lab
        {
            adicionarlab adicionarlab = new adicionarlab();
            adicionarlab.Show();
            this.Close();
        }

        private void icnAddEsp_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // vai p/ pagina de  adicionar esp
        {
            adicionaresp adicionaresp = new adicionaresp();
            adicionaresp.Show();
            this.Close();
        }

        private void LaboratoriosList_SelectionChanged(object sender, SelectionChangedEventArgs e) // Função p/ mostrar o Menu Control com as informações do lab/esp
        {
            // Verifica se um item foi selecionado
            if (LaboratoriosList.SelectedItem != null)
            {
                // Obtém o laboratório selecionado
                var laboratorioSelecionado = (Laboratorio)LaboratoriosList.SelectedItem;

                // Atualiza o conteúdo das Labels com os valores do laboratório selecionado
                lblTitulo.Content = laboratorioSelecionado.Nome;
                lblIdEsp.Content = laboratorioSelecionado.Esps.Count > 0 ? laboratorioSelecionado.Esps[0].Id.ToString() : "Sem ESP";
                lblStatusEsp.Content = laboratorioSelecionado.Esps.Count > 0 ? laboratorioSelecionado.Esps[0].Estado : "Indefinido";
                lblTempLab.Content = "Temperatura: " + "36°C"; // exemplo parado

                
                // Atualizado os dados conforme o lab selecionado
                Comandos.AtualizarDados(laboratorioSelecionado.Nome, laboratorioSelecionado.Esps.Count > 0 ? laboratorioSelecionado.Esps[0].Id.ToString() : "Sem ESP", laboratorioSelecionado.Esps.Count > 0 ? laboratorioSelecionado.Esps[0].Estado : "Indefinido");

                //Configura a grid e o botão, para mostrar ou ocultar a grid e alterar o botão
                comandos.ConfigurarInterface(GridBotões, btnLigar);

                grdMenuControl.Visibility = Visibility.Visible;  // Exibe o grid (define Visibility como Visible)
            }
        }

        private void icnBDAcess_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) // vai p/ pagina do banco de dados e esps
        {
            BDAccesWindow bDAcces = new BDAccesWindow();
            bDAcces.Show();
            this.Close();
        } 

        private void BotaoMostrarGrid_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                string novoEstado = btn.Content.ToString() == "On" ? "online" : "offline"; 
                string idEsp = lblIdEsp.Content.ToString();

                // Atualiza o estado do esp no banco
                espDao.AtualizarEstadoEsp(idEsp, novoEstado, lblStatusEsp);

                // Reconfigura a interface
                comandos.ConfigurarInterface(GridBotões, btnLigar);

                // Recarrega os laboratorios do painel
                CarregarLaboratorios();
            }
        }

        private void AumentarTemp_Click(object sender, RoutedEventArgs e)
        {
            Comandos.AumentarTemperatura();
        }
    }

 

}
