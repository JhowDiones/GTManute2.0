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

namespace GTManute.Views.Lançamento
{
    /// <summary>
    /// Lógica interna para View_Abast.xaml
    /// </summary>
    public partial class View_Abast : Window
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
        List<db_abast> Listpesquisa = new List<db_abast>();
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext("");
        public View_Abast()
        {
            InitializeComponent();
            db = new dbManuteDataContext(cfgdb.conexao);

            Empresa = cfgdb.empresa;
            carregando(0, true);
            cmbbox();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex(@"[^0-9,]+");
            e.Handled = regex.IsMatch(e.Text);

        }
        private void setData(object sender, RoutedEventArgs e)
        {
            TextBox dt = (TextBox)sender;
            try
            {
                string justNumbers = new String(dt.Text.Where(Char.IsDigit).ToArray());

                string newDate = justNumbers.Insert(2, "/").Insert(5, "/");

                dt.Text = DateTime.Parse(newDate).ToString("dd/MM/yyyy");
            }
            catch (Exception ex)
            {
                mensagem("Data invalida!", false, "", "OK");

            }

        }
        private void setValor(object sender, RoutedEventArgs e)
        {
            TextBox dt = (TextBox)sender;
            try
            {

                double newDate = double.Parse(dt.Text);

                dt.Text = newDate.ToString("N2");
            }
            catch (Exception ex)
            {
                mensagem("Valor invalido!", false, "", "OK");

            }

        }
        private void setHora(object sender, RoutedEventArgs e)
        {
            TextBox dt = (TextBox)sender;
            try
            {
                string justNumbers = new String(dt.Text.Where(Char.IsDigit).ToArray());

                string newDate = justNumbers.Insert(2, ":");
               
                dt.Text = DateTime.Parse(newDate).ToString("HH:mm");
            }
            catch (Exception ex)
            {
                mensagem("horario invalido invalida!", false, "", "OK");

            }

        }
        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
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
        private async void cmbbox()
        {

            await Task.Run(async () =>
            {
                Application.Current.Dispatcher.Invoke((Action)async delegate
                {
                    List<string> ajudante = new List<string>();
                    List<string> motorista = new List<string>();
                    List<string> fornecedor = new List<string>();
                    List<string> Rotas = new List<string>();
                    List<string> Rotas1 = new List<string>();
                    List<string> placas = new List<string>();

                    List<db_colaboradores> aju = await Task.FromResult<List<db_colaboradores>>(db.db_colaboradores.Where(a => a.funcao == "AJUDANTE").OrderBy(a => a.NOME).ToList());

                    List<db_frota> pla = await Task.FromResult<List<db_frota>>(db.db_frota.OrderBy(a => a.PLACA).ToList());
                    List<db_colaboradores> moto = await Task.FromResult<List<db_colaboradores>>(db.db_colaboradores.Where(a => a.funcao == "MOTORISTA").OrderBy(a => a.NOME).ToList());
                    List<db_forn> forn = await Task.FromResult<List<db_forn>>(db.db_forn.OrderBy(a => a.RAZAO_SOCIAL).ToList());
                    List<db_rotas> rot = await Task.FromResult<List<db_rotas>>(db.db_rotas.OrderBy(a => a.PARA).ToList());
                    List<db_rotas> rot1 = await Task.FromResult<List<db_rotas>>(db.db_rotas.OrderBy(a => a.DE).ToList());
                    for (int i = 0; i < aju.Count; i++)
                    {
                        ajudante.Add(aju[i].NOME);
                    }
                    for (int i = 0; i < moto.Count; i++)
                    {
                        motorista.Add(moto[i].NOME);
                    }
                    for (int i = 0; i < pla.Count; i++)
                    {
                        placas.Add(pla[i].PLACA);
                    }
                    for (int i = 0; i < forn.Count; i++)
                    {
                        fornecedor.Add(forn[i].RAZAO_SOCIAL);
                    }
                    for (int i = 0; i < rot.Count; i++)
                    {
                        Rotas.Add(rot[i].PARA);
                    }
                    cmb_destino.ItemsSource = Rotas;

                    for (int i = 0; i < rot1.Count; i++)
                    {
                        Rotas1.Add(rot1[i].DE);
                    }
                    List<string> combustivel = new List<string>();
                    combustivel.Add("Disel");
                    combustivel.Add("Disel S-10");
                    combustivel.Add("Disel Aditivado");
                    combustivel.Add("Disel Premium");
                    combustivel.Add("Etanol");
                    combustivel.Add("Etanol Aditivado");
                    combustivel.Add("Gasolina Comum");
                    combustivel.Add("Gasolina Aditivada");
                    combustivel.Add("Gasolina Premium");

                    cmb_combustivel.ItemsSource = combustivel;
                    cmb_partida.ItemsSource = Rotas1;
                    cmb_1ajudante.ItemsSource = ajudante;
                    cmb_2ajudante.ItemsSource = ajudante;
                    cmb_motorista.ItemsSource = motorista;
                    cmb_fornecedor.ItemsSource = fornecedor;
                    cmb_veiculo.ItemsSource = placas;

                });
            });

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
                double média = 0;
                double valorunit = 0;
                try
                {
                    média = ((double.Parse(txt_km_destino.Text) - double.Parse(txt_km_inicial.Text)) / double.Parse(txt_litragem.Text));
                    valorunit = (double.Parse(txt_valor.Text) / double.Parse(txt_litragem.Text));
                }
                catch
                {

                }
                String retorno = MessageBox.Show("Gravar abastecimento? \n Média: " + média.ToString("N2") + "| Valor total: " + valorunit.ToString("N2"), "Conferencia!!!", MessageBoxButton.YesNo).ToString();
                if (retorno == "Yes")
                {
                    try
                    {
                        db_abast _abast = new db_abast();

                        _abast.AJUDANTE1 = cmb_1ajudante.Text;
                        _abast.AJUDANTE2 = cmb_2ajudante.Text;
                        _abast.DE = cmb_partida.Text;
                        _abast.DESPESA_ALI = txt_desp_alimentacao.Text;
                        _abast.DESPESA_COMB = txt_res_unitario.Text;
                        _abast.DESPESA_OUTRAS = txt_outras_desp.Text;
                        _abast.DESPESA_PERN = txt_desp_pernoite.Text;
                        _abast.DT_CHEGADA = txt_dt_destino.Text;
                        _abast.DT_PARTIDA = txt_dt_partida.Text;
                        _abast.Empresa = Empresa;
                        _abast.FORNECEDOR = cmb_fornecedor.Text;
                        _abast.HORA_CHEGADA = txt_hr_destino.Text;
                        _abast.HORA_PARTIDA = txt_hr_partida.Text;
                        _abast.KM_CHEGADA = txt_km_destino.Text;
                        _abast.KM_PARTIDA = txt_km_inicial.Text;
                        _abast.LITRAGEM = txt_litragem.Text;
                        _abast.MOTORISTA = cmb_motorista.Text;
                        _abast.N_DOC = txt_doc.Text;
                        _abast.PARA = cmb_destino.Text;
                        _abast.periodo = (DateTime.Parse(txt_dt_destino.Text) - DateTime.Parse(txt_dt_partida.Text)).ToString();
                        _abast.USUARIO = Usuario;
                        _abast.VALOR_TOTAL = txt_valor.Text;
                        _abast.DT_HR = DateTime.UtcNow;


                        await Task.Run(() =>
                        {
                            try
                            {
                                db.db_abast.InsertOnSubmit(_abast);
                                db.SubmitChanges();
                                Application.Current.Dispatcher.Invoke((Action)delegate
                                {
                                    mensagem("Abastecimento gravado com sucesso!", false, "", "Ok");


                                    btn_novo.Text = "Novo";
                                    carregando(0, true);
                                });
                            }
                            catch
                            {
                                Application.Current.Dispatcher.Invoke((Action)delegate
                                {
                                    mensagem("Obtivemos algum erro ao gravar o abastecimento! Revise os campos e tente novamente! \n Caso persista entre em contato com: " + cfg.Email_Dev, false, "", "Ok");
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
            String retorno = MessageBox.Show("Deseja alterar este abastecimento?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
            if (retorno == "Yes")
            {
                db_abast _abast = await Task.FromResult<db_abast>(db.db_abast.Where(a => a.ID == ID).FirstOrDefault());

                _abast.AJUDANTE1 = cmb_1ajudante.Text;
                _abast.AJUDANTE2 = cmb_2ajudante.Text;
                _abast.DE = cmb_partida.Text;
                _abast.DESPESA_ALI = txt_desp_alimentacao.Text;
                _abast.DESPESA_COMB = txt_res_unitario.Text;
                _abast.DESPESA_OUTRAS = txt_outras_desp.Text;
                _abast.DESPESA_PERN = txt_desp_pernoite.Text;
                _abast.DT_CHEGADA = txt_dt_destino.Text;
                _abast.DT_PARTIDA = txt_dt_partida.Text;
                _abast.Empresa = Empresa;
                _abast.FORNECEDOR = cmb_fornecedor.Text;
                _abast.HORA_CHEGADA = txt_hr_destino.Text;
                _abast.HORA_PARTIDA = txt_hr_partida.Text;
                _abast.KM_CHEGADA = txt_km_destino.Text;
                _abast.KM_PARTIDA = txt_km_inicial.Text;
                _abast.LITRAGEM = txt_litragem.Text;
                _abast.MOTORISTA = cmb_motorista.Text;
                _abast.N_DOC = txt_doc.Text;
                _abast.PARA = cmb_destino.Text;
                _abast.periodo = (DateTime.Parse(txt_dt_destino.Text) - DateTime.Parse(txt_dt_partida.Text)).ToString();
                _abast.USUARIO = Usuario;
                _abast.VALOR_TOTAL = txt_valor.Text;
                _abast.DT_HR = DateTime.UtcNow;


                await Task.Run(() =>
                {
                    try
                    {
                        db.SubmitChanges();
                        Application.Current.Dispatcher.Invoke((Action)delegate
                        {
                            mensagem("Abastecimento gravado com sucesso!", false, "", "Ok");

                            carregando(ID, true);
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
        }

        private async void btn_delete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string retorno = MessageBox.Show("Deseja alterar este abastecimento?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
            if (retorno == "Yes")
            {
                try
                {
                    db_abast abast = await Task.FromResult<db_abast>(db.db_abast.Where(a => a.ID == ID).FirstOrDefault());
                    db.db_abast.DeleteOnSubmit(abast);
                    db.SubmitChanges();
                    Limpar();
                    carregando(ID - 1, true);
                }
                catch
                {
                    Application.Current.Dispatcher.Invoke((Action)delegate
                    {
                        mensagem("Tivemos algum erro ao deletar o abastecimento! Revise os campos e tente novamente! \n Caso persista entre em contato com: " + cfg.Email_Dev, false, "", "Ok");
                    });
                }

            }
        }
        private void Limpar()
        {
            txt_desp_alimentacao.Text = "";
            txt_desp_pernoite.Text = "";
            txt_doc.Text = "";
            txt_dt_destino.Text = "";
            txt_dt_partida.Text = "";
            txt_hr_destino.Text = "";
            txt_hr_partida.Text = "";
            txt_km_destino.Text = "";
            txt_km_inicial.Text = "";
            txt_litragem.Text = "";
            txt_outras_desp.Text = "";

            cmb_1ajudante.Text = "";
            cmb_2ajudante.Text = "";
            cmb_destino.Text = "";
            cmb_fornecedor.Text = "";
            cmb_motorista.Text = "";
            cmb_partida.Text = "";
            cmb_veiculo.Text = "";

            txt_res_km.Text = "";
            txt_res_media.Text = "";
            txt_res_unitario.Text = "";
            txt_valor.Text = "";


        }
        private void preencher(string despAlimentacao, string despPernoite, string doc, string dtdestino, string dtpartida,
            string hrdestino, string hrpartida, string kmdestino, string kmpartida, string litragem, string outrasdesp, string valor,
             string ajudante1, string ajudante2, string destino, string fornecedor, string motorista,
    string partida, string veiculo)
        {
            Limpar();
            txt_desp_alimentacao.Text = despAlimentacao;
            txt_desp_pernoite.Text = despPernoite;
            txt_doc.Text = doc;
            txt_dt_destino.Text = dtdestino;
            txt_dt_partida.Text = dtpartida;
            txt_hr_destino.Text = hrdestino;
            txt_hr_partida.Text = hrpartida;
            txt_km_destino.Text = kmdestino;
            txt_km_inicial.Text = kmpartida;
            txt_litragem.Text = litragem;
            txt_outras_desp.Text = outrasdesp;

            cmb_1ajudante.Text = ajudante1;
            cmb_2ajudante.Text = ajudante2;
            cmb_destino.Text = destino;
            cmb_fornecedor.Text = fornecedor;
            cmb_motorista.Text = motorista;
            cmb_partida.Text = partida;
            cmb_veiculo.Text = veiculo;
            txt_valor.Text = valor;

            double kmrestante = double.Parse(kmdestino) - double.Parse(kmpartida);
            double media = kmrestante / double.Parse(litragem);
            valor = valor.Replace("R$ ", "");
            double unitario = double.Parse(valor) / double.Parse(litragem);
            txt_res_km.Text = kmrestante.ToString("N2");
            txt_res_media.Text = media.ToString("N2");
            txt_res_unitario.Text = unitario.ToString("N2");


        }

        private async void carregando(int cod, bool full)
        {
            try
            {
                db_abast abast = new db_abast();
                if (cod == 0)
                {
                    abast = await Task.FromResult<db_abast>(db.db_abast.Where(a => a.Empresa == Empresa).OrderByDescending(a => a.ID).FirstOrDefault());
                }
                else
                {
                    abast = await Task.FromResult<db_abast>(db.db_abast.Where(a => a.Empresa == Empresa).Where(a => a.ID == cod).FirstOrDefault());
                }
                ID = abast.ID;
                List<db_abast> Listaabast = await Task.FromResult<List<db_abast>>(db.db_abast.Where(a => a.Empresa == Empresa).Where(a => a.PLACA == abast.PLACA).Where(a => a.DE == abast.DE).Where(a => a.PARA == abast.PARA).OrderByDescending(a => a.ID).Take(5).ToList());

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
                    carregar(abast);
                }
            }
            catch
            {
                btn_novo.Text = "Gravar";
            }
        }

        private void carregar(db_abast abast)
        {


            preencher(abast.DESPESA_ALI, abast.DESPESA_PERN, abast.N_DOC, abast.DT_CHEGADA,
                abast.DT_PARTIDA, abast.HORA_CHEGADA, abast.HORA_PARTIDA, abast.KM_CHEGADA, abast.KM_PARTIDA,
                abast.LITRAGEM, abast.DESPESA_OUTRAS, abast.VALOR_TOTAL, abast.AJUDANTE1, abast.AJUDANTE2, abast.PARA, abast.FORNECEDOR, abast.MOTORISTA, abast.DE, abast.PLACA);
        }

        private async void btn_pesquisar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string dtchegada = txt_pes_datachegada.Text;
            string dtpartida = txt_pes_datapartida.Text;
            string placa = txt_pes_veiculo.Text;//
            string motorista = txt_pes_motorista.Text;//
            string fornecedor = txt_pes_fornecedor.Text;//
            string localpartida = txt_pes_Locpartida.Text;//
            string localdestino = txt_pes_locdestino.Text;//

            if (rad_contem.IsChecked == true)
            {
                Listpesquisa = await Task.FromResult<List<db_abast>>(db.db_abast.Where(a => a.Empresa == Empresa)
                    .Where(a => a.DE.Contains(localpartida)).Where(a => a.PLACA.Contains(placa)).Where(a => a.PARA.Contains(localdestino))
                    .Where(a => a.MOTORISTA.Contains(motorista)).Where(a => a.FORNECEDOR.Contains(fornecedor)).Where(a => a.DT_CHEGADA.Contains(dtchegada))
                   .Where(a => a.DT_PARTIDA.Contains(dtpartida)).OrderByDescending(a => a.ID).ToList());

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

        private void Grid_LostFocus(object sender, RoutedEventArgs e)
        {
            double média = 0;
            double valorunit = 0;
            double km = 0;
            try
            {
                média = ((double.Parse(txt_km_destino.Text) - double.Parse(txt_km_inicial.Text)) / double.Parse(txt_litragem.Text));
                valorunit = (double.Parse(txt_valor.Text) / double.Parse(txt_litragem.Text));
                km = (double.Parse(txt_km_destino.Text) - double.Parse(txt_km_inicial.Text));
                txt_res_unitario.Text = valorunit.ToString("N2");
                txt_res_media.Text = média.ToString("N2");
                txt_res_media.Text = km.ToString();

            }
            catch
            {

            }
        }

        

        private void txt_dt_partida_LostFocus(object sender, RoutedEventArgs e)
        {
            setData(sender, e);
        }

        private void txt_dt_destino_LostFocus(object sender, RoutedEventArgs e)
        {
            setData(sender, e);
        }

        private void txt_desp_alimentacao_LostFocus(object sender, RoutedEventArgs e)
        {
            setValor(sender, e);
        }

        private void cmb_veiculo_LostFocus(object sender, RoutedEventArgs e)
        {

        }

        private void txt_litragem_LostFocus(object sender, RoutedEventArgs e)
        {
            setValor(sender, e);
            try
            {
               double valorunit = (double.Parse(txt_valor.Text) / double.Parse(txt_litragem.Text));
                txt_res_unitario.Text = valorunit.ToString("N2");
            }
            catch
            {

            }
        }

        private void txt_valor_LostFocus(object sender, RoutedEventArgs e)
        {
            setValor(sender, e);
            try
            {
                double valorunit = (double.Parse(txt_valor.Text) / double.Parse(txt_litragem.Text));
                txt_res_unitario.Text = valorunit.ToString("N2");
            }
            catch
            {

            }
        }

        private void txt_hr_partida_LostFocus(object sender, RoutedEventArgs e)
        {
            setHora(sender, e);
        }
    }

}
