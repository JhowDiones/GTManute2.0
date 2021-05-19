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
    /// Lógica interna para view_Banco.xaml
    /// </summary>
    public partial class View_Banco : Window
    {
        public View_Banco()
        {
            InitializeComponent();
        }

        private void txt_usuario_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_empresa.Text = "";
        }

        private void txt_servidor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_empresa.Text == "")
            {
                txt_empresa.Text = "Servidor";
            }
        }

        private void txt_senha_GotFocus_1(object sender, RoutedEventArgs e)
        {
            txt_senha.Text = "";
        }

        private void txt_senha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_senha.Text == "")
            {
                txt_senha.Text = "Servidor";
            }
        }
    }
}
