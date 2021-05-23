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

namespace GTManute.Views.Lançamento
{
    /// <summary>
    /// Lógica interna para View_Abast.xaml
    /// </summary>
    public partial class View_Abast : Window
    {
        public View_Abast()
        {
            InitializeComponent();
        }

        private void txt_pes_datapartida_GotFocus(object sender, RoutedEventArgs e)
        {
            if(txt_pes_datapartida.Text=="Data partida")
            {
                txt_pes_datapartida.Text = "";
            }
        }

        private void txt_pes_datachegada_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_pes_datachegada.Text == "Data chegada")
            {
                txt_pes_datachegada.Text = "";
            }
        }

        private void txt_pes_veiculo_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_pes_veiculo.Text == "Veículo")
            {
                txt_pes_veiculo.Text = "";
            }
        }

        private void txt_pes_motorista_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_pes_motorista.Text == "Motorista")
            {
                txt_pes_motorista.Text = "";
            }
        }

        private void txt_pes_Locpartida_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_pes_Locpartida.Text == "Local partida")
            {
                txt_pes_Locpartida.Text = "";
            }
        }

        private void txt_pes_locdestino_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_pes_locdestino.Text == "Local destino")
            {
                txt_pes_locdestino.Text = "";
            }
        }

        private void txt_pes_forncedor_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_pes_fornecedor.Text == "Fornecedor")
            {
                txt_pes_fornecedor.Text = "";
            }
        }

        private void txt_pes_datapartida_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_pes_datapartida.Text == "")
            {
                txt_pes_fornecedor.Text = "Data partida";
            }
        }

        private void txt_pes_datachegada_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_pes_datachegada.Text == "")
            {
                txt_pes_datachegada.Text = "Data chegada";
            }
        }

        private void txt_pes_veiculo_LostFocus(object sender, RoutedEventArgs e)
        {

            if (txt_pes_veiculo.Text == "")
            {
                txt_pes_veiculo.Text = "Veículo";
            }
        }

        private void txt_pes_motorista_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_pes_motorista.Text == "")
            {
                txt_pes_motorista.Text = "Motorista";
            }
        }

        private void txt_pes_Locpartida_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_pes_Locpartida.Text == "")
            {
                txt_pes_Locpartida.Text = "Local partida";
            }
        }

        private void txt_pes_locdestino_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_pes_locdestino.Text == "")
            {
                txt_pes_locdestino.Text = "Local destino";
            }
        }

        private void txt_pes_fornecedor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_pes_fornecedor.Text == "")
            {
                txt_pes_fornecedor.Text = "Fornecedor";
            }
        }
    }
}
