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
    public partial class View_Frota : Window
    {
        private class Ultimas
        {
            public string Motorista { get; set; }
            public string KmRodado { get; set; }
            public string Média { get; set; }
            public string DTPartida { get; set; }
        }


        private string Usuario { get; set; }
        private Settings cfg = new Settings();
        private int ID { get; set; }
        List<db_frota> Listpesquisa = new List<db_frota>();
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext();
        public View_Frota()
        {
            InitializeComponent();
            Empresa = cfg.Empresa;
            try
            {
                carregando(0, true);
            }
            catch
            {

            }
            
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
            vs.Add("Carro");
            vs.Add("Motocicleta");
            vs.Add("Triciclo");
            vs.Add("Caminhão");
            vs.Add("Cavalo");
            vs.Add("Impemento");
            cmb_tipoVeiculo.ItemsSource = vs;
            List<string> trans = new List<string>();
            trans.Add("Automatico");
            trans.Add("Semi-Automatico");
            trans.Add("Manual");
           
            cmb_transmissao.ItemsSource = trans;
        }
        private void Limpar()
        {
            txt_ano.Text = "";
            txt_chassis.Text = "";
            txt_cor.Text = "";
            txt_eixos.Text = "";
            txt_marca.Text = "";
            txt_modelo.Text = "";
            txt_placa.Text = "";
            txt_potencia.Text = "";
            txt_p_1.Text = "";
            txt_p_2.Text = "";
            txt_p_3.Text = "";
            txt_p_4.Text = "";
            txt_p_5.Text = "";
            txt_p_6.Text = "";
            txt_p_estepe.Text = "";
            txt_renavan.Text = "";
            cmb_tipoVeiculo.Text = "";
            cmb_transmissao.Text = "";

        }
        private void preencher(string ano, string chassis, string cor, string eixos, string marca, string modelo, 
            string placa, string potencia, string p1, string p2, string p3, string p4, string p5, string p6, string pestepe,
           string renavan, string tipoveiculo, string transmissao)
        {
            Limpar();
            txt_ano.Text = ano;
            txt_chassis.Text = chassis;
            txt_cor.Text = cor;
            txt_eixos.Text = eixos;
            txt_marca.Text = marca;
            txt_modelo.Text = modelo;
            txt_placa.Text = placa;
            txt_potencia.Text = potencia;
            txt_p_1.Text = p1;
            txt_p_2.Text = p2;
            txt_p_3.Text = p3;
            txt_p_4.Text = p4;
            txt_p_5.Text = p5;
            txt_p_6.Text = p6;
            txt_p_estepe.Text = pestepe;
            txt_renavan.Text = renavan;
            cmb_tipoVeiculo.Text = tipoveiculo;
            cmb_transmissao.Text = transmissao;

            eixosLoad();

        }

        private async void carregando(int cod, bool full)
        {
            db_frota frota = new db_frota();
            if (cod == 0)
            {
                frota = await Task.FromResult<db_frota>(db.db_frota.Where(a => a.Empresa == Empresa).OrderByDescending(a => a.COD).FirstOrDefault());
            }
            else
            {
                frota = await Task.FromResult<db_frota>(db.db_frota.Where(a => a.Empresa == Empresa).Where(a => a.COD == cod).FirstOrDefault());
            }
            ID = frota.COD;
            List<db_abast> Listaabast = await Task.FromResult<List<db_abast>>(db.db_abast.Where(a => a.Empresa == Empresa).Where(a => a.PLACA == frota.PLACA).OrderByDescending(a => a.ID).Take(5).ToList());

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

        private void carregar(db_frota abast)
        {


            preencher(abast.ANO_FAB, abast.CHASSIS, abast.COR, abast.EIXOS, abast.MARCA, abast.MODELO, abast.PLACA,
                abast.POTENCIA, abast.P1, abast.P2, abast.P3, abast.P4,abast.P5,abast.P6, abast.PESTEPE,abast.RENAVAN,abast.TIPO_FROTA,abast.TIPO_CARRO);


        }
        private async void btn_pesquisar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string chassis = txt_pes_chassis.Text;
            string cor = txt_pes_cor.Text;
            string marca = txt_pes_marca.Text;//
            string modelo = txt_pes_modelo.Text;//
            string placa = txt_pes_placa.Text;//
            string renavan = txt_pes_renavan.Text;//

            if (rad_contem.IsChecked == true)
            {
                Listpesquisa = await Task.FromResult<List<db_frota>>(db.db_frota.Where(a => a.Empresa == Empresa)
                    .Where(a => a.CHASSIS.Contains(chassis)).Where(a => a.COR.Contains(cor)).Where(a => a.MARCA.Contains(marca))
                    .Where(a => a.MODELO.Contains(modelo)).Where(a => a.PLACA.Contains(placa)).Where(a => a.RENAVAN.Contains(renavan))
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
                    db_frota forn = await Task.FromResult<db_frota>(db.db_frota.Where(a => a.COD == ID).FirstOrDefault());
                    db.db_frota.DeleteOnSubmit(forn);
                    db.SubmitChanges();
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
               
                string retorno = MessageBox.Show("Gravar cadastro?" , "Conferencia!!!", MessageBoxButton.YesNo).ToString();
                if (retorno == "Yes")
                {
                    try
                    {
                        db_frota _abast = new db_frota();

                        _abast.ANO_FAB = txt_ano.Text;
                        _abast.CHASSIS = txt_chassis.Text;
                        _abast.COR = txt_cor.Text;
                        _abast.DT_LANCA = DateTime.Now;
                        _abast.EIXOS = txt_eixos.Text;
                        _abast.Empresa = Empresa;
                        _abast.MARCA = txt_marca.Text;
                        _abast.MODELO = txt_modelo.Text;
                        _abast.PLACA = txt_placa.Text;
                        _abast.POTENCIA = txt_potencia.Text;
                        _abast.P1 = txt_p_1.Text;
                        _abast.P2 = txt_p_2.Text;
                        _abast.P3 = txt_p_3.Text;
                        _abast.P4 = txt_p_4.Text;
                        _abast.P5 = txt_p_5.Text;
                        _abast.P6 = txt_p_6.Text;
                        _abast.PESTEPE = txt_p_estepe.Text;
                        _abast.RENAVAN = txt_renavan.Text;
                        _abast.TIPO_FROTA = cmb_tipoVeiculo.Text;
                        _abast.TIPO_CARRO = cmb_transmissao.Text;

                        _abast.USUARIO = "";


                        await Task.Run(() =>
                        {
                            try
                            {
                                db.db_frota.InsertOnSubmit(_abast);
                                db.SubmitChanges();
                                Application.Current.Dispatcher.Invoke((Action)delegate {
                                    mensagem("Cadastro gravado com sucesso!", false, "", "Ok");
                                
                                
                                btn_novo.Text = "Novo";
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
                        mensagem("Obtivemos algum erro ao gravar o cadastro! Revise os campos e tente novamente! \n Caso persista entre em contato com: " + cfg.Email_Dev, false, "", "Ok");

                    }
                }
            }
        }

        private async void btn_alterar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            string retorno = MessageBox.Show("Deseja alterar este cadastro?", "Conferencia!!!", MessageBoxButton.YesNo).ToString();
            if (retorno == "Yes")
            {
                db_frota _abast = await Task.FromResult<db_frota>(db.db_frota.Where(a => a.COD == ID).FirstOrDefault());


                _abast.ANO_FAB = txt_ano.Text;
                _abast.CHASSIS = txt_chassis.Text;
                _abast.COR = txt_cor.Text;
                _abast.DT_LANCA = DateTime.Now;
                _abast.EIXOS = txt_eixos.Text;
                _abast.Empresa = Empresa;
                _abast.MARCA = txt_marca.Text;
                _abast.MODELO = txt_modelo.Text;
                _abast.PLACA = txt_placa.Text;
                _abast.POTENCIA = txt_potencia.Text;
                _abast.P1 = txt_p_1.Text;
                _abast.P2 = txt_p_2.Text;
                _abast.P3 = txt_p_3.Text;
                _abast.P4 = txt_p_4.Text;
                _abast.P5 = txt_p_5.Text;
                _abast.P6 = txt_p_6.Text;
                _abast.PESTEPE = txt_p_estepe.Text;
                _abast.RENAVAN = txt_renavan.Text;
                _abast.TIPO_FROTA = cmb_tipoVeiculo.Text;
                _abast.TIPO_CARRO = cmb_transmissao.Text;



                await Task.Run(() =>
                {
                    try
                    {
                        db.SubmitChanges();
                        Application.Current.Dispatcher.Invoke((Action)delegate {
                            mensagem("Veículo gravado com sucesso!", false, "", "Ok");
                       
                        
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

        private void txt_eixos_LostFocus(object sender, RoutedEventArgs e)
        {
            eixosLoad();
        }
        private void eixosLoad()
        {
            if (txt_eixos.Text == "2")
            {
                txt_p_3.Visibility = Visibility.Hidden;
                txt_p_4.Visibility = Visibility.Hidden;
                txt_p_5.Visibility = Visibility.Hidden;
                txt_p_6.Visibility = Visibility.Hidden;

                labeleixo3.Visibility = Visibility.Hidden;
                labeleixo4.Visibility = Visibility.Hidden;
                labeleixo5.Visibility = Visibility.Hidden;
                labeleixo6.Visibility = Visibility.Hidden;

                grid_eixos.Visibility = Visibility.Visible;
            }
            if (txt_eixos.Text == "1")
            {
                txt_p_2.Visibility = Visibility.Hidden;
                txt_p_3.Visibility = Visibility.Hidden;
                txt_p_4.Visibility = Visibility.Hidden;
                txt_p_5.Visibility = Visibility.Hidden;
                txt_p_6.Visibility = Visibility.Hidden;


                labeleixo2.Visibility = Visibility.Hidden;
                labeleixo3.Visibility = Visibility.Hidden;
                labeleixo4.Visibility = Visibility.Hidden;
                labeleixo5.Visibility = Visibility.Hidden;
                labeleixo6.Visibility = Visibility.Hidden;
                grid_eixos.Visibility = Visibility.Visible;
            }
            else if (txt_eixos.Text == "3")
            {
                txt_p_4.Visibility = Visibility.Hidden;
                txt_p_5.Visibility = Visibility.Hidden;
                txt_p_6.Visibility = Visibility.Hidden;
                labeleixo4.Visibility = Visibility.Hidden;
                labeleixo5.Visibility = Visibility.Hidden;
                labeleixo6.Visibility = Visibility.Hidden;
                grid_eixos.Visibility = Visibility.Visible;
            }
            else if (txt_eixos.Text == "4")
            {
                txt_p_5.Visibility = Visibility.Hidden;
                txt_p_6.Visibility = Visibility.Hidden;
                labeleixo5.Visibility = Visibility.Hidden;
                labeleixo6.Visibility = Visibility.Hidden;
                grid_eixos.Visibility = Visibility.Visible;
            }
            else if (txt_eixos.Text == "5")
            {
                txt_p_6.Visibility = Visibility.Hidden;
                labeleixo6.Visibility = Visibility.Hidden;
                grid_eixos.Visibility = Visibility.Visible;
            }
            else if (txt_eixos.Text == "6")
            {
                grid_eixos.Visibility = Visibility.Visible;
            }
            else
            {

            }
        }
    }
}
