using dbAcessos;
using GTManute.Properties;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
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



        private Settings cfg = new Settings();
        List<db_abast> Listpesquisa = new List<db_abast>();
        private string Empresa { get; set; }
        dbManuteDataContext db = new dbManuteDataContext();
        public View_Abast()
        {
            InitializeComponent();
            Empresa = cfg.Empresa;
            carregar(0);
        }

        protected override void OnMouseLeftButtonDown(MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);

            // Begin dragging the window
            this.DragMove();
        }

        private async void btn_novo_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private async void btn_alterar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }

        private async void btn_delete_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

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
            grid_ultimas.ItemsSource = null;

        }
        private void preencher(string despAlimentacao, string despPernoite, string doc, string dtdestino, string dtpartida,
            string hrdestino, string hrpartida, string kmdestino, string kmpartida, string litragem, string outrasdesp, string valor,
            List<Ultimas> gridUltimas, string ajudante1, string ajudante2, string destino, string fornecedor, string motorista,
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

            grid_ultimas.ItemsSource = gridUltimas;
        }
        private async void carregar(int cod)
        {
            db_abast abast = new db_abast();
            if (cod == 0)
            {
                abast = await Task.FromResult<db_abast>(db.db_abast.Where(a => a.Empresa == Empresa).OrderByDescending(a => a.ID).FirstOrDefault());
            }
            else
            {
               abast = await Task.FromResult<db_abast>(db.db_abast.Where(a => a.Empresa == Empresa).Where(a=>a.ID==cod).FirstOrDefault());
            }
           
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

            preencher(abast.DESPESA_ALI, abast.DESPESA_PERN, abast.N_DOC, abast.DT_CHEGADA,
                abast.DT_PARTIDA, abast.HORA_CHEGADA, abast.HORA_PARTIDA, abast.KM_CHEGADA, abast.KM_PARTIDA,
                abast.LITRAGEM, abast.DESPESA_OUTRAS, abast.VALOR_TOTAL, ultimas, abast.AJUDANTE1, abast.AJUDANTE2, abast.PARA, abast.FORNECEDOR, abast.MOTORISTA, abast.DE, abast.PLACA);
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
                carregar(Listpesquisa[dt_pesquisa.SelectedIndex].ID);
            }
            catch
            {

            }
        }

        private void dt_pesquisa_CurrentCellChanged(object sender, System.EventArgs e)
        {
           
        }
    }
}
