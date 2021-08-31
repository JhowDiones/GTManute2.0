using dbAcessos;
using GTManute.Properties;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace GTManute.Views
{
    /// <summary>
    /// Lógica interna para View_Login.xaml
    /// </summary>
    public partial class View_Login : Window
    {
        private dbAcessos.Properties.Settings cfgdb = new dbAcessos.Properties.Settings();
        private Settings cfg = new Settings();
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext("");
        private bool validade= true;
        private DateTime data;
        public View_Login()
        {
            InitializeComponent();
            db = new dbManuteDataContext(cfgdb.conexao);
            Empresa = cfgdb.empresa;
            Carregar();
            txt_usuario.Focus();

        }
        private async void Carregar()
        {
            
            Empresa = cfgdb.empresa;
            if (Empresa == null || Empresa == "")
            {
                mensagem("Empresa ainda não configurada!", true, "Antes do primeiro acesso, é necessario configurar o arquivo de configurações na pasta do sistema!", "Ok!");
                dbAcessos.banco_controle banco = new dbAcessos.banco_controle();
                banco.ShowDialog();
                this.Close();
                
            }
            else
            {
                try
                {
                    db_empresas _empresas = await Task.FromResult<db_empresas>(db.db_empresas.Where(a => a.Empresa == int.Parse(Empresa)).First());
                    validade = true;
                    data = _empresas.Validade.Value;
                    if (_empresas.Validade < DateTime.Now)
                    {
                        mensagem("Sua chave de licença expirou, o sistema trabalhará de forma limitada.", true, "Entre em contato com " + cfg.Email_Dev + " para solicitar outra chave ou reportar algum problema", "Ok");
                        validade = false;
                    }
                }
                catch
                {
                    validade = false;
                }
            }
        }

        void container_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            ComboBox combo = e.Source as ComboBox;
            TextBox tb = e.Source as TextBox;
            if (tb != null)
            {
                switch (e.Key)
                {
                    case Key.Enter:
                        tb.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                        break;
                    default:
                        break;
                }
            }
            else if (combo != null)
            {
                switch (e.Key)
                {
                    case Key.Enter:
                        TraversalRequest next = new TraversalRequest(FocusNavigationDirection.Next);
                        UIElement el = Keyboard.FocusedElement as UIElement;
                        el.MoveFocus(next);
                        break;
                    default:
                        break;
                }
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

        private void txt_usuario_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_usuario.Text == "Usuário")
            {
                txt_usuario.Text = "";
            }

        }
        private async void txt_usuario_LostFocus(object sender, RoutedEventArgs e)
        {
            {
                if (txt_usuario.Text == "")
                {
                    txt_usuario.Text = "Usuário";
                }
                else
                {
                    try
                    {
                        string usuario = await Task.FromResult<string>(db.db_login.Where(a => a.Empresa == Empresa).Where(a => a.USUARIO.Equals(txt_usuario.Text)).Select(a => a.USUARIO).First());
                        txt_usuario.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF747171"));
                        txt_usuario.Text = usuario;
                    }
                    catch
                    {
                        txt_usuario.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
            }
        }

        private void txt_senha_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_senha.Password == "********")
            {
                txt_senha.Password = "";
            }

        }

        private async void txt_senha_LostFocus(object sender, RoutedEventArgs e)
        {
            {
                if (txt_senha.Password == "")
                {
                    txt_senha.Password = "********";
                }
                else
                {
                    try
                    {
                        string senha = await Task.FromResult<string>(db.db_login.Where(a => a.Empresa == Empresa).Where(a => a.SENHA.Equals(txt_senha.Password)).Select(a => a.SENHA).First());
                        txt_senha.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF747171"));

                    }
                    catch
                    {
                        txt_senha.Foreground = new SolidColorBrush(Colors.Red);
                    }
                }
            }
        }

        private void txt_Novo_Usuario_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Novo_Usuario.Text == "Usuário")
            {
                txt_Novo_Usuario.Text = "";
            }

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
                    string senha = await Task.FromResult<string>(db.db_login.Where(a => a.Empresa == Empresa).Where(a => a.USUARIO == txt_Novo_Usuario.Text).Select(a => a.USUARIO).First());


                    txt_Novo_Usuario.Foreground = new SolidColorBrush(Colors.Red);
                    mensagem("Usuário já cadastrado!", false, "", "Ok");
                    txt_Novo_Usuario.Text = "";

                }
                catch
                {
                    txt_Novo_Usuario.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FF747171"));
                }
            }
        }

        private void txt_Novo_Senha_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Novo_Senha.Password == "********")
                txt_Novo_Senha.Password = "";
        }

        private void txt_Novo_Senha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Novo_Senha.Password == "")
            {
                txt_Novo_Senha.Password = "********";
            }
        }

        private void txt_Novo_ConfirmaSenha_GotFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Novo_ConfirmaSenha.Password == "********")
                txt_Novo_ConfirmaSenha.Password = "";
        }

        private void txt_Novo_ConfirmaSenha_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txt_Novo_ConfirmaSenha.Password == "")
            {
                txt_Novo_ConfirmaSenha.Password = "********";
            }
        }

        private void btn_Fechar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private async void _btn_entrar()
        {
            if (txt_usuario.Text != "" || txt_senha.ToString() != "" || txt_usuario.Text != null || txt_senha.ToString() != null || txt_usuario.Text != "Usuário" || txt_senha.ToString() != "Senha")
            {
                try
                {
                    Carregar();
                    db_login login = await Task.FromResult<db_login>(db.db_login.Where(a => a.Empresa == Empresa).Where(a => a.SENHA == txt_senha.Password).Where(a => a.USUARIO == txt_usuario.Text).First());

                    View_Menu view_Menu = new View_Menu(validade,data.ToShortDateString());
                    view_Menu.Show();
                    this.Close();

                }
                catch
                {
                    mensagem("Falha ao tentar login, confira o usuário e senha!", true, "Confira os campos, estaram em vermelho os campos com dados incorretos.", "Ok");
                }
            }
        }

        private async void textBlock3_Copy_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (txt_Novo_ConfirmaSenha.Password != "" && txt_Novo_ConfirmaSenha.Password != null &&
                txt_Novo_Senha.Password != "" && txt_Novo_Senha.Password != null && txt_Novo_Usuario.Text != "Usuário" || txt_Novo_Senha.Password != "Senha" ||
                txt_Novo_Usuario.Text != "" && txt_Novo_Usuario.Text != null)
            {
                db_login novologin = new db_login();
                novologin.Empresa = Empresa;
                novologin.SENHA = txt_Novo_Senha.Password;
                novologin.T_acesso = "MASTER";
                novologin.USUARIO = txt_Novo_Usuario.Text;

                await Task.Run(() =>
                {
                    Application.Current.Dispatcher.Invoke((Action)async delegate
                    {
                        try
                        {
                            db.db_login.InsertOnSubmit(novologin);
                            db.SubmitChanges();
                            mensagem("Usuário cadastrado com sucesso!", false, "", "Ok");
                            txt_Novo_ConfirmaSenha.Password = "********";
                            txt_Novo_Senha.Password = "********";
                            txt_Novo_Usuario.Text = "Usuário";
                        }
                        catch
                        {
                            mensagem("Erro ao inserir usuário! Entre em contato com o desenvolvedor \n" + cfg.Email_Dev, false, "", "Ok");
                        }
                    });
                });
            }
        }
        private void mensagem(string principal, bool explica, string explicacao, string botao)
        {
            Mensagem mensagem = new Mensagem(principal, explica, explicacao, botao);
            mensagem.ShowDialog();
        }

        private void btn_config_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
               dbAcessos.banco_controle banco = new dbAcessos.banco_controle();
            banco.ShowDialog();
            this.Close();
        }

        private void btn_entrar_Click(object sender, RoutedEventArgs e)
        {
            _btn_entrar();
        }

        private void image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://api.whatsapp.com/send?phone=+5538988595412&text="+"*Pre-atendimento* = *Empresa:* "+cfgdb.NomeEmpresa + " *Cod:* " + cfgdb.empresa+ " *Programa:* "+"GTManute");
        }
    }
}
