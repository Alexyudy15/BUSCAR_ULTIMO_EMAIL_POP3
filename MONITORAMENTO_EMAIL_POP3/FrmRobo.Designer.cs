
namespace MONITORAMENTO_EMAIL_POP3
{
    partial class FrmRobo
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblEmailHost = new MetroFramework.Controls.MetroLabel();
            this.lblSenhaHost = new MetroFramework.Controls.MetroLabel();
            this.lblEmailDest = new MetroFramework.Controls.MetroLabel();
            this.TxtSenha = new MetroFramework.Controls.MetroTextBox();
            this.txtHost = new MetroFramework.Controls.MetroTextBox();
            this.txtMonitorado = new MetroFramework.Controls.MetroTextBox();
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.lblCorpo = new MetroFramework.Controls.MetroLabel();
            this.lblAssunto = new MetroFramework.Controls.MetroLabel();
            this.txtCorpo = new MetroFramework.Controls.MetroLabel();
            this.txtAssunto = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // lblEmailHost
            // 
            this.lblEmailHost.AutoSize = true;
            this.lblEmailHost.Location = new System.Drawing.Point(13, 91);
            this.lblEmailHost.Name = "lblEmailHost";
            this.lblEmailHost.Size = new System.Drawing.Size(78, 19);
            this.lblEmailHost.TabIndex = 0;
            this.lblEmailHost.Text = "E-mail host:";
            // 
            // lblSenhaHost
            // 
            this.lblSenhaHost.AutoSize = true;
            this.lblSenhaHost.Location = new System.Drawing.Point(13, 127);
            this.lblSenhaHost.Name = "lblSenhaHost";
            this.lblSenhaHost.Size = new System.Drawing.Size(75, 19);
            this.lblSenhaHost.TabIndex = 1;
            this.lblSenhaHost.Text = "Senha host:";
            // 
            // lblEmailDest
            // 
            this.lblEmailDest.AutoSize = true;
            this.lblEmailDest.Location = new System.Drawing.Point(285, 86);
            this.lblEmailDest.Name = "lblEmailDest";
            this.lblEmailDest.Size = new System.Drawing.Size(124, 19);
            this.lblEmailDest.TabIndex = 2;
            this.lblEmailDest.Text = "E-mail monitorado:";
            // 
            // TxtSenha
            // 
            this.TxtSenha.Location = new System.Drawing.Point(94, 127);
            this.TxtSenha.Name = "TxtSenha";
            this.TxtSenha.Size = new System.Drawing.Size(185, 23);
            this.TxtSenha.TabIndex = 3;
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(94, 86);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(185, 23);
            this.txtHost.TabIndex = 4;
            // 
            // txtMonitorado
            // 
            this.txtMonitorado.Location = new System.Drawing.Point(415, 86);
            this.txtMonitorado.Name = "txtMonitorado";
            this.txtMonitorado.Size = new System.Drawing.Size(184, 23);
            this.txtMonitorado.TabIndex = 5;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(481, 127);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(118, 23);
            this.metroButton1.TabIndex = 6;
            this.metroButton1.Text = "Buscar último e-mail";
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // lblCorpo
            // 
            this.lblCorpo.AutoSize = true;
            this.lblCorpo.Location = new System.Drawing.Point(13, 220);
            this.lblCorpo.Name = "lblCorpo";
            this.lblCorpo.Size = new System.Drawing.Size(138, 19);
            this.lblCorpo.TabIndex = 8;
            this.lblCorpo.Text = "Corpo da mensagem:";
            // 
            // lblAssunto
            // 
            this.lblAssunto.AutoSize = true;
            this.lblAssunto.Location = new System.Drawing.Point(13, 179);
            this.lblAssunto.Name = "lblAssunto";
            this.lblAssunto.Size = new System.Drawing.Size(57, 19);
            this.lblAssunto.TabIndex = 9;
            this.lblAssunto.Text = "Assunto:";
            // 
            // txtCorpo
            // 
            this.txtCorpo.AutoSize = true;
            this.txtCorpo.Location = new System.Drawing.Point(13, 239);
            this.txtCorpo.Name = "txtCorpo";
            this.txtCorpo.Size = new System.Drawing.Size(0, 0);
            this.txtCorpo.TabIndex = 10;
            // 
            // txtAssunto
            // 
            this.txtAssunto.AutoSize = true;
            this.txtAssunto.Location = new System.Drawing.Point(76, 179);
            this.txtAssunto.Name = "txtAssunto";
            this.txtAssunto.Size = new System.Drawing.Size(0, 0);
            this.txtAssunto.TabIndex = 11;
            this.txtAssunto.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // FrmRobo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(612, 559);
            this.Controls.Add(this.txtAssunto);
            this.Controls.Add(this.txtCorpo);
            this.Controls.Add(this.lblAssunto);
            this.Controls.Add(this.lblCorpo);
            this.Controls.Add(this.metroButton1);
            this.Controls.Add(this.txtMonitorado);
            this.Controls.Add(this.txtHost);
            this.Controls.Add(this.TxtSenha);
            this.Controls.Add(this.lblEmailDest);
            this.Controls.Add(this.lblSenhaHost);
            this.Controls.Add(this.lblEmailHost);
            this.Name = "FrmRobo";
            this.Text = "OBTER ÚLTIMO E-MAIL";
            this.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lblEmailHost;
        private MetroFramework.Controls.MetroLabel lblSenhaHost;
        private MetroFramework.Controls.MetroLabel lblEmailDest;
        private MetroFramework.Controls.MetroTextBox TxtSenha;
        private MetroFramework.Controls.MetroTextBox txtHost;
        private MetroFramework.Controls.MetroTextBox txtMonitorado;
        private MetroFramework.Controls.MetroButton metroButton1;
        private MetroFramework.Controls.MetroLabel lblCorpo;
        private MetroFramework.Controls.MetroLabel lblAssunto;
        private MetroFramework.Controls.MetroLabel txtCorpo;
        private MetroFramework.Controls.MetroLabel txtAssunto;
    }
}

