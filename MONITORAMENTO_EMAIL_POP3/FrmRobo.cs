using MetroFramework.Forms;
using MONITORAMENTO_EMAIL_POP3.DTL;
using MONITORAMENTO_EMAIL_POP3.Processos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MONITORAMENTO_EMAIL_POP3
{
    public partial class FrmRobo : MetroForm
    {
        Fluxo fluxo = new Fluxo();
        public FrmRobo()
        {
            InitializeComponent();
            TxtSenha.PasswordChar = '*';
            TxtSenha.MaxLength = 14;

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            if (txtHost.Text != "" && TxtSenha.Text != "" &&  txtMonitorado.Text != "")
            {
                fluxo.Executar(txtHost.Text, TxtSenha.Text, txtMonitorado.Text);
                txtAssunto.Text = RetornoEmailDTO.Assunto;
                txtCorpo.Text = RetornoEmailDTO.Corpo;                                     
            }
            else
            {
                MessageBox.Show("Preencha os campos!");
            }
        }

    }
}
