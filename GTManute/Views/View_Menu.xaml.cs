using dbAcessos;
using GTManute.Views.Cadastro;
using GTManute.Views.CompanyControl;
using GTManute.Views.Lançamento;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace GTManute.Views
{
    /// <summary>
    /// Lógica interna para View_Menu.xaml
    /// </summary>
    public partial class View_Menu : Window
    {
        private string VersaoPrograma = "1.0.0.8";
        private string Usuario { get; set; }
        Addons addons = new Addons();
        List<db_manu> pecaslista = new List<db_manu>();
        List<db_manu_log> manut = new List<db_manu_log>();
        private GTManute.Properties.Settings cfg = new Properties.Settings();
        private dbAcessos.Properties.Settings cfgdb = new dbAcessos.Properties.Settings();
        private int ID { get; set; }
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext("");
        public View_Menu(bool validade, string data)
        {
            InitializeComponent();
            db = new dbManuteDataContext(addons.NC);
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
        private void Atualizar()
        {
            string version = new WebClient().DownloadString("https://pastebin.com/raw/69a43Jdw");
            string Importante = new WebClient().DownloadString("https://pastebin.com/raw/f5Cb29qQ");


            if (VersaoPrograma != version)
            {
                btn_atualizar.Visibility = Visibility.Visible;
                if (Importante == "Sim")
                {
                    mensagem("Atualização obrigatória! O GTManute estará disponivel para ultilização logo após a atualização!!!", false, "", "OK");

                    try
                    {
                        System.Diagnostics.Process.Start("C:\\GTManute\\UpGTManute.exe");
                        this.Close();
                    }
                    catch
                    {

                    }
                }
                else
                {
                    mensagem("Existem atualizações pendentes!", false, "", "OK");
                }

            }

        }
        private void mensagem(string principal, bool explica, string explicacao, string botao)
        {
            Mensagem mensagem = new Mensagem(principal, explica, explicacao, botao);
            mensagem.ShowDialog();
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
        private void Grid_MouseLeftButtonDown_5(object sender, MouseButtonEventArgs e)
        {
            View_Manut acesso = new View_Manut();
            acesso.ShowDialog();
        }

        private void btn_atualizar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("C:\\GTManute\\UpGTManute.exe");
                this.Close();
            }
            catch
            {

            }

        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            Atualizar();
        }
       
        private async void btn_upvalores_Click(object sender, RoutedEventArgs e)
        {
            pecaslista = new List<db_manu>(); //await Task.FromResult<List<db_manu>>(db.db_manu.Where(a => a.Empresa == Empresa).ToList());
            manut = await Task.FromResult<List<db_manu_log>>(db.db_manu_log.Where(a => a.Empresa == Empresa).ToList());


            for (int i = 0; i < manut.Count; i++)
            {
                try
                {
                    db_manu db_Manu = new db_manu();
                    if (manut[i].Desconto != "" && manut[i].Desconto != null)
                    {
                       db_Manu = new db_manu();
                        db_Manu = await Task.FromResult(db.db_manu.Where(a => a.Empresa == Empresa).Where(a=>a.NR_LANCA==manut[i].NR_NF).FirstOrDefault());
                        db_Manu.DESCONTO = manut[i].Desconto.Replace("R$ ","");
                        pecaslista.Add(db_Manu);
                    }
                    
                }
                catch
                {

                }


            }
            String retorno = MessageBox.Show("Alterar manutenções?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
            if (retorno == "Yes")
            {
                await Task.Run(() =>
                {
                    try
                    {



                        db.SubmitChanges();
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            mensagem("Manutenção alterada com sucesso!", false, "", "Ok");

                        });
                    }
                    catch
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            mensagem("Tivemos algum erro ao alterar o abastecimento! Revise os campos e tente novamente! \n Caso persista entre em contato com: " + cfg.Email_Dev, false, "", "Ok");
                        });
                    }
                });
            }
            else
            {

            }
        }
    }
}
