﻿using dbAcessos;
using GTManute.Properties;
using dbAcessos.Properties;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Configuration;

namespace GTManute.Views
{
    /// <summary>
    /// Lógica interna para view_Banco.xaml
    /// </summary>
    public partial class View_Banco : Window
    {
        private GTManute.Properties.Settings cfg = new Properties.Settings();
        private dbAcessos.Properties.Settings cfgdb = new dbAcessos.Properties.Settings();
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext("");
        public View_Banco()
        {
            InitializeComponent();
        }
        private async void txt_servidor_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_empresa.Text == "")
            {
                txt_empresa.Text = "Empresa";
            }
            try
            {
                int usuario = await Task.FromResult<int>((int)db.db_empresas.Where(a => a.Empresa == int.Parse(txt_empresa.Text)).Select(a => a.Empresa).First());
                txt_empresa.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF747171"));
            }
            catch
            {
                txt_empresa.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
        private void txt_senha_GotFocus_1(object sender, RoutedEventArgs e)
        {
            if (txt_senha.Text == "Contra senha")
            {
                txt_senha.Text = "";
            }
        }
        private async void txt_senha_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_senha.Text == "")
                {
                    txt_senha.Text = "Contra senha";
                }
                if (txt_empresa.Text != "Contra senha" && txt_senha.Text != "" && txt_empresa.Text != "Empresa")
                {
                    var data = await Task.FromResult<db_empresas>(db.db_empresas.Where(a => a.Empresa == int.Parse(txt_empresa.Text)).Where(a => a.ContraSenha == txt_senha.Text).FirstOrDefault());
                    txt_licenca.Content = "Vencimento da Licença: " + data.Validade.ToString();
                }
            }
            catch
            {

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

        private async void textBlock3_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

            AlterarBD();
            if (txt_empresa.Text == "" && txt_empresa.Foreground == new SolidColorBrush(Colors.Red) && txt_senha.Text == "")
            {

            }
            else
            {
                try
                {
                    db_empresas resultado = await Task.FromResult<db_empresas>(db.db_empresas.Where(a => a.ContraSenha == txt_senha.Text).Where(a => a.Empresa == int.Parse(txt_empresa.Text)).First());
                    if (resultado.Empresa == int.Parse(txt_empresa.Text))
                    {
                        cfgdb.empresa = txt_empresa.Text;
                        cfg.Save();
                        this.Close();
                    }
                    else
                    {
                        mensagem("", false, "", "Ok");
                    }
                }
                catch
                {
                }
                if (txt_empresa.Foreground == new SolidColorBrush(Colors.Red))
                {
                    mensagem("Codigo da empresa incorreto!", false, "", "Ok");
                    txt_empresa.Focus();
                }
                else
                {
                    mensagem("Senha incorreta!", false, "", "Ok");
                }
            }
        }
        private void mensagem(string principal, bool explica, string explicacao, string botao)
        {
            Mensagem mensagem = new Mensagem(principal, explica, explicacao, botao);
            mensagem.ShowDialog();
        }

        private async void AlterarBD()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringsSection = (ConnectionStringsSection)config.GetSection("conexao");
            connectionStringsSection.ConnectionStrings["Connection"].ConnectionString = "Data Source="+txt_dataSouce.Text+";Initial Catalog="+txt_catalogo.Text+";UID="+txt_Usúario.Text+ ";password=" + txt_senhabanco.Text ;
            config.Save();
            ConfigurationManager.RefreshSection("conexao");
        }

        private void txt_empresa_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_empresa.Text == "Empresa")
            {
                txt_empresa.Text = "";
            }
        }

        private void btn_Fechar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
