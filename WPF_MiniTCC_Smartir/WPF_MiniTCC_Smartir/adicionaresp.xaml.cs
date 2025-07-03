﻿using System;
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
    /// Lógica interna para adicionaresp.xaml
    /// </summary>
    public partial class adicionaresp : Window
    {
        public adicionaresp()
        {
            InitializeComponent();
        }

        //Função de limpar os campos
        public void limpar()
        {
            txtid.Clear();
            txtip.Clear();
        }

        //Botão para cadastrar o ESP32
        private void btncadastrar_Click(object sender, RoutedEventArgs e)
        {

            string idESP = txtid.Text;
            if (txtid.Text != "" && txtip.Text != "") // Verifica se as caixas estão vazias
            {
                if (EspDAO.verificarIdEsp(idESP)) // Verifica se já existe um ID semelhante
                {
                    CustomMessageBox.Show("Um Esp32 já possui esse ID, altere por outro", "Erro: ID Existente");
                }

                else // Não possui um ID semelhante
                {                
                    Esp32 cadastroesp = new Esp32(Convert.ToInt32(txtid.Text), txtip.Text, "offline");
                    EspDAO.cadastroesp(cadastroesp);
                    CustomMessageBox.Show("Novo Esp32 cadastrado com sucesso!", "Aviso: Cadastro Concluído");
                    limpar();
                }
            }

            else // Caixas vazias
            {
                CustomMessageBox.Show("As credenciais não podem estar vazias!", "Erro: Credenciais Inválidas");
                limpar();
                txtid.Focus();
            }
        
        }

        //Botão para voltar ao painel
        private void VoltarBtn_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Painel painel = new Painel();
            painel.Show();
            this.Close();
        }

        private void IdTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Permitir apenas letras
            e.Handled = !Regex.IsMatch(e.Text, @"^\d{0,3}$");
        }

    }
}
