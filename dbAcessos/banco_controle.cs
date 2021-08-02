using dbAcessos.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace dbAcessos
{
    public partial class banco_controle : Form
    {
        private Settings cfg = new Settings();
        dbManuteDataContext db = new dbManuteDataContext("");
        bool result = false;
        public banco_controle()
        {
            InitializeComponent();
            txt_catalogo.Text = cfg.catalogo;
            txt_empresa.Text = cfg.empresa;
            txt_id_banco.Text = cfg.id;
            txt_senhabanco.Text = cfg.senha;
            txt_senhaempresa.Text = cfg.senhaempresa;
            txt_source.Text = cfg.dtSource;
            db = new dbManuteDataContext(cfg.conexao);
        }

        private void btn_gravar_Click(object sender, EventArgs e)
        {
            AlterarBD();
            teste();
            if (result == true)
            {
                cfg.empresa = txt_empresa.Text;
                cfg.senhaempresa = txt_senhaempresa.Text;
                cfg.Save();
                this.Close();
               
            }
            else
            {

            }
        }
        private async void AlterarBD()
        {
            try
            {
                cfg.catalogo = txt_catalogo.Text;
                cfg.dtSource = txt_source.Text;
                cfg.id = txt_id_banco.Text;
                cfg.senha = txt_senhabanco.Text;

                
                string banco = "Data Source=" + txt_source.Text + ";Initial Catalog=" + txt_catalogo.Text + ";Persist Security Info=True;User ID=" + txt_id_banco.Text + ";Password=" + txt_senhabanco.Text;
                cfg.conexao = banco;
                cfg.Save();

                db = new dbManuteDataContext(banco);
            }
            catch (Exception m)
            {
                MessageBox.Show("Erro ao configurar banco! " + m.Message);
            }

        }

        private void banco_controle_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            teste();
        }
        private void teste()
        {
            try
            {
                AlterarBD();
                List<db_empresas> lista = db.db_empresas.ToList();

                if (lista.Count >= 1)
                {

                    try
                    {
                        db_empresas resultado = db.db_empresas.Where(a => a.ContraSenha == txt_senhaempresa.Text).Where(a => a.Empresa == int.Parse(txt_empresa.Text)).First();
                        if (resultado.Empresa == int.Parse(txt_empresa.Text))
                        {
                            cfg.NomeEmpresa = resultado.NomeEmpresa;
                            cfg.Save();
                            MessageBox.Show("Testado com sucesso!");
                            button1.BackColor = Color.Green;
                            result = true;
                            

                        }
                        else
                        {
                            MessageBox.Show("Empresa não licenciada no sistema!");
                            button1.BackColor = Color.Orange;
                            result = false;
                        }

                    }
                    catch
                    {
                        MessageBox.Show("Empresa não licenciada no sistema!");
                        button1.BackColor = Color.Orange;
                        result = false;
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao configurar! Nenhuma empresa licenciada, contate o \n Desenvolvedor!");
                    button1.BackColor = Color.Red;
                    result = false;
                }
            }
            catch (Exception m)
            {
                MessageBox.Show("Erro ao configurar!" + m.Message);
                button1.BackColor = Color.Red;
                result = false;
            }

        }

        private void banco_controle_Load(object sender, EventArgs e)
        {

        }
    }
}
