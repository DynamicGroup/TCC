using System;

namespace DynamicService
{
    class Singleton
    {
        public string caminhoLogServico { get; set; }
        public string urlPost { get; set; }
        public Int32 timerServico { get; set; }
        public bool envioConcluido { get; set; }

        private static Singleton instance;

        private Singleton() 
        {
            envioConcluido = true;
        }

        public static Singleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Singleton();
                }
                return instance;
            }
        }

        public bool lerConfiguracao()
        {
            try
            {
                caminhoLogServico = AppDomain.CurrentDomain.BaseDirectory + "DynamicServico.log";
                urlPost = Properties.Settings.Default.stringConexao;
                timerServico = (Properties.Settings.Default.timerServico * 1000) * 60;
                return true;
            }
            catch (Exception e)
            {
                registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        public void registraLog(string mensagem)
        {
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(Singleton.Instance.caminhoLogServico, true))
                {
                    file.WriteLine(DateTime.Now + " - " + mensagem);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
