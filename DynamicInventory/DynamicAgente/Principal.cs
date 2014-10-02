using System;
using System.Diagnostics;
using System.Windows.Forms;
using DynamicService;

namespace DynamicAgente
{
    public partial class Principal : Form
    {
        public Principal()
        {
            InitializeComponent();

            if (!UAC.IsAdmin())
            {
                this.Text += " (Sem Privilégios)";
                UAC.AddShieldToButton(btnConfiguracao);
            }
            else
                this.Text += " (Com Privilégios)";
        }

        private void notifyIcon_DoubleClick(object sender, EventArgs e)
        {
            Show();
            Activate();
            WindowState = FormWindowState.Normal;
            notifyIcon.Visible = false;
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void lbDynamic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.dynamicgroup.com.br");
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            notifyIcon.Visible = true;
            this.Hide();
        }

        private void ComputadorPL_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                notifyIcon.Visible = true;
                Hide();
            } 
        }

        private void ComputadorPL_Shown(object sender, EventArgs e)
        {
            //Hide();
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            lbStatus.Text = string.Format("DynamicService está: {0}", ServiceManager.StatusServico());
        }

        private void btnConfiguracao_Click(object sender, EventArgs e)
        {
            if (UAC.IsAdmin())
            {
                Configuracao configuracao = new Configuracao();
                configuracao.ShowDialog();
            }
            else
            {
                MessageBox.Show("A Aplicação será reiniciada com privilégios administrativos!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                UAC.RestartElevated();
            }
        }
    }
}
