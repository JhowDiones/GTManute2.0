using dbAcessos;
using GTManute.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace GTManute.Views.Cadastro
{
    /// <summary>
    /// Lógica interna para View_CadFornecedores.xaml
    /// </summary>
    public partial class View_Colaboradores : Window
    {
        private class Ultimas
        {
            public string Data { get; set; }
            public string Veículo { get; set; }
            public string Partida { get; set; }
            public string Destino { get; set; }
        }


        private string Usuario { get; set; }
        private Settings cfg = new Settings();
        private int ID { get; set; }
        List<db_colaboradores> Listpesquisa = new List<db_colaboradores>();
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext();
        public View_Colaboradores()
        {
            InitializeComponent();
            Empresa = cfg.Empresa;
            carregando(0, true);
            cmbBox();
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
        private void cmbBox()
        {
            List<string> vs = new List<string>();
            vs.Add("Ajudante");
            vs.Add("Motorista");

            cmb_funcao.ItemsSource = vs;

        }
        private void Limpar()
        {
            txt_categoria.Text = "";
            txt_cnh.Text = "";
            txt_cpf.Text = "";
            txt_endereco.Text = "";
            txt_nome.Text = "";
            txt_rg.Text = "";
            txt_Sobrenome.Text = "";
            txt_telefone.Text = "";
            txt_telefone2.Text = "";
            txt_validadecnh.Text = "";
            cmb_funcao.Text = "";


        }
        private void preencher(db_colaboradores col)
        {
            Limpar();
            txt_categoria.Text =col.CAT_CNH;
            txt_cnh.Text = col.CNH;
            txt_cpf.Text =col.CPF;
            txt_endereco.Text = col.ENDERECO;
            txt_nome.Text = col.NOME;
            txt_rg.Text = col.RG;
            txt_Sobrenome.Text = col.SOBRENOME;
            txt_telefone.Text = col.TEL;
            txt_telefone2.Text = col.TEL2;
            txt_validadecnh.Text = col.DT_CNH;
            cmb_funcao.Text = col.funcao;


        }

        private async void carregando(int cod, bool full)
        {
            try
            {
                db_colaboradores frota = new db_colaboradores();
                if (cod == 0)
                {
                    frota = await Task.FromResult<db_colaboradores>(db.db_colaboradores.Where(a => a.Empresa == Empresa).OrderByDescending(a => a.COD).FirstOrDefault());
                }
                else
                {
                    frota = await Task.FromResult<db_colaboradores>(db.db_colaboradores.Where(a => a.Empresa == Empresa).Where(a => a.COD == cod).FirstOrDefault());
                }
                ID = frota.COD;
                List<db_abast> Listaabast = new List<db_abast>();
                if (frota.funcao == "Motorista")
                {
                    Listaabast = await Task.FromResult<List<db_abast>>(db.db_abast.Where(a => a.Empresa == Empresa).Where(a => a.MOTORISTA == frota.NOME).OrderByDescending(a => a.ID).Take(20).ToList());
                }
                else
                {
                    List<db_abast> ajudante1 = await Task.FromResult<List<db_abast>>(db.db_abast.Where(a => a.Empresa == Empresa).Where(a => a.AJUDANTE1 == frota.NOME).OrderByDescending(a => a.ID).Take(20).ToList());
                    Listaabast.AddRange(ajudante1);
                    List<db_abast> ajudante2 = await Task.FromResult<List<db_abast>>(db.db_abast.Where(a => a.Empresa == Empresa).Where(a => a.AJUDANTE2 == frota.NOME).OrderByDescending(a => a.ID).Take(20).ToList());
                    Listaabast.AddRange(ajudante2);
                }

                List<Ultimas> ultimas = new List<Ultimas>();
                for (int i = 0; i < Listaabast.Count; i++)
                {
                    Ultimas ult = new Ultimas();

                    ult.Data = Listaabast[i].DT_CHEGADA;
                    ult.Destino = Listaabast[i].PARA;
                    ult.Partida = Listaabast[i].DE;
                    ult.Veículo = Listaabast[i].PLACA;
                    ultimas.Add(ult);

                }
                grid_ultimas.ItemsSource = ultimas;

                if (full == true)
                {
                    carregar(frota);
                }
            }
            catch
            {
                btn_novo.Text = "Gravar";
            }
        }

        private void carregar(db_colaboradores abast)
        {


            preencher(abast);


        }
        private async void btn_pesquisar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string cnh = txt_pes_cnh.Text;
            string cpf = txt_pes_cpf.Text;//
            string nome = txt_pes_nome.Text;//
            string sobrenome = txt_pes_sobrenome.Text;//

            if (rad_contem.IsChecked == true)
            {
                Listpesquisa = await Task.FromResult<List<db_colaboradores>>(db.db_colaboradores.Where(a => a.Empresa == Empresa)
                    .Where(a => a.CNH.Contains(cnh)).Where(a => a.CPF.Contains(cpf)).Where(a => a.NOME.Contains(nome))
                    .Where(a => a.SOBRENOME.Contains(sobrenome))
                   .OrderByDescending(a => a.COD).ToList());

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
                carregando(Listpesquisa[dt_pesquisa.SelectedIndex].COD, true);
            }
            catch
            {

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
        private async void btn_delete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string retorno = MessageBox.Show("Deseja deletar este cadastro?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
            if (retorno == "Yes")
            {
                try
                {
                    db_colaboradores forn = await Task.FromResult<db_colaboradores>(db.db_colaboradores.Where(a => a.COD == ID).FirstOrDefault());
                    db.db_colaboradores.DeleteOnSubmit(forn);
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
        private async void btn_novo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (btn_novo.Text == "Novo")
            {
                btn_novo.Text = "Gravar";
                Limpar();
                grid_ultimas.ItemsSource = null;
            }
            else
            {

                string retorno = MessageBox.Show("Gravar cadastro?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
                if (retorno == "Yes")
                {
                    try
                    {
                        db_colaboradores _abast = new db_colaboradores();

                        _abast.CAT_CNH = txt_categoria.Text;
                        _abast.CNH = txt_cnh.Text;
                        _abast.CPF = txt_cpf.Text;
                        _abast.DT_LANCA = DateTime.Now;
                        _abast.DT_CNH = txt_validadecnh.Text;
                        _abast.Empresa = Empresa;
                        _abast.ENDERECO = txt_endereco.Text;
                        _abast.funcao = cmb_funcao.Text;
                        _abast.NOME = txt_nome.Text;
                        _abast.RG = txt_rg.Text;
                        _abast.SOBRENOME = txt_Sobrenome.Text;
                        _abast.TEL = txt_telefone.Text;
                        _abast.TEL2 = txt_telefone2.Text;
                       

                        _abast.USUARIO = "";


                        await Task.Run(() =>
                        {
                            try
                            {
                                db.db_colaboradores.InsertOnSubmit(_abast);
                                db.SubmitChanges();
                                Application.Current.Dispatcher.Invoke((Action)delegate
                                {
                                    mensagem("Cadastro gravado com sucesso!", false, "", "Ok");


                                    btn_novo.Text = "Novo";
                                    carregando(0, true);
                                });
                            }
                            catch
                            {
                                Application.Current.Dispatcher.Invoke((Action)delegate
                                {
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

        private async void btn_alterar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string retorno = MessageBox.Show("Deseja alterar este cadastro?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
            if (retorno == "Yes")
            {
                db_colaboradores _abast = await Task.FromResult<db_colaboradores>(db.db_colaboradores.Where(a => a.COD == ID).FirstOrDefault());
                _abast.CAT_CNH = txt_categoria.Text;
                _abast.CNH = txt_cnh.Text;
                _abast.CPF = txt_cpf.Text;
                _abast.DT_LANCA = DateTime.Now;
                _abast.DT_CNH = txt_validadecnh.Text;
                _abast.Empresa = Empresa;
                _abast.ENDERECO = txt_endereco.Text;
                _abast.funcao = cmb_funcao.Text;
                _abast.NOME = txt_nome.Text;
                _abast.RG = txt_rg.Text;
                _abast.SOBRENOME = txt_Sobrenome.Text;
                _abast.TEL = txt_telefone.Text;
                _abast.TEL2 = txt_telefone2.Text;



                await Task.Run(() =>
                {
                    try
                    {
                        db.SubmitChanges();
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            mensagem("Cadastro alterado com sucesso!", false, "", "Ok");


                            carregando(ID, true);
                        });
                    }
                    catch
                    {
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            mensagem("Tivemos algum erro ao alterar o cadastro! Revise os campos e tente novamente! \n Caso persista entre em contato com: " + cfg.Email_Dev, false, "", "Ok");

                        });
                    }
                });
            }
        }

    }
}
