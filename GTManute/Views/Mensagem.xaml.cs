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
    /// Lógica interna para Mensagem.xaml
    /// </summary>
    public partial class Mensagem : Window
    {
        public Mensagem(string principal, bool explica, string explicacao, string botao)
        {
            InitializeComponent();
            if (explica == true)
            {
                txt_principal.Text = principal;
                txt_secundaria.Text = explicacao;
                grid_explica.Visibility = Visibility.Visible;
                btn_ok.Content = botao;
                btn_ok_segundo.Text = botao;
            }
            else
            {
                txt_principal.Text = principal;
                txt_secundaria.Text = explicacao;
                grid_explica.Visibility = Visibility.Hidden;
                btn_ok.Content = botao;
                btn_ok_segundo.Text = botao;
            }
        }
        private void btn_ok1()
        {
            this.Close();
        }
       
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private void btn_ok_segundo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            btn_ok1();
        }
    }
}
