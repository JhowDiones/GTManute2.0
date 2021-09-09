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
            public string ValorItem { get; set; }
        }
        List<Ultimas> ultimas = new List<Ultimas>();
        private string Usuario { get; set; }
        private GTManute.Properties.Settings cfg = new Properties.Settings();
        private dbAcessos.Properties.Settings cfgdb = new dbAcessos.Properties.Settings();
        List<db_manu> Listpesquisa = new List<db_manu>();
        List<db_manu> pecaslista = new List<db_manu>();
        db_manu peca = new db_manu();
        Addons addons = new Addons();
        private string NF { get; set; }
        private int PecaId { get; set; }
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext("");
        public View_Manut()
        {
            InitializeComponent();
            db = new dbManuteDataContext(addons.NC);

            Empresa = cfgdb.empresa;
            carregando("0", true);
            cmbbox();
            txt_doc.Focus();
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

            //Begin dragging the window
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

            await Task.Run(() =>
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
                Limpar();
                btn_mais1.Visibility = Visibility.Visible;
                ultimas = new List<Ultimas>();
                pecaslista.Clear();
                NF = null;
                grid_itens.ItemsSource = null;
            }
            else
            {
                String retorno = MessageBox.Show("Gravar manutenção? \n Valor Total: " + txt_calcTotal.Text, "Conferencia!!!", MessageBoxButton.YesNo).ToString();
                if (retorno == "Yes")
                {
                    try
                    {
                        calcular();

                        await Task.Run(() =>
                        {
                            try
                            {
                                AtualizarItens();
                                db.db_manu.InsertAllOnSubmit(pecaslista);
                                db.SubmitChanges();

                                Application.Current.Dispatcher.Invoke((Action)delegate
                                {
                                    mensagem("Manutenção gravada com sucesso!", false, "", "Ok");
                                    btn_mais1.Visibility = Visibility.Hidden;
                                    btn_novo.Content = "Novo";
                                    carregando("0", true);
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
                AtualizarItens();
                await Task.Run(() =>
                 {
                     try
                     {

                        

                         db.SubmitChanges();
                         Application.Current.Dispatcher.Invoke((Action)delegate
                         {
                             mensagem("Manutenção alterada com sucesso!", false, "", "Ok");
                             NF = pecaslista[PecaId].NR_LANCA;
                             carregando(NF, true);
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
                    if (pecaslista.Count > 1)
                    {
                        db.db_manu.DeleteOnSubmit(pecaslista[PecaId]);
                        db.SubmitChanges();
                        Limpar();
                        carregando(NF, true);
                    }
                    else
                    {
                        db.db_manu.DeleteOnSubmit(pecaslista[PecaId]);
                        db.SubmitChanges();
                        Limpar();
                        carregando("0", true);
                    }

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
        private void preencher(db_manu listamanu)
        {
            Limpar();
            txt_calcDesconto.Text = "";
            txt_calcTotal.Text = "";
            txt_data.Text = listamanu.DT_NF;
            txt_doc.Text = listamanu.NR_LANCA;
            txt_itemDesconto.Text = listamanu.DESCONTO;
            txt_itemQuant.Text = listamanu.QUANTIDADE;
            txt_itemValor.Text = listamanu.VALOR;
            txt_km.Text = listamanu.KM_MANUTENCAO;
            if (listamanu.MProgramada == "Programada")
            {
                txt_ProgrmadoObs.Text = listamanu.M_OBS_Programada;
                txt_progrmadoKm.Text = listamanu.M_Km_Programada;
            }

            cmb_fornecedor.Text = listamanu.FORNECEDOR;
            cmb_ItemDesc.Text = listamanu.DESCRICAO;
            cmb_motorista.Text = listamanu.MOTORISTA;
            cmb_veiculo.Text = listamanu.VEICULO;
            calcular();
            btn_novo.Content = "Novo";
        }
        private async void carregando(string NF, bool full)
        {
            try
            {

                if (NF == "0")
                {
                    peca = await Task.FromResult(db.db_manu.Where(a => a.Empresa == Empresa).OrderByDescending(a => a.COD).FirstOrDefault());
                    pecaslista = await Task.FromResult<List<db_manu>>(db.db_manu.Where(a => a.Empresa == Empresa).Where(a => a.NR_LANCA == peca.NR_LANCA).ToList());
                    carregar(pecaslista[0]);
                    NF = pecaslista[0].NR_LANCA;
                    PecaId = 0;
                }
                else
                {
                    try
                    {
                        pecaslista = await Task.FromResult<List<db_manu>>(db.db_manu.Where(a => a.Empresa == Empresa).Where(a => a.NR_LANCA == NF).ToList());
                        carregar(pecaslista[0]);
                        NF = pecaslista[0].NR_LANCA;
                        PecaId = 0;
                    }
                    catch
                    {
                        mensagem("Erro ao carregar!", false, "", "OK");
                    }

                }

                

                ultimas = new List<Ultimas>();
                for (int i = 0; i < pecaslista.Count; i++)
                {
                    Ultimas ult = new Ultimas();

                    ult.ID = i;
                    ult.Desconto = pecaslista[i].DESCONTO;
                    ult.Descrição = pecaslista[i].DESCRICAO;
                    ult.Quant = pecaslista[i].QUANTIDADE;
                    ult.ValorItem = pecaslista[i].VALOR;
                    ultimas.Add(ult);

                }
                grid_itens.ItemsSource = ultimas;
                calcular();


            }
            catch
            {
                grid_itens.ItemsSource = null;
                btn_novo.Content = "Gravar";
                PecaId = -1;
            }
        }
        private void carregar(db_manu _db_manu)
        {
            preencher(_db_manu);


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
                    .Where(a => a.DT_NF.Contains(dt)).Where(a => a.NR_LANCA.Contains(doc)).Where(a => a.FORNECEDOR.Contains(fornecedor))
                    .Where(a => a.MOTORISTA.Contains(motorista)).Where(a => a.KM_MANUTENCAO.Contains(km)).Where(a => a.VEICULO.Contains(placa))
                   .Where(a => a.DESCRICAO.Contains(peca)).OrderByDescending(a => a.COD).ToList());

                dt_pesquisa.ItemsSource = Listpesquisa;

                txt_registros.Text = "Nº de Registros: " + Listpesquisa.Count().ToString();
            }
        }
        private void dt_pesquisa_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                object item = dt_pesquisa.SelectedItem;
                string ID = (dt_pesquisa.SelectedCells[1].Column.GetCellContent(item) as TextBlock).Text;
                carregando(ID, true);

            }
            catch
            {
                object item = dt_pesquisa.SelectedItem;
                string ID = (dt_pesquisa.SelectedCells[1].Column.GetCellContent(item) as TextBox).Text;
                carregando(ID, true);
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
        private async void btn_novo_Click(object sender, RoutedEventArgs e)
        {
            _btn_novo();

        }
        private async void btn_alterar_Click(object sender, RoutedEventArgs e)
        {
            _btn_alterar();

        }
        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            _btn_deletar();
        }
        private void btn_mais_Click(object sender, RoutedEventArgs e)
        {
            btn_mais();
        }
        private void btn_mais()
        {
            peca.Empresa = Empresa;
            peca.DESCONTO = txt_itemDesconto.Text;
            peca.DESCRICAO = txt_itemDesconto.Text;
            peca.DT_LANCA = DateTime.Now;
            peca.DT_NF = txt_data.Text;
            peca.FORNECEDOR = cmb_fornecedor.Text;
            peca.KM_MANUTENCAO = txt_km.Text;
            peca.MOTORISTA = cmb_motorista.Text;
            if (chq_programada.IsChecked == true)
            {
                peca.MProgramada = "Programada";
                peca.M_Km_Programada = txt_progrmadoKm.Text;
                peca.M_OBS_Programada = txt_ProgrmadoObs.Text;
            }
            peca.NR_LANCA = txt_doc.Text;
            peca.NR_NF = txt_doc.Text;
            peca.QUANTIDADE = txt_itemQuant.Text;
            peca.USUARIO = "";
            peca.VALOR = txt_itemValor.Text;
            peca.VEICULO = cmb_veiculo.Text;

            pecaslista.Add(peca);

            txt_itemDesconto.Text = "";
            txt_itemQuant.Text = "";
            txt_itemValor.Text = "";
            cmb_ItemDesc.Text = "";
            txt_progrmadoKm.Text = "";
            txt_ProgrmadoObs.Text = "";
            chq_programada.IsChecked = false;
            CheqTeste();
            cmb_ItemDesc.Focus();
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
                    pecaslista[i].DT_LANCA = DateTime.Now;
                    pecaslista[i].DT_NF = txt_data.Text;
                    pecaslista[i].Empresa = Empresa;
                    pecaslista[i].FORNECEDOR = cmb_fornecedor.Text;
                    pecaslista[i].KM_MANUTENCAO = txt_km.Text;
                    pecaslista[i].MOTORISTA = cmb_motorista.Text;
                    try
                    {
                        pecaslista[i].NR_LANCA = txt_doc.Text;
                        pecaslista[i].NR_NF = txt_doc.Text;
                        pecaslista[i].VEICULO = cmb_veiculo.Text;
                    }
                    catch
                    {
                        pecaslista[i].NR_LANCA = "";
                        pecaslista[i].NR_NF = "";
                        pecaslista[i].VEICULO = cmb_veiculo.Text;
                    }

                }
                if (chq_programada.IsChecked == true)
                {
                    pecaslista[PecaId].MProgramada = "Programada";
                    pecaslista[PecaId].M_Km_Programada = txt_progrmadoKm.Text;
                    pecaslista[PecaId].M_OBS_Programada = txt_ProgrmadoObs.Text;
                    
                }
                pecaslista[PecaId].DESCRICAO = cmb_ItemDesc.Text;
                pecaslista[PecaId].DESCONTO = txt_itemDesconto.Text;
                pecaslista[PecaId].VALOR = txt_itemValor.Text;
                pecaslista[PecaId].QUANTIDADE = txt_itemQuant.Text;
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
                    try
                    {
                        double.TryParse(pecaslista[i].DESCONTO.Replace("R$ ", ""), out desc1);
                    }
                    catch { }
                    double.TryParse(pecaslista[i].QUANTIDADE.Replace("R$ ", ""), out quant);
                    double.TryParse(pecaslista[i].VALOR.Replace("R$ ", ""), out val);
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
        private void chq_programada_Checked(object sender, RoutedEventArgs e)
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
        private void grid_itens_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            try
            {
                object item = grid_itens.SelectedItem;
                string ID = (grid_itens.SelectedCells[0].Column.GetCellContent(item) as TextBlock).Text;
                PecaId = int.Parse(ID);
                cmb_ItemDesc.Text = pecaslista[PecaId].DESCRICAO;
                txt_itemDesconto.Text = pecaslista[PecaId].DESCONTO;
                txt_itemQuant.Text = pecaslista[PecaId].QUANTIDADE;
                txt_itemValor.Text = pecaslista[PecaId].VALOR;
            }
            catch
            {

                try
                {

                    object item = grid_itens.SelectedItem;
                    string ID = (grid_itens.SelectedCells[0].Column.GetCellContent(item) as TextBox).Text;
                    PecaId = int.Parse(ID);
                    cmb_ItemDesc.Text = pecaslista[PecaId].DESCRICAO;
                    txt_itemDesconto.Text = pecaslista[PecaId].DESCONTO;
                    txt_itemQuant.Text = pecaslista[PecaId].QUANTIDADE;
                    txt_itemValor.Text = pecaslista[PecaId].VALOR;
                }
                catch
                {

                }

            }
            cmb_ItemDesc.Focus();
        }
        private void chq_programada_Click(object sender, RoutedEventArgs e)
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

        private async void txt_doc_LostFocus(object sender, RoutedEventArgs e)
        {
            try
            {
                peca = new db_manu();
                peca = await Task.FromResult(db.db_manu.Where(a => a.Empresa == Empresa).Where(a => a.NR_LANCA==txt_doc.Text).FirstOrDefault());
                if (peca.NR_LANCA!=""&& peca.NR_LANCA!=null&&NF==null)
                {
                    NF = peca.NR_LANCA;
                    carregando(NF,true);
                    mensagem("Documento já existente e carregado!", false, "", "Ok");
                }
            }
            catch
            {

            }
        }
    }

}
