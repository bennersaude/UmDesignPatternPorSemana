using System;

namespace Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema
{
    public class WebConfig : IWebConfig
    {
        public string DiretorioTemporario { get; set; }
        public string EnderecoCliente { get; set; }
    }
}
