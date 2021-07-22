using dbAcessos;
using dbAcessos.Properties;
using GTManute.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
        private string Usuario { get; set; }
        private GTManute.Properties.Settings cfg = new Properties.Settings();
        private dbAcessos.Properties.Settings cfgdb = new dbAcessos.Properties.Settings();
        private int ID { get; set; }
        List<db_empresas> Listpesquisa = new List<db_empresas>();
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext("");
        public Company_Control()

        {

            InitializeComponent();
            db = new dbManuteDataContext(cfgdb.conexao);
            CarregarGrid();
        }

        private void btn_Fechar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private async void btn_alterar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db_empresas empresa = await Task.FromResult<db_empresas>(db.db_empresas.Where(a => a.Empresa == int.Parse(txt_Cod_empresa.Text)).FirstOrDefault());
                empresa.ContraSenha = txt_senha.Text;
                empresa.Validade = txt_validade.SelectedDate;
                empresa.Empresa = int.Parse(txt_Cod_empresa.Text);
                empresa.NomeEmpresa = txt_empresa.Text;
                db.SubmitChanges();
                mensagem("Alterado com sucesso!", false, "", "Ok");
            }
            catch
            {
                mensagem("Erro ao alterar empresa!", false, "", "Ok");
            }

        }
        private void dt_pesquisa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dataGrid.SelectedItem;
                string ID = (dataGrid.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                db_empresas empresa = new db_empresas();
                empresa = db.db_empresas.Where(a => a.Empresa == int.Parse(ID)).FirstOrDefault();
                preecher(empresa.Empresa, empresa.NomeEmpresa, empresa.ContraSenha, empresa.Validade);

            }
            catch
            {

            }
        }
        private void btn_gravar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                db_empresas empresa = new db_empresas();
                empresa.Empresa = int.Parse(txt_Cod_empresa.Text);
                empresa.ContraSenha = txt_senha.Text;
                empresa.Validade = txt_validade.SelectedDate;
                empresa.DataCadastro = DateTime.Now;
                empresa.NomeEmpresa = txt_empresa.Text;

                db.db_empresas.InsertOnSubmit(empresa);
                db.SubmitChanges();
                mensagem("Gravado com sucesso!", false, "", "Ok");
            }
            catch(Exception w)
            {
                mensagem("Erro ao gravar! "+w.Message, false, "", "Ok");
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
        private async void CarregarGrid()
        {
            Listpesquisa = db.db_empresas.ToList();

            dataGrid.ItemsSource = Listpesquisa;
            preecher(Listpesquisa[0].Empresa, Listpesquisa[0].NomeEmpresa, Listpesquisa[0].ContraSenha, Listpesquisa[0].Validade);

        }
        private void preecher(int? codempresa, string empresa, string senha, DateTime? validade)
        {
            txt_Cod_empresa.Text = codempresa.ToString();
            txt_empresa.Text = empresa;
            txt_senha.Text = senha;
            txt_validade.SelectedDate = validade;
        }
        private void mensagem(string principal, bool explica, string explicacao, string botao)
        {
            Mensagem mensagem = new Mensagem(principal, explica, explicacao, botao);
            mensagem.ShowDialog();
        }

        private void btn_config_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
