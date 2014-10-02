using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    public class  MySettings: AppSettings<MySettings>
    {
        public int timerServico = 1;
        public string stringConexao = "Server={0};Database={1};User Id={2};Password={3};";
        public string usuarioConexao = "ZW";
        public string senhaConexao = "ZW";
        public string enderecoConexao = "VBOXSVR";
        public string nomeBanco = "DI";
    }
}
