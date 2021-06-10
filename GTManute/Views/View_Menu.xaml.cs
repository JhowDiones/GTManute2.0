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
using GTManute.Properties;
using GTManute.Views.Cadastro;
using GTManute.Views.Lançamento;

namespace GTManute.Views
{
    /// <summary>
    /// Lógica interna para View_Menu.xaml
    /// </summary>
    public partial class View_Menu : Window
    {
        private string Usuario { get; set; }
        private Settings cfg = new Settings();
        private int ID { get; set; }
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext();
        public View_Menu()
        {
            InitializeComponent();
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            try
            {
                this.DragMove();
            }
            catch
            {

            }
            
        }

        private void Home2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom(cfg.TerceiraCor);
            Brush brush1 = (Brush)bc.ConvertFrom(cfg.SegundaCor);
            btn_home.Background = brush1;
            btn_cadastro.Background = brush;
            btn_Lanca.Background = brush1;
            grid_cadastro.Visibility = Visibility.Visible;
            grid_lanc.Visibility = Visibility.Hidden;
        }

        private void btn_Config_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //View_Banco view_Banco = new View_Banco();
           // view_Banco.ShowDialog();
        }

        private void Home3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom(cfg.TerceiraCor);
            Brush brush1 = (Brush)bc.ConvertFrom(cfg.SegundaCor);
            btn_home.Background = brush1;
            btn_cadastro.Background = brush1;
            btn_Lanca.Background = brush;
            grid_cadastro.Visibility = Visibility.Hidden;
            grid_lanc.Visibility = Visibility.Visible;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            View_Frota view_Abast = new View_Frota();
            view_Abast.ShowDialog();
        }

        private void Grid_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            View_CadFornecedores view_Abast = new View_CadFornecedores();
            view_Abast.ShowDialog();
        }

        private void Grid_MouseLeftButtonDown_2(object sender, MouseButtonEventArgs e)
        {
            View_Colaboradores view_Abast = new View_Colaboradores();
            view_Abast.ShowDialog();
        }

        private void Grid_MouseLeftButtonDown_3(object sender, MouseButtonEventArgs e)
        {
            Lançamento.View_Abast view_Abast = new Lançamento.View_Abast();
            view_Abast.ShowDialog();
        }

        private void btn_Fechar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btn_home_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            BrushConverter bc = new BrushConverter();
            Brush brush = (Brush)bc.ConvertFrom(cfg.TerceiraCor);
            Brush brush1 = (Brush)bc.ConvertFrom(cfg.SegundaCor);
            btn_home.Background = brush;
            btn_cadastro.Background = brush1;
            btn_Lanca.Background = brush1;
            grid_cadastro.Visibility = Visibility.Hidden;
            grid_lanc.Visibility = Visibility.Hidden;
        }
    }
}
