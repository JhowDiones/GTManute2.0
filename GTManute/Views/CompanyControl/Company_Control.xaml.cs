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

namespace GTManute.Views.CompanyControl
{
    /// <summary>
    /// Lógica interna para Company_Control.xaml
    /// </summary>
    public partial class Company_Control : Window
    {
        private class Ultimas
        {
            public string Descrição { get; set; }
            public string Quantidade { get; set; }
            public string Preço_Unit { get; set; }
            public string Total { get; set; }

        }
        public Company_Control()
       
        {

            InitializeComponent();
        }

        private void btn_Fechar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btn_alterar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_gravar_Click(object sender, RoutedEventArgs e)
        {

        }
        private async void CarregarGrid()
        {

        }
    }
}
