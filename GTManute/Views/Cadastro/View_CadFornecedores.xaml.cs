using dbAcessos;
using dbAcessos.Properties;
using GTManute.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GTManute.Views.Cadastro
{
    /// <summary>
    /// Lógica interna para View_CadFornecedores.xaml
    /// </summary>
    public partial class View_CadFornecedores : Window
    {
        private class Ultimas
        {
            public string Descrição { get; set; }
            public string Quantidade { get; set; }
            public string Preço_Unit { get; set; }
            public string Total { get; set; }

        }

        Addons addons = new Addons();
        private string Usuario { get; set; }
        private GTManute.Properties.Settings cfg = new Properties.Settings();
        private dbAcessos.Properties.Settings cfgdb = new dbAcessos.Properties.Settings();
        private int ID { get; set; }
        List<db_forn> Listpesquisa = new List<db_forn>();
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext("");
        public View_CadFornecedores()
        {
            InitializeComponent();
            Empresa = cfgdb.empresa;
            db = new dbManuteDataContext(addons.NC);
            carregando(0, true);
            cmbBox();
        }
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);

        }
        private void setTelefone(object sender, RoutedEventArgs e)
        {
            TextBox dt = (TextBox)sender;
            try
            {

                double cell = double.Parse(dt.Text);
                if (dt.Text.Length==11)
                {
                    dt.Text = cell.ToString("(##) #####-####");
                }
               else if(dt.Text.Length == 9)
                {
                    dt.Text = cell.ToString("#####-####");
                }
                else if (dt.Text.Length == 8)
                {
                    dt.Text = cell.ToString("####-####");
                }
                else if (dt.Text.Length == 10)
                {
                    dt.Text = cell.ToString("(##) ####-####");
                }
                else
                {
                    mensagem("Telefone invalido!", false, "", "OK");
                }
            }
            catch (Exception ex)
            {
                mensagem("Telefone invalido!", false, "", "OK");

            }

        }
        private void setDoc(object sender, RoutedEventArgs e)
        {
            TextBox dt = (TextBox)sender;
            try
            {

                double cell = double.Parse(dt.Text);
                if (dt.Text.Length == 14)
                {
                    dt.Text = cell.ToString(@"##\.###\.###\/####-##");
                }
                else if (dt.Text.Length == 11)
                {
                    dt.Text = cell.ToString(@"###\.###\.###-##");
                }
                else
                {
                    mensagem("Documento invalido!", false, "", "OK");
                }
            }
            catch (Exception ex)
            {
                mensagem("Telefone invalido!", false, "", "OK");

            }

        }
        private void cmbBox()
        {
            List<string> vs = new List<string>();
            vs.Add("AC");
            vs.Add("AL");
            vs.Add("AP");
            vs.Add("AM");
            vs.Add("BA");
            vs.Add("CE");
            vs.Add("DF");
            vs.Add("ES");
            vs.Add("GO");
            vs.Add("MA");
            vs.Add("MT");
            vs.Add("MS");
            vs.Add("MG");
            vs.Add("PA");
            vs.Add("PB");
            vs.Add("PR");
            vs.Add("PE");
            vs.Add("PI");
            vs.Add("RJ");
            vs.Add("RN");
            vs.Add("RS");
            vs.Add("RO");
            vs.Add("RR");
            vs.Add("SC");
            vs.Add("SP");
            vs.Add("SE");
            vs.Add("TO");

            cmb_uf.ItemsSource = vs;

            List<string> vs1 = new List<string>();
            vs1.Add("A Vista" );
            vs1.Add("Boleto 7 Dias");
            vs1.Add("Boleto 14 Dias");
            vs1.Add("Boleto 21 Dias");
            vs1.Add("Cheque 7 Dias");
            vs1.Add("Cheque 14 Dias");
            vs1.Add("Cheque 21 Dias");
            cmb_pagamento.ItemsSource = vs1;
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
        private void Limpar()
        {
            txt_cidade.Text = "";
            txt_cnpj.Text = "";
            txt_email.Text = "";
            txt_endereco.Text = "";
            txt_fantasia.Text = "";
            txt_inscricao.Text = "";
            txt_razao.Text = "";
            txt_telefone.Text = "";
            txt_telefone2.Text = "";

            cmb_pagamento.Text = "";
            cmb_uf.Text = "";



        }
        private void preencher(string cidade, string cnpj, string email, string endereco, string fantasia, string inscricao,
            string razao, string telefone, string telefone2, string pagamento, string uf)
        {
            Limpar();
            txt_cidade.Text = cidade;
            txt_cnpj.Text = cnpj;
            txt_email.Text = email;
            txt_endereco.Text = endereco;
            txt_fantasia.Text = fantasia;
            txt_inscricao.Text = inscricao;
            txt_razao.Text = razao;
            txt_telefone.Text = telefone;
            txt_telefone2.Text = telefone2;
            cmb_pagamento.Text = pagamento;
            cmb_uf.Text = uf;
            btn_novo.Content = "Novo";
        }

        private async void carregando(int cod, bool full)
        {
            try
            {
                db_forn forn = new db_forn();
                if (cod == 0)
                {
                    forn = await Task.FromResult<db_forn>(db.db_forn.Where(a => a.Empresa == Empresa).OrderByDescending(a => a.codigo).FirstOrDefault());
                }
                else
                {
                    forn = await Task.FromResult<db_forn>(db.db_forn.Where(a => a.Empresa == Empresa).Where(a => a.codigo == cod).FirstOrDefault());
                }
                ID = forn.codigo;
                List<db_manu> ListaCompras = await Task.FromResult<List<db_manu>>(db.db_manu.Where(a => a.Empresa == Empresa).Where(a => a.FORNECEDOR == forn.RAZAO_SOCIAL).OrderByDescending(a => a.COD).Take(20).ToList());

                List<Ultimas> ultimas = new List<Ultimas>();
                for (int i = 0; i < ListaCompras.Count; i++)
                {
                    Ultimas ult = new Ultimas();

                    ult.Descrição = ListaCompras[i].DESCRICAO;
                    ult.Preço_Unit = ListaCompras[i].VALOR;
                    ult.Quantidade = ListaCompras[i].QUANTIDADE;
                    ult.Total = (double.Parse(ListaCompras[i].VALOR.Replace("R$ ", "")) * double.Parse(ListaCompras[i].QUANTIDADE)).ToString("N2");
                    ultimas.Add(ult);

                }
                grid_ultimas.ItemsSource = ultimas;

                if (full == true)
                {
                    carregar(forn);
                }
            }
            catch
            {
                btn_novo.Content = "Gravar";
            }
        }

        private void carregar(db_forn abast)
        {


            preencher(abast.CIDADE, abast.CNPJ, abast.EMAIL, abast.ENDERECO, abast.NM_FANTASIA, abast.INSC_ESTADUAL, abast.RAZAO_SOCIAL,
                abast.TEL1, abast.TEL2, abast.PAGAMENTO, abast.SEG);


        }
        private async void _btn_pesquisar()
        {
            string cidade = txt_pes_cidade.Text;
            string cnpj = txt_pes_cnpj.Text;
            string endereco = txt_pes_endereco.Text;//
            string fantasia = txt_pes_fantasia.Text;//
            string inscricao = txt_pes_inscricao.Text;//
            string razao = txt_pes_razao.Text;//
            string telefone = txt_pes_teltefone.Text;//

            if (rad_contem.IsChecked == true)
            {
                Listpesquisa = await Task.FromResult<List<db_forn>>(db.db_forn.Where(a => a.Empresa == Empresa)
                    .Where(a => a.CIDADE.Contains(cidade)).Where(a => a.CNPJ.Contains(cnpj)).Where(a => a.ENDERECO.Contains(endereco))
                    .Where(a => a.NM_FANTASIA.Contains(fantasia)).Where(a => a.INSC_ESTADUAL.Contains(inscricao)).Where(a => a.RAZAO_SOCIAL.Contains(razao))
                   .Where(a => a.TEL1.Contains(telefone)).OrderByDescending(a => a.codigo).ToList());

                //
                //
                // 

                dt_pesquisa.ItemsSource = Listpesquisa;

                txt_registros.Text = "Nº de Registros: " + Listpesquisa.Count().ToString();
            }
        }

        private void dt_pesquisa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dt_pesquisa.SelectedItem;
                string ID = (dt_pesquisa.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                carregando(int.Parse(ID), true);

            }
            catch
            {
                object item = dt_pesquisa.SelectedItem;
                string ID = (dt_pesquisa.SelectedCells[0].Column.GetCellContent(item) as TextBox).Text;
                carregando(int.Parse(ID), true);
            }
        }

        private void dt_pesquisa_CurrentCellChanged(object sender, System.EventArgs e)
        {

        }

        private void btn_Fechar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void mensagem(string principal, bool explica, string explicacao, string botao)
        {
            Mensagem mensagem = new Mensagem(principal, explica, explicacao, botao);
            mensagem.ShowDialog();
        }
        private async void _btn_excluir()
        {
            string retorno = MessageBox.Show("Deseja deletar este cadastro?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
            if (retorno == "Yes")
            {
                try
                {
                    db_forn forn = await Task.FromResult<db_forn>(db.db_forn.Where(a => a.codigo == ID).FirstOrDefault());
                    db.db_forn.DeleteOnSubmit(forn);
                    db.SubmitChanges();
                    Limpar();
                    carregando(ID - 1, true);
                }
                catch
                {
                    mensagem("Tivemos algum erro ao deletar o cadastro! Revise os campos e tente novamente! \n Caso persista entre em contato com: " + cfg.Email_Dev, false, "", "Ok");
                }

            }
        }
        private async void _Btn_Novo()
        {
            if (btn_novo.Content.ToString() == "Novo")
            {
                btn_novo.Content = "Gravar";
                Limpar();
                grid_ultimas.ItemsSource = null;
            }
            else
            {
               
                string retorno = MessageBox.Show("Gravar cadastro?" , "Conferencia!!!", MessageBoxButton.YesNo).ToString();
                if (retorno == "Yes")
                {
                    try
                    {
                        db_forn _abast = new db_forn();

                        _abast.BAIRRO = "";
                        _abast.CIDADE = txt_cidade.Text;
                        _abast.CNPJ = txt_cnpj.Text;
                        _abast.DT_LANCA = DateTime.Now;
                        _abast.EMAIL = txt_email.Text;
                        _abast.Empresa = Empresa;
                        _abast.ENDERECO = txt_endereco.Text;
                        _abast.INSC_ESTADUAL = txt_inscricao.Text;
                        _abast.NM_FANTASIA = txt_fantasia.Text;
                        _abast.PAGAMENTO = cmb_pagamento.Text;
                        _abast.RAZAO_SOCIAL = txt_razao.Text;
                        _abast.SEG = cmb_uf.Text;
                        _abast.STATUS = "ATIVO";
                        _abast.TEL1 = txt_telefone.Text;
                        _abast.TEL2 = txt_telefone2.Text;
                        _abast.USUARIO = "";


                        await Task.Run(() =>
                        {
                            try
                            {
                                db.db_forn.InsertOnSubmit(_abast);
                                db.SubmitChanges();
                                Application.Current.Dispatcher.Invoke((Action)delegate {
                                    mensagem("Cadastro gravado com sucesso!", false, "", "Ok");
                                
                                
                                btn_novo.Content = "Novo";
                                carregando(0, true);
                                });
                            }
                            catch
                            {
                                Application.Current.Dispatcher.Invoke((Action)delegate {
                                    mensagem("Obtivemos algum erro ao gravar o cadastro! Revise os campos e tente novamente! \n Caso persista entre em contato com: " + cfg.Email_Dev, false, "", "Ok");
                                });
                              }

                        });
                    }
                    catch
                    {
                        mensagem("Obtivemos algum erro ao gravar o abastecimento! Revise os campos e tente novamente! \n Caso persista entre em contato com: " + cfg.Email_Dev, false, "", "Ok");

                    }
                }
            }
        }

        private async void _btn_alterar()
        {
            string retorno = MessageBox.Show("Deseja alterar este cadastro?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
            if (retorno == "Yes")
            {
                db_forn _abast = await Task.FromResult<db_forn>(db.db_forn.Where(a => a.codigo == ID).FirstOrDefault());

                _abast.BAIRRO ="";
                _abast.CIDADE = txt_cidade.Text;
                _abast.CNPJ = txt_cnpj.Text;
                _abast.DT_LANCA = DateTime.Now;
                _abast.EMAIL = txt_email.Text;
                _abast.Empresa = Empresa;
                _abast.ENDERECO = txt_endereco.Text;
                _abast.INSC_ESTADUAL = txt_inscricao.Text;
                _abast.NM_FANTASIA = txt_fantasia.Text;
                _abast.PAGAMENTO = cmb_pagamento.Text;
                _abast.RAZAO_SOCIAL = txt_razao.Text;
                _abast.SEG = cmb_uf.Text;
                _abast.STATUS = "ATIVO";
                _abast.TEL1 = txt_telefone.Text;
                _abast.TEL2 = txt_telefone2.Text;
                _abast.USUARIO = "";
                


                await Task.Run(() =>
                {
                    try
                    {
                        db.SubmitChanges();
                        Application.Current.Dispatcher.Invoke((Action)delegate {
                            mensagem("Fornecedor gravado com sucesso!", false, "", "Ok");
                       
                        
                        carregando(ID, true);
                        });
                    }
                    catch
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate {
                            mensagem("Tivemos algum erro ao alterar o cadastro! Revise os campos e tente novamente! \n Caso persista entre em contato com: " + cfg.Email_Dev, false, "", "Ok");

                        });
                     }
                });
            }
        }

        private void txt_telefone_LostFocus(object sender, RoutedEventArgs e)
        {
            setTelefone(sender, e);
        }

        private void txt_telefone2_LostFocus(object sender, RoutedEventArgs e)
        {
            setTelefone(sender, e);
        }

        private void txt_cnpj_LostFocus(object sender, RoutedEventArgs e)
        {
            setDoc(sender, e);
        }

        private void btn_novo_Click(object sender, RoutedEventArgs e)
        {
            _Btn_Novo();
        }

        private void btn_alterar_Click(object sender, RoutedEventArgs e)
        {
            _btn_alterar();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            _btn_excluir();
        }

        private void btn_pesquisar_Click(object sender, RoutedEventArgs e)
        {
            _btn_pesquisar();
        }
    }
}
