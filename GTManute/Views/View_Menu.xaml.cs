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
using dbAcessos.Properties;
using GTManute.Properties;
using GTManute.Views.Cadastro;
using GTManute.Views.CompanyControl;
using GTManute.Views.Lançamento;
using Microsoft.Reporting.WinForms;

namespace GTManute.Views
{
    /// <summary>
    /// Lógica interna para View_Menu.xaml
    /// </summary>
    public partial class View_Menu : Window
    {
        private string Usuario { get; set; }
        private GTManute.Properties.Settings cfg = new Properties.Settings();
        private dbAcessos.Properties.Settings cfgdb = new dbAcessos.Properties.Settings();
        private int ID { get; set; }
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext("");
        public View_Menu(bool validade,string data)
        {
            InitializeComponent();
            db = new dbManuteDataContext(cfgdb.conexao);
            txt_validade.Content = data;
            txt_empresa.Content = cfgdb.NomeEmpresa;
           Empresa = cfgdb.empresa;
            if (validade == false)
            {
                btn_cadastro.IsEnabled = false;
                btn_Lanca.IsEnabled = false;
                btn_home.IsEnabled = false;
            }
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

        private void Rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            CompanyControl.Control_Acesso acesso = new Control_Acesso();
            acesso.ShowDialog();
        }

        private void Grid_MouseLeftButtonDown_4(object sender, MouseButtonEventArgs e)
        {
            View_Rotas acesso = new View_Rotas();
            acesso.ShowDialog();
        }

        private async void ReportViewer_Load(object sender, EventArgs e)
        {
            string mesatual = DateTime.Now.ToShortDateString();
            string dias = DateTime.Now.Day.ToString("#0");
           mesatual= mesatual.Replace(dias, "");
            var dadosRelatorio = new List<db_abast>();
            dadosRelatorio = await Task.FromResult<List<db_abast>>(db.db_abast.Where(a => a.Empresa == Empresa).Where(a=>a.DT_CHEGADA.Contains(mesatual)).ToList()) ;
            
            Rel_Abast.LocalReport.DataSources.Clear();
            var dataSource = new ReportDataSource("DataSet1", dadosRelatorio);
            Rel_Abast.LocalReport.DataSources.Add(dataSource);
            Rel_Abast.LocalReport.ReportEmbeddedResource = "GTManute.Relatorios.Rel_Home_Abast.rdlc";

            Rel_Abast.RefreshReport();
        }
    }
}
