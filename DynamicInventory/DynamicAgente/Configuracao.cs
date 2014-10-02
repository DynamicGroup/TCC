using System;
using System.Windows.Forms;
using DynamicService;

namespace DynamicAgente
{
    public partial class Configuracao : Form
    {
        public Configuracao()
        {
            InitializeComponent();
            Singleton.Instance.lerConfiguracao();
        }

        private void Configuracao_Load(object sender, EventArgs e)
        {
            tbEndereco.Text = Singleton.Instance.enderecoConexao;
            tbNomeBanco.Text = Singleton.Instance.nomeBanco;
            tbSenha.Text = Singleton.Instance.senhaConexao;
            tbUsuario.Text = Singleton.Instance.usuarioConexao;
            nudTimer.Value = Singleton.Instance.timerServico;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                MySettings settings = MySettings.Load();
                settings.enderecoConexao = tbEndereco.Text;
                settings.nomeBanco = tbNomeBanco.Text;
                settings.senhaConexao = Singleton.Instance.codifica(tbSenha.Text);
                settings.usuarioConexao = Singleton.Instance.codifica(tbUsuario.Text);
                settings.timerServico = Convert.ToInt32(nudTimer.Value);
                MySettings.Save(settings);

                MessageBox.Show("Configuraçãoes salvas com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                Singleton.Instance.registraLog(ex.Message + ex.StackTrace);
            }
        }

        private void nudTimer_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < 48 || e.KeyChar > 57)
            {
                e.Handled = true;
            }
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            string status = ServiceManager.StatusServico();
            lbStatus.Text = string.Format("Status Dynamic Service: {0}", status);
            btnStart.Enabled = status == "Parado";
            btnStop.Enabled = status == "Rodando";
            btnReiniciar.Enabled = status == "Rodando";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            ServiceManager.StartService("DynamicService", 10000);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            ServiceManager.StopService("DynamicService", 10000);
        }

        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            ServiceManager.RestartService("DynamicService", 10000);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
