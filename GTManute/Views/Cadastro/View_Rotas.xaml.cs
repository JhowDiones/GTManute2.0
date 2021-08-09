using dbAcessos;
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
    public partial class View_Rotas : Window
    {
        private class Ultimas
        {
            public string Motorista { get; set; }
            public string KmRodado { get; set; }
            public string Média { get; set; }
            public string DTPartida { get; set; }
        }

        private string Usuario { get; set; }
        private GTManute.Properties.Settings cfg = new Properties.Settings();
        private dbAcessos.Properties.Settings cfgdb = new dbAcessos.Properties.Settings();
        private int ID { get; set; }
        List<db_rotas> Listpesquisa = new List<db_rotas>();
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext("");
        public View_Rotas()
        {
            InitializeComponent();
            Empresa = cfgdb.empresa;
            db = new dbManuteDataContext(cfgdb.conexao);
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
            cmb_ufpartida.ItemsSource = vs;
            cmb_ufdestino.ItemsSource = vs;
        }
        private void Limpar()
        {
            txt_destino.Text = "";
            txt_partida.Text = "";
            cmb_ufdestino.Text = "";
            cmb_ufpartida.Text = "";
            txt_destino.Text = "";

        }
        private void preencher(string destino, string partida, string detinouf, string partidauf, string distancia)
        {
            Limpar();

            txt_destino.Text = destino;
            txt_partida.Text = partida;
            cmb_ufdestino.Text = detinouf; 
            cmb_ufpartida.Text = partidauf;
            txt_distancia.Text = distancia;

        }

        private async void carregando(int cod, bool full)
        {
            try
            {
                db_rotas frota = new db_rotas();
                if (cod == 0)
                {
                    frota = await Task.FromResult<db_rotas>(db.db_rotas.Where(a => a.Empresa == Empresa).OrderByDescending(a => a.COD).FirstOrDefault());
                }
                else
                {
                    frota = await Task.FromResult<db_rotas>(db.db_rotas.Where(a => a.Empresa == Empresa).Where(a => a.COD == cod).FirstOrDefault());
                }
                ID = frota.COD;
                List<db_abast> Listaabast = await Task.FromResult<List<db_abast>>(db.db_abast.Where(a => a.Empresa == Empresa).Where(a => a.DE==frota.DE).Where(a => a.PARA == frota.PARA).OrderByDescending(a => a.ID).Take(20).ToList());

                List<Ultimas> ultimas = new List<Ultimas>();
                for (int i = 0; i < Listaabast.Count; i++)
                {
                    Ultimas ult = new Ultimas();
                    ult.Motorista = Listaabast[i].MOTORISTA;
                    ult.KmRodado = (double.Parse(Listaabast[i].KM_CHEGADA) - double.Parse(Listaabast[i].KM_PARTIDA)).ToString("N2");
                    ult.Média = (double.Parse(ult.KmRodado) / double.Parse(Listaabast[i].LITRAGEM)).ToString("N2");
                    ult.DTPartida = Listaabast[i].DT_PARTIDA;
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
                btn_novo.Content = "Gravar";
            }
        }

        private void carregar(db_rotas abast)
        {


            preencher(abast.PARA,abast.DE,abast.UF_PARA,abast.UF_DE,abast.DISTANCIA);


        }
        private async void btn_pesquisar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string partida = txt_pes_placa.Text;
            string destino = txt_pes_modelo.Text;
           

            if (rad_contem.IsChecked == true)
            {
                Listpesquisa = await Task.FromResult<List<db_rotas>>(db.db_rotas.Where(a => a.Empresa == Empresa)
                    .Where(a => a.DE.Contains(partida)).Where(a => a.PARA.Contains(destino))
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
        private async void _btn_deletar()
        {
            string retorno = MessageBox.Show("Deseja deletar este cadastro?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
            if (retorno == "Yes")
            {
                try
                {
                    db_rotas forn = await Task.FromResult<db_rotas>(db.db_rotas.Where(a => a.COD == ID).FirstOrDefault());
                    db.db_rotas.DeleteOnSubmit(forn);
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
        private async void _btn_novo()
        {
            if (btn_novo.Content.ToString() == "Novo")
            {
                btn_novo.Content = "Gravar";
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
                        db_rotas _abast = new db_rotas();

                        
                        _abast.DE = txt_partida.Text;
                        _abast.PARA = txt_destino.Text;
                        _abast.UF_DE = cmb_ufpartida.Text;
                        _abast.UF_PARA = cmb_ufdestino.Text;
                        _abast.DISTANCIA = txt_distancia.Text;
                        _abast.USUARIO = "";
                        _abast.Empresa = Empresa;


                        await Task.Run(() =>
                        {
                            try
                            {
                                db.db_rotas.InsertOnSubmit(_abast);
                                db.SubmitChanges();
                                Application.Current.Dispatcher.Invoke((Action)delegate
                                {
                                    mensagem("Cadastro gravado com sucesso!", false, "", "Ok");


                                    btn_novo.Content = "Novo";
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
                        mensagem("Obtivemos algum erro ao gravar o cadastro! Revise os campos e tente novamente! \n Caso persista entre em contato com: " + cfg.Email_Dev, false, "", "Ok");

                    }
                }
            }
        }

        private async void _btn_alterar()
        {
            string retorno = MessageBox.Show("Deseja alterar este cadastro?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
            if (retorno == "Yes")
            {
                db_rotas _abast = await Task.FromResult<db_rotas>(db.db_rotas.Where(a => a.COD == ID).FirstOrDefault());


                _abast.DE = txt_partida.Text;
                _abast.PARA = txt_destino.Text;
                _abast.UF_DE = cmb_ufpartida.Text;
                _abast.UF_PARA = cmb_ufdestino.Text;
                _abast.DISTANCIA = txt_distancia.Text;



                await Task.Run(() =>
                {
                    try
                    {
                        db.SubmitChanges();
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            mensagem("Veículo gravado com sucesso!", false, "", "Ok");


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

        private void txt_eixos_LostFocus(object sender, RoutedEventArgs e)
        {
           
        }

        private void btn_calcular_Click(object sender, RoutedEventArgs e)
        {
            mensagem("Veja a distância no site que abrirá no seu navegador web e coloque no campo distância para continuar!", false, "", "OK");
            System.Diagnostics.Process.Start("https://pt.distance.to/"+txt_partida.Text+"-"+cmb_ufpartida.Text+"/"+txt_destino.Text+"-"+cmb_ufdestino.Text);
        }

        private void btn_novo_Click(object sender, RoutedEventArgs e)
        {
            _btn_novo();
        }

        private void btn_alterar_Click(object sender, RoutedEventArgs e)
        {
            _btn_alterar();
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            _btn_deletar();
        }
    }
}
