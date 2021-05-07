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
using System.Windows.Shapes;

namespace GTManute.Views
{
    /// <summary>
    /// Lógica interna para View_Login.xaml
    /// </summary>
    public partial class View_Login : Window
    {
        public View_Login()
        {
            InitializeComponent();
        }

        private void txt_usuario_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_usuario.Text = "";
        }

        private void txt_usuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_usuario.Text =="")
            {
                txt_usuario.Text = "Usuário";
            }
        }

        private void txt_senha_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_senha.Text = "";
        }

        private void txt_senha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_senha.Text == "")
            {
                txt_senha.Text = "Senha";
            }
        }

        private void txt_Novo_Usuario_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_Novo_Usuario.Text = "";
        }

        private void txt_Novo_Usuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Novo_Usuario.Text == "")
            {
                txt_Novo_Usuario.Text = "Usuário";
            }
        }

        private void txt_Novo_Senha_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_Novo_Senha.Text = "";
        }

        private void txt_Novo_Senha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Novo_Senha.Text == "")
            {
                txt_Novo_Senha.Text = "Senha";
            }
        }

        private void txt_Novo_ConfirmaSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_Novo_ConfirmaSenha.Text = "";
        }

        private void txt_Novo_ConfirmaSenha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Novo_ConfirmaSenha.Text == "")
            {
                txt_Novo_ConfirmaSenha.Text = "Confirmar senha";
            }
        }

        private void btn_Fechar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
