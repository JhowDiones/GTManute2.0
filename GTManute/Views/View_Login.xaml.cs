using dbAcessos;
using GTManute.Properties;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
namespace GTManute.Views
{
    /// <summary>
    /// Lógica interna para View_Login.xaml
    /// </summary>
    public partial class View_Login : Window
    {
        private Settings cfg = new Settings();
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext();
       
        public View_Login()
        {
            InitializeComponent();
            Empresa = cfg.Empresa;
            if (Empresa == null || Empresa == "")
            {
                Mensagem("Empresa não configurada!",false,"","Ok!");
            }
        }

        private void txt_usuario_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_usuario.Text = "";
        }

        private async void txt_usuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_usuario.Text == "")
            {
                txt_usuario.Text = "Usuário";
            }
            else
            {
                try
                {
                    string usuario = db.db_login.Where(a => a.USUARIO == txt_usuario.Text).Where(a => a.Empresa == Empresa).Select(a => a.USUARIO).First();
                    txt_usuario.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF747171"));
                }
                catch
                {
                    txt_usuario.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void txt_senha_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_senha.Text = "";
        }

        private void txt_senha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_senha.Text == "")
            {
                txt_senha.Text = "Senha";
            }
            else
            {
                try
                {
                    string senha = db.db_login.Where(a => a.Empresa == Empresa).Where(a => a.SENHA == txt_senha.Text).Select(a => a.SENHA).First();
                    txt_senha.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF747171"));

                }
                catch
                {
                    txt_senha.Foreground = new SolidColorBrush(Colors.Red);
                }
            }
        }

        private void txt_Novo_Usuario_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_Novo_Usuario.Text = "";
        }

        private async void txt_Novo_Usuario_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Novo_Usuario.Text == "")
            {
                txt_Novo_Usuario.Text = "Usuário";
            }
            else
            {
                try
                {
                    string senha = db.db_login.Where(a => a.Empresa == Empresa).Where(a => a.USUARIO == txt_Novo_Usuario.Text).Select(a => a.USUARIO).First();


                    txt_Novo_Usuario.Foreground = new SolidColorBrush(Colors.Red);
                    MessageBox.Show("Usuário já cadastrado!", "Cadastro de Usuário");

                }
                catch
                {
                    txt_Novo_Usuario.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF747171"));
                }
            }
        }

        private void txt_Novo_Senha_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_Novo_Senha.Text = "";
        }

        private void txt_Novo_Senha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Novo_Senha.Text == "")
            {
                txt_Novo_Senha.Text = "Senha";
            }
        }

        private void txt_Novo_ConfirmaSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            txt_Novo_ConfirmaSenha.Text = "";
        }

        private void txt_Novo_ConfirmaSenha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Novo_ConfirmaSenha.Text == "")
            {
                txt_Novo_ConfirmaSenha.Text = "Confirmar senha";
            }
        }

        private void btn_Fechar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void btn_entrar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // var usuarios= db.db_login.Where()
        }

        private void textBlock3_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (txt_Novo_ConfirmaSenha.Text != "" && txt_Novo_ConfirmaSenha.Text != null &&
                txt_Novo_Senha.Text != "" && txt_Novo_Senha.Text != null &&
                txt_Novo_Usuario.Text != "" && txt_Novo_Usuario.Text != null && txt_Novo_Usuario.Foreground != new SolidColorBrush(Colors.Red))
            {

            }
        }
        private void Mensagem(string principal, bool explica, string explicacao, string botao)
        {
            Mensagem mensagem = new Mensagem(principal,explica,explicacao,botao);
             mensagem.ShowDialog();
        }
    }
}
