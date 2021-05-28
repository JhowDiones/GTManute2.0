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
using dbAcessos;

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

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
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

        private async void btn_novo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private async void btn_alterar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private async void btn_delete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void Limpar()
        {
            txt_desp_alimentacao.Text = "";
            txt_desp_pernoite.Text = "";
            txt_doc.Text = "";
            txt_dt_destino.Text = "";
            txt_dt_partida.Text = "";
            txt_hr_destino.Text = "";
            txt_hr_partida.Text = "";
            txt_km_destino.Text = "";
            txt_km_inicial.Text = "";
            txt_litragem.Text = "";
            txt_outras_desp.Text = "";
            txt_res_km.Text = "";
            txt_res_media.Text = "";
            txt_res_unitario.Text = "";
            txt_valor.Text = "";
            grid_ultimas.ItemsSource = null;

        }
        private void preencher(string despAlimentacao, string despPernoite, string doc, string dtdestino, string dtpartida,
            string hrdestino, string hrpartida,string kmdestino, string kmpartida, string litragem, string outrasdesp, string valor,
            List<dbAcessos.db_abast> gridUltimas )
        {
            txt_desp_alimentacao.Text = despAlimentacao;
            txt_desp_pernoite.Text = despPernoite;
            txt_doc.Text = doc;
            txt_dt_destino.Text = dtdestino;
            txt_dt_partida.Text = dtpartida;
            txt_hr_destino.Text = hrdestino;
            txt_hr_partida.Text = hrpartida;
            txt_km_destino.Text = kmdestino;
            txt_km_inicial.Text = kmpartida;
            txt_litragem.Text = litragem;
            txt_outras_desp.Text = outrasdesp;

            double kmrestante = double.Parse(kmdestino) - double.Parse(kmpartida);
            double media = kmrestante/ double.Parse(kmpartida);
            double unitario = double.Parse(valor) / double.Parse(litragem);
            txt_res_km.Text = kmrestante.ToString("N2");
            txt_res_media.Text = media.ToString("N2");
            txt_res_unitario.Text = unitario.ToString("N2");
            txt_valor.Text = valor;
            grid_ultimas.ItemsSource = gridUltimas;
        }
        private async void carregar()
        {
            db_login login = await Task.FromResult<db_login>(db.db_login.Where(a => a.Empresa == Empresa).Where(a => a.SENHA == txt_senha.Text).Where(a => a.USUARIO == txt_usuario.Text).First());

        }
    }
}
