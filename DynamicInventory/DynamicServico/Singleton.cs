using System;

namespace DynamicService
{
    class Singleton
    {
        public string caminhoLogServico { get; set; }
        public string stringConexao { get; set; }
        public string columnInfoQuery = "SELECT c.name ColumnName,t.name as TypeName,c.max_Length as Max_Length,c.is_nullable as Is_Nullable  FROM sys.columns c "
        + "JOIN sys.types AS t ON c.user_type_id=t.user_type_id where object_id=Object_Id('{0}')";
        public Int32 timerServico { get; set; }
        public bool envioConcluido { get; set; }
        public string SerialNumber { get; set; }

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
                Properties.Settings.Default.Upgrade();
                caminhoLogServico = AppDomain.CurrentDomain.BaseDirectory + "DynamicServico.log";
                stringConexao = Properties.Settings.Default.stringConexao;
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
