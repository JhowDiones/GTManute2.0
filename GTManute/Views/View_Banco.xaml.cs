using dbAcessos;
using GTManute.Properties;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace GTManute.Views
{
    /// <summary>
    /// Lógica interna para view_Banco.xaml
    /// </summary>
    public partial class View_Banco : Window
    {
        private Settings cfg = new Settings();
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext();
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
            try
            {
                int usuario = (int)db.db_empresas.Where(a => a.Empresa == int.Parse(txt_empresa.Text)).Select(a => a.Empresa).First();
                txt_empresa.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF747171"));
            }
            catch
            {
                txt_empresa.Foreground = new SolidColorBrush(Colors.Red);
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

        private void textBlock3_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (txt_empresa.Text == "" && txt_empresa.Foreground == new SolidColorBrush(Colors.Red) && txt_senha.Text == "")
            {
               
            }
            else
            {
                try
                {
                    var resultado = db.db_empresas.Where(a => a.ContraSenha == txt_senha.Text).Where(a => a.Empresa == int.Parse(txt_empresa.Text)).First();
                    if(resultado.)
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
    }
}
