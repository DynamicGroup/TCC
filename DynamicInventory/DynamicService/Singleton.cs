using System;

namespace DynamicService
{
    class Singleton
    {
        public string caminhoLogServico { get; set; }
        public string stringConexao { get; set; }
        public string usuarioConexao { get; set; }
        public string senhaConexao { get; set; }
        public string enderecoConexao { get; set; }
        public string nomeBanco { get; set; }
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
                caminhoLogServico = AppDomain.CurrentDomain.BaseDirectory + "DynamicService.log";

                MySettings settings = MySettings.Load();

                usuarioConexao = settings.usuarioConexao;
                senhaConexao = settings.senhaConexao;
                enderecoConexao = settings.enderecoConexao;
                nomeBanco = settings.nomeBanco;
                stringConexao = string.Format(settings.stringConexao, settings.enderecoConexao, settings.nomeBanco, decodifica(settings.usuarioConexao), decodifica(settings.senhaConexao));
                timerServico = (settings.timerServico * 1000) * 60;
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

        public string codifica(string texto)
        {
            string cCriptografia, sCriptografia, resultado;
            int pos;
            resultado = "";

            cCriptografia = @"œ!=#$%^&*(-|\][›?><:@Ÿ/{}¯àQWERTYUIOPASDFGHJKLZXCVBNM1324580976+ºusabcd";
            sCriptografia = @"  ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-&*:\/.";
            for (int i = 0; i < texto.Length; i++)
            {
                pos = sCriptografia.IndexOf(texto.Substring(i, 1), 0);
                resultado = resultado + cCriptografia.Substring(pos, 1);
            }
            return resultado;
        }

        public string decodifica(string texto)
        {
            string cCriptografia, sCriptografia, resultado;
            int pos;
            resultado = "";

            cCriptografia = @"œ!=#$%^&*(-|\][›?><:@Ÿ/{}¯àQWERTYUIOPASDFGHJKLZXCVBNM1324580976+ºusabcd";
            sCriptografia = @"  ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789-&*:\/.";
            for (int i = 0; i < texto.Length; i++)
            {
                pos = cCriptografia.IndexOf(texto.Substring(i, 1), 0);
                resultado = resultado + sCriptografia.Substring(pos, 1);
            }
            return resultado;
        }
    }
}
