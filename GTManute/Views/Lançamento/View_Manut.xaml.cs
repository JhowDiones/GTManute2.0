using dbAcessos;
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
    public partial class View_Manut : Window
    {
        private class Ultimas
        {
            public int ID { get; set; }
            public string Descrição { get; set; }
            public string Quant { get; set; }
            public string Desconto { get; set; }
            public string Total { get; set; }
        }
        List<Ultimas> ultimas = new List<Ultimas>();
        private string Usuario { get; set; }
        private GTManute.Properties.Settings cfg = new Properties.Settings();
        private dbAcessos.Properties.Settings cfgdb = new dbAcessos.Properties.Settings();
        private int ID { get; set; }
        private int PecaId { get; set; }
        db_manu_log manulog = new db_manu_log();
        List<db_manu> Excluirpecaslista = new List<db_manu>();
        List<db_manu> Listpesquisa = new List<db_manu>();
        List<db_manu> Novaspecaslista = new List<db_manu>();
        List<db_manu> pecaslista = new List<db_manu>();
        db_manu peca = new db_manu();
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext("");
        public View_Manut()
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
            try
            {
                this.DragMove();
            }
            catch
            {

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
        private async void cmbbox()
        {

            await Task.Run(async () =>
            {
                Application.Current.Dispatcher.Invoke((Action)async delegate
                {

                    List<string> pla = await Task.FromResult<List<string>>(db.db_frota.Where(a => a.Empresa == Empresa).OrderBy(a => a.PLACA).Select(a => a.PLACA).Distinct().ToList());
                    List<string> moto = await Task.FromResult<List<string>>(db.db_colaboradores.Where(a => a.Empresa == Empresa).Where(a => a.funcao == "MOTORISTA").OrderBy(a => a.NOME).Select(a => a.NOME).Distinct().ToList());
                    List<string> forn = await Task.FromResult<List<string>>(db.db_forn.OrderBy(a => a.RAZAO_SOCIAL).Where(a => a.Empresa == Empresa).Select(a => a.RAZAO_SOCIAL).Distinct().ToList());
                    List<string> peca = await Task.FromResult<List<string>>(db.db_manu.OrderBy(a => a.DESCRICAO).Where(a => a.Empresa == Empresa).Select(a => a.DESCRICAO).Distinct().ToList());

                    cmb_fornecedor.ItemsSource = forn;
                    cmb_motorista.ItemsSource = moto;
                    cmb_ItemDesc.ItemsSource = peca;
                    cmb_veiculo.ItemsSource = pla;

                });
            });

        }
        private async void _btn_novo()
        {
            if (btn_novo.Content.ToString() == "Novo")
            {
                btn_novo.Content = "Gravar";
                pecaslista = new List<db_manu>();
                Limpar();
                PecaId = -1;
                ultimas.Clear();
                Novaspecaslista.Clear();
                Excluirpecaslista.Clear();
                pecaslista.Clear();
                grid_itens.ItemsSource = null;
            }
            else
            {

                String retorno = MessageBox.Show("Gravar manutenção? \n Valor Total: " + txt_calcTotal.Text, "Conferencia!!!", MessageBoxButton.YesNo).ToString();
                if (retorno == "Yes")
                {
                    try
                    {
                        db_manu_log _abast = new db_manu_log();

                        _abast.Desconto = txt_calcDesconto.Text;
                        _abast.DT_LANCA = DateTime.UtcNow;
                        _abast.DT_NF = txt_data.Text;
                        _abast.Empresa = Empresa;
                        _abast.FORNECEDOR = cmb_fornecedor.Text;
                        _abast.km_manutencao = txt_km.Text;
                        _abast.MOTORISTA = cmb_motorista.Text;
                        _abast.NR_NF = txt_doc.Text;
                        _abast.PLACA = cmb_veiculo.Text;
                        _abast.VALOR_TT = txt_calcTotal.Text;
                        calcular();
                        AtualizarItens();
                        await Task.Run(() =>
                        {
                            try
                            {
                                db.db_manu_log.InsertOnSubmit(_abast);
                                db.db_manu.InsertAllOnSubmit(pecaslista);
                                db.SubmitChanges();
                                Application.Current.Dispatcher.Invoke((Action)delegate
                                {
                                    mensagem("Manutenção gravada com sucesso!", false, "", "Ok");


                                    btn_novo.Content = "Novo";
                                    carregando(0, true);
                                });
                            }
                            catch
                            {
                                Application.Current.Dispatcher.Invoke((Action)delegate
                                {
                                    mensagem("Obtivemos algum erro ao gravar a manutenção! Revise os campos e tente novamente! \n Caso persista entre em contato com: " + cfg.Email_Dev, false, "", "Ok");
                                });
                            }

                        });
                    }
                    catch
                    {
                        mensagem("Obtivemos algum erro ao gravar a manutenção! Revise os campos e tente novamente! \n Caso persista entre em contato com: " + cfg.Email_Dev, false, "", "Ok");

                    }
                }
            }
        }
        private async void _btn_alterar()
        {
            String retorno = MessageBox.Show("Deseja alterar esta manuteção?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
            if (retorno == "Yes")
            {
                db_manu_log _abast = await Task.FromResult<db_manu_log>(db.db_manu_log.Where(a => a.COD == ID).FirstOrDefault());

                _abast.Desconto = txt_calcDesconto.Text;
                _abast.DT_LANCA = DateTime.UtcNow;
                _abast.DT_NF = txt_data.Text;
                _abast.Empresa = Empresa;
                _abast.FORNECEDOR = cmb_fornecedor.Text;
                _abast.km_manutencao = txt_km.Text;
                _abast.MOTORISTA = cmb_motorista.Text;
                _abast.NR_NF = txt_doc.Text;
                _abast.PLACA = cmb_veiculo.Text;
                _abast.VALOR_TT = txt_calcTotal.Text;
                AtualizarItens();
                await Task.Run(() =>
                 {
                     try
                     {
                         db.SubmitChanges();
                         Application.Current.Dispatcher.Invoke((Action)delegate
                         {
                             mensagem("Manutenção gravada com sucesso!", false, "", "Ok");

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
        private async void _btn_deletar()
        {
            string retorno = MessageBox.Show("Deseja apagar esta manutenção?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
            if (retorno == "Yes")
            {
                try
                {
                    db_manu_log abast = await Task.FromResult<db_manu_log>(db.db_manu_log.Where(a => a.COD == ID).FirstOrDefault());
                    db.db_manu_log.DeleteOnSubmit(abast);
                    db.db_manu.DeleteAllOnSubmit(pecaslista);
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
            txt_calcDesconto.Text = "";
            txt_calcTotal.Text = "";
            txt_data.Text = "";
            txt_doc.Text = "";
            txt_itemDesconto.Text = "";
            txt_itemQuant.Text = "";
            txt_itemValor.Text = "";
            txt_km.Text = "";
            txt_ProgrmadoObs.Text = "";
            txt_progrmadoKm.Text = "";

            cmb_fornecedor.Text = "";
            cmb_ItemDesc.Text = "";
            cmb_motorista.Text = "";
            cmb_veiculo.Text = "";

        }
        private void preencher(db_manu listamanu, db_manu_log logmanu)
        {
            Limpar();
            txt_calcDesconto.Text = "";
            txt_calcTotal.Text = "";
            txt_data.Text = logmanu.DT_NF;
            txt_doc.Text = logmanu.NR_NF;
            txt_itemDesconto.Text = listamanu.DESCONTO;
            txt_itemQuant.Text = listamanu.QUANTIDADE;
            txt_itemValor.Text = listamanu.VALOR;
            txt_km.Text = logmanu.km_manutencao;
            if (listamanu.MProgramada == "Programada")
            {
                txt_ProgrmadoObs.Text = listamanu.M_OBS_Programada;
                txt_progrmadoKm.Text = listamanu.M_Km_Programada;
            }

            cmb_fornecedor.Text = logmanu.FORNECEDOR;
            cmb_ItemDesc.Text = listamanu.DESCRICAO;
            cmb_motorista.Text = logmanu.MOTORISTA;
            cmb_veiculo.Text = logmanu.PLACA;


        }
        private async void carregando(int cod, bool full)
        {
            try
            {

                if (cod == 0)
                {
                    manulog = await Task.FromResult<db_manu_log>(db.db_manu_log.Where(a => a.Empresa == Empresa).OrderByDescending(a => a.COD).FirstOrDefault());
                }
                else
                {
                    manulog = await Task.FromResult<db_manu_log>(db.db_manu_log.Where(a => a.Empresa == Empresa).Where(a => a.COD == cod).FirstOrDefault());

                }
                try
                {
                    pecaslista = await Task.FromResult<List<db_manu>>(db.db_manu.Where(a => a.Empresa == Empresa).Where(a => a.NR_NF == manulog.COD.ToString("00000#")).ToList());
                    carregar(manulog, pecaslista[0]);
                }
                catch
                {
                    pecaslista = await Task.FromResult<List<db_manu>>(db.db_manu.Where(a => a.Empresa == Empresa).Where(a => a.NR_NF == manulog.COD.ToString("#")).ToList());
                    carregar(manulog, pecaslista[0]);
                }
                ID = manulog.COD;
                PecaId = 0;

                ultimas = new List<Ultimas>();
                for (int i = 0; i < pecaslista.Count; i++)
                {
                    Ultimas ult = new Ultimas();

                    ult.ID = i;
                    ult.Desconto = pecaslista[i].DESCONTO;
                    ult.Descrição = pecaslista[i].DESCRICAO;
                    ult.Quant = pecaslista[i].QUANTIDADE;
                    ult.Total = pecaslista[i].VALOR;
                    ultimas.Add(ult);

                }
                grid_itens.ItemsSource = ultimas;
                calcular();


            }
            catch
            {
                btn_novo.Content = "Gravar";
            }
        }
        private void carregar(db_manu_log log, db_manu _db_manu)
        {
            preencher(_db_manu, log);


        }
        private async void btn_pesquisar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string dt = txt_pes_data.Text;
            string doc = txt_pes_doc.Text;
            string fornecedor = txt_pes_fornecedor.Text;//
            string motorista = txt_pes_motorista.Text;//
            string km = txt_pes_kmmanute.Text;//
            string placa = txt_pes_placa.Text;//
            string peca = txt_pes_pecaservico.Text;//

            if (rad_contem.IsChecked == true)
            {
                Listpesquisa = await Task.FromResult<List<db_manu>>(db.db_manu.Where(a => a.Empresa == Empresa)
                    .Where(a => a.DT_NF.Contains(dt)).Where(a => a.NR_NF.Contains(doc)).Where(a => a.FORNECEDOR.Contains(fornecedor))
                    .Where(a => a.MOTORISTA.Contains(motorista)).Where(a => a.KM_MANUTENCAO.Contains(km)).Where(a => a.VEICULO.Contains(placa))
                   .Where(a => a.DESCRICAO.Contains(peca)).OrderByDescending(a => a.COD).ToList());

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
        private void btn_mais_Click(object sender, RoutedEventArgs e)
        {
            txt_itemDesconto.Text = "";
            txt_itemQuant.Text = "";
            txt_itemValor.Text = "";
            cmb_ItemDesc.Text = "";
            txt_progrmadoKm.Text = "";
            txt_ProgrmadoObs.Text = "";
            chq_programada.IsChecked = false;
            CheqTeste();
            cmb_ItemDesc.Focus();
            PecaId = -1;
        }
        private void CheqTeste()
        {
            if (chq_programada.IsChecked == true)
            {
                _manutprogramada.Visibility = Visibility.Visible;
            }
            else
            {
                _manutprogramada.Visibility = Visibility.Hidden;
            }
        }
        private void btn_itemAdd_Click(object sender, RoutedEventArgs e)
        {
            if (PecaId == -1)
            {


                try
                {
                    peca = new db_manu();
                    peca.DESCONTO = txt_itemDesconto.Text;
                    peca.DESCRICAO = cmb_ItemDesc.Text;
                    peca.DT_LANCA = DateTime.Now;
                    peca.DT_NF = txt_data.Text;
                    peca.Empresa = Empresa;
                    peca.FORNECEDOR = cmb_fornecedor.Text;
                    peca.KM_MANUTENCAO = txt_km.Text;
                    peca.MOTORISTA = cmb_motorista.Text;
                    if (chq_programada.IsChecked == true)
                    {
                        peca.MProgramada = "Sim";
                        peca.M_Km_Programada = txt_progrmadoKm.Text;
                        peca.M_OBS_Programada = txt_ProgrmadoObs.Text;
                    }
                    try
                    {
                        peca.NR_LANCA = manulog.NR_NF;
                        peca.NR_NF = manulog.COD.ToString();
                        peca.QUANTIDADE = txt_itemQuant.Text;
                        peca.VALOR = txt_itemValor.Text;
                        peca.VEICULO = cmb_veiculo.Text;
                    }
                    catch
                    {
                        peca.NR_LANCA = "";
                        peca.NR_NF = "";
                        peca.QUANTIDADE = txt_itemQuant.Text;
                        peca.VALOR = txt_itemValor.Text;
                        peca.VEICULO = cmb_veiculo.Text;
                    }
                    Novaspecaslista.Add(peca);
                    Ultimas ultimas1 = new Ultimas();
                    ultimas1.ID = ultimas.Count + 1;
                    ultimas1.Desconto = txt_itemDesconto.Text;
                    ultimas1.Descrição = cmb_ItemDesc.Text;
                    ultimas1.Quant = txt_itemQuant.Text;
                    ultimas1.Total = txt_itemValor.Text;
                    ultimas.Add(ultimas1);
                    grid_itens.ItemsSource = null;
                    grid_itens.ItemsSource = ultimas;

                    mensagem("Peça/Serviço adicionado com sucesso!", false, "", "Ok");

                }
                catch
                {
                    mensagem("Erro ao adicionar peça/serviço!", false, "", "Ok");
                }
            }
            else
            {
                try
                {
                    pecaslista[PecaId].DESCONTO = txt_itemDesconto.Text;
                    pecaslista[PecaId].DESCRICAO = cmb_ItemDesc.Text;
                    pecaslista[PecaId].DT_LANCA = DateTime.Now;
                    pecaslista[PecaId].DT_NF = txt_data.Text;
                    pecaslista[PecaId].Empresa = Empresa;
                    pecaslista[PecaId].FORNECEDOR = cmb_fornecedor.Text;
                    pecaslista[PecaId].KM_MANUTENCAO = txt_km.Text;
                    pecaslista[PecaId].MOTORISTA = cmb_motorista.Text;
                    if (chq_programada.IsChecked == true)
                    {
                        pecaslista[PecaId].MProgramada = "Sim";
                        pecaslista[PecaId].M_Km_Programada = txt_progrmadoKm.Text;
                        pecaslista[PecaId].M_OBS_Programada = txt_ProgrmadoObs.Text;
                    }
                    try
                    {
                        pecaslista[PecaId].NR_LANCA = manulog.NR_NF;
                        pecaslista[PecaId].NR_NF = manulog.COD.ToString();
                        pecaslista[PecaId].QUANTIDADE = txt_itemQuant.Text;
                        pecaslista[PecaId].VALOR = txt_itemValor.Text;
                        pecaslista[PecaId].VEICULO = cmb_veiculo.Text;
                    }
                    catch
                    {
                        pecaslista[PecaId].NR_LANCA = "";
                        pecaslista[PecaId].NR_NF = "";
                        pecaslista[PecaId].QUANTIDADE = txt_itemQuant.Text;
                        pecaslista[PecaId].VALOR = txt_itemValor.Text;
                        pecaslista[PecaId].VEICULO = cmb_veiculo.Text;
                    }
                    ultimas[PecaId].Desconto = txt_itemDesconto.Text;
                    ultimas[PecaId].Descrição = cmb_ItemDesc.Text;
                    ultimas[PecaId].Quant = txt_itemQuant.Text;
                    ultimas[PecaId].Total = txt_itemValor.Text;
                    grid_itens.ItemsSource = null;
                    grid_itens.ItemsSource = ultimas;

                    mensagem("Peça/Serviço alterada com sucesso!", false, "", "Ok");

                }
                catch
                {
                    mensagem("Erro ao alterar peça/serviço!", false, "", "Ok");
                }
            }
        }
        private void btn_itemExcluir_Click(object sender, RoutedEventArgs e)
        {
            if (PecaId == -1)
            {

            }
            else
            {
                Excluirpecaslista.Add(pecaslista[PecaId]);
                ultimas.Remove(ultimas[PecaId]);
                pecaslista.Remove(pecaslista[PecaId]);
                grid_itens.ItemsSource = null;
                grid_itens.ItemsSource = ultimas;
            }
        }
        private void txt_data_LostFocus(object sender, RoutedEventArgs e)
        {
            setData(sender, e);
        }
        private void txt_calcDesconto_LostFocus(object sender, RoutedEventArgs e)
        {
            setValor(sender, e);
        }
        private void txt_calcTotal_LostFocus(object sender, RoutedEventArgs e)
        {
            setValor(sender, e);
        }
        private void txt_itemDesconto_LostFocus(object sender, RoutedEventArgs e)
        {
            setValor(sender, e);
        }
        private void txt_itemValor_LostFocus(object sender, RoutedEventArgs e)
        {
            setValor(sender, e);
        }
        private void AtualizarItens()
        {
            try
            {
                for (int i = 0; i < pecaslista.Count; i++)
                {
                    peca = pecaslista[i];
                    pecaslista[i].DESCRICAO = cmb_ItemDesc.Text;
                    pecaslista[i].DT_LANCA = DateTime.Now;
                    pecaslista[i].DT_NF = txt_data.Text;
                    pecaslista[i].Empresa = Empresa;
                    pecaslista[i].FORNECEDOR = cmb_fornecedor.Text;
                    pecaslista[i].KM_MANUTENCAO = txt_km.Text;
                    pecaslista[i].MOTORISTA = cmb_motorista.Text;
                    try
                    {
                        pecaslista[i].NR_LANCA = manulog.NR_NF;
                        pecaslista[i].NR_NF = manulog.COD.ToString();
                        pecaslista[i].VEICULO = cmb_veiculo.Text;
                    }
                    catch
                    {
                        pecaslista[i].NR_LANCA = "";
                        pecaslista[i].NR_NF = "";
                        pecaslista[i].VEICULO = cmb_veiculo.Text;
                    }

                }
            }
            catch
            {

            }
            try
            {
                for (int i = 0; i < Novaspecaslista.Count; i++)
                {
                    peca = Novaspecaslista[i];
                    Novaspecaslista[i].DESCRICAO = cmb_ItemDesc.Text;
                    Novaspecaslista[i].DT_LANCA = DateTime.Now;
                    Novaspecaslista[i].DT_NF = txt_data.Text;
                    Novaspecaslista[i].Empresa = Empresa;
                    Novaspecaslista[i].FORNECEDOR = cmb_fornecedor.Text;
                    Novaspecaslista[i].KM_MANUTENCAO = txt_km.Text;
                    Novaspecaslista[i].MOTORISTA = cmb_motorista.Text;
                    try
                    {
                        Novaspecaslista[i].NR_LANCA = manulog.NR_NF;
                        Novaspecaslista[i].NR_NF = manulog.COD.ToString();
                        Novaspecaslista[i].VEICULO = cmb_veiculo.Text;
                    }
                    catch
                    {
                        Novaspecaslista[i].NR_LANCA = "";
                        Novaspecaslista[i].NR_NF = "";
                        Novaspecaslista[i].VEICULO = cmb_veiculo.Text;
                    }

                }
            }
            catch
            {

            }
        }
        private void calcular()
        {
            try
            {
                double desconto = 0;
                double total = 0;
                double desc1 = 0;
                double quant = 0;
                double val = 0;


                for (int i = 0; i < pecaslista.Count; i++)
                {
                    desc1 = 0;
                    quant = 0;
                    val = 0;
                    double.TryParse(pecaslista[i].DESCONTO.Replace("R$ ", ""), out desc1);
                    double.TryParse(pecaslista[i].QUANTIDADE.Replace("R$ ", ""), out quant);
                    double.TryParse(pecaslista[i].VALOR.Replace("R$ ",""), out val);
                    desconto += desc1 * quant;
                    total +=val* quant;
                    
                }
                txt_calcDesconto.Text = desconto.ToString("N2");
                txt_calcTotal.Text = total.ToString("N2");
                for (int f = 0; f < Novaspecaslista.Count; f++)
                {
                    double.TryParse(Novaspecaslista[f].DESCONTO.Replace("R$ ", ""), out desc1);
                    double.TryParse(Novaspecaslista[f].QUANTIDADE.Replace("R$ ", ""), out quant);
                    double.TryParse(Novaspecaslista[f].VALOR.Replace("R$ ", ""), out val);
                    desconto += desc1 * quant;
                    total += val * quant;
                }
                txt_calcDesconto.Text = desconto.ToString("N2");
                txt_calcTotal.Text = total.ToString("N2");
            }
            catch
            {

            }
        }
    }

}
