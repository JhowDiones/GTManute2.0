
namespace dbAcessos
{
    partial class banco_controle
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_source = new System.Windows.Forms.TextBox();
            this.txt_catalogo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_id_banco = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_senhabanco = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_empresa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_senhaempresa = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_gravar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Data Source";
            // 
            // txt_source
            // 
            this.txt_source.Location = new System.Drawing.Point(13, 26);
            this.txt_source.Name = "txt_source";
            this.txt_source.Size = new System.Drawing.Size(216, 20);
            this.txt_source.TabIndex = 1;
            // 
            // txt_catalogo
            // 
            this.txt_catalogo.Location = new System.Drawing.Point(12, 73);
            this.txt_catalogo.Name = "txt_catalogo";
            this.txt_catalogo.Size = new System.Drawing.Size(216, 20);
            this.txt_catalogo.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Catálogo";
            // 
            // txt_id_banco
            // 
            this.txt_id_banco.Location = new System.Drawing.Point(12, 125);
            this.txt_id_banco.Name = "txt_id_banco";
            this.txt_id_banco.Size = new System.Drawing.Size(216, 20);
            this.txt_id_banco.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "ID Banco";
            // 
            // txt_senhabanco
            // 
            this.txt_senhabanco.Location = new System.Drawing.Point(12, 177);
            this.txt_senhabanco.Name = "txt_senhabanco";
            this.txt_senhabanco.PasswordChar = '*';
            this.txt_senhabanco.Size = new System.Drawing.Size(216, 20);
            this.txt_senhabanco.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Senha Banco";
            // 
            // txt_empresa
            // 
            this.txt_empresa.Location = new System.Drawing.Point(12, 229);
            this.txt_empresa.Name = "txt_empresa";
            this.txt_empresa.Size = new System.Drawing.Size(216, 20);
            this.txt_empresa.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(11, 212);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Empresa";
            // 
            // txt_senhaempresa
            // 
            this.txt_senhaempresa.Location = new System.Drawing.Point(12, 280);
            this.txt_senhaempresa.Name = "txt_senhaempresa";
            this.txt_senhaempresa.PasswordChar = '*';
            this.txt_senhaempresa.Size = new System.Drawing.Size(216, 20);
            this.txt_senhaempresa.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 263);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Contra senha";
            // 
            // btn_gravar
            // 
            this.btn_gravar.Location = new System.Drawing.Point(81, 318);
            this.btn_gravar.Name = "btn_gravar";
            this.btn_gravar.Size = new System.Drawing.Size(75, 23);
            this.btn_gravar.TabIndex = 12;
            this.btn_gravar.Text = "Gravar";
            this.btn_gravar.UseVisualStyleBackColor = true;
            this.btn_gravar.Click += new System.EventHandler(this.btn_gravar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 318);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Testar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // banco_controle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 356);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_gravar);
            this.Controls.Add(this.txt_senhaempresa);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_empresa);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_senhabanco);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_id_banco);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_catalogo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_source);
            this.Controls.Add(this.label1);
            this.Name = "banco_controle";
            this.Text = "Controle do banco";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.banco_controle_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_source;
        private System.Windows.Forms.TextBox txt_catalogo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_id_banco;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_senhabanco;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_empresa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txt_senhaempresa;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_gravar;
        private System.Windows.Forms.Button button1;
    }
}