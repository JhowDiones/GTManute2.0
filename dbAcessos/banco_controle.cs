using dbAcessos.Properties;
using System;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dbAcessos
{
    public partial class banco_controle : Form
    {
        private Settings cfg = new Settings();
        dbManuteDataContext db = new dbManuteDataContext();
        public banco_controle()
        {
            InitializeComponent();
            txt_catalogo.Text = cfg.catalogo;
            txt_empresa.Text = cfg.empresa;
            txt_id_banco.Text = cfg.id;
            txt_senhabanco.Text = cfg.senha;
            txt_senhaempresa.Text = cfg.senhaempresa;
            txt_source.Text = cfg.dtSource;
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            AlterarBD();
        }
        private async void AlterarBD()
        {
            try
            {
                cfg.catalogo = txt_catalogo.Text;
                cfg.dtSource = txt_source.Text;
                cfg.id = txt_id_banco.Text;
                cfg.senha = txt_senhabanco.Text;
                cfg.senhaempresa = txt_senhaempresa.Text;
                cfg.empresa = txt_empresa.Text;
                cfg.Save();
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var connectionStringsSection = (ConnectionStringsSection)config.GetSection("conexao");
                connectionStringsSection.ConnectionStrings["Connection"].ConnectionString = "Data Source="+txt_source.Text+";Initial Catalog="+txt_catalogo.Text+";Persist Security Info=True;User ID="+txt_id_banco+";Password="+txt_senhabanco.Text;
                config.Save();
                ConfigurationManager.RefreshSection("conexao");
            }
            catch
            {

            }

        }

        private void banco_controle_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                AlterarBD();
                db_empresas resultado = db.db_empresas.Where(a => a.ContraSenha == txt_senhaempresa.Text).Where(a => a.Empresa == int.Parse(txt_empresa.Text)).First();
                if (resultado.Empresa == int.Parse(txt_empresa.Text))
                {
                    MessageBox.Show("Configurado com sucesso!");
                    button1.BackColor = Color.Green;

                }
                else
                {
                    MessageBox.Show("Erro ao não identificado!");
                    button1.BackColor = Color.Orange;
                }
            }
            catch
            {
                MessageBox.Show("Erro ao configurar!");
                button1.BackColor = Color.Red;
            }
        }
    }
}
