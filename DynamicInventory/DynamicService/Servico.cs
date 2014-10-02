using System;
using System.ServiceProcess;
using System.Threading;

namespace DynamicService
{
    public partial class Servico : ServiceBase
    {
        Timer timerAgente;
 
        public Servico()
        {
            InitializeComponent();
            Singleton.Instance.lerConfiguracao();
        }

        protected override void OnStart(string[] args)
        {
            try
            {
                timerAgente = (Singleton.Instance.timerServico <= 0) ? null : new Timer(new TimerCallback(timerServico_Tick), null, 15000, Singleton.Instance.timerServico);
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
            }
        }

        protected override void OnStop()
        {
        }

        private void timerServico_Tick(object sender)
        {
            try
            {
                if (Singleton.Instance.envioConcluido)
                {
                    Singleton.Instance.lerConfiguracao();
                    Win32_ComputerSystemDAO.setWin32_ComputerSystem(Win32_ComputerSystemDAO.getWin32_ComputerSystem());
                }
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
            }
        }
    }
}
