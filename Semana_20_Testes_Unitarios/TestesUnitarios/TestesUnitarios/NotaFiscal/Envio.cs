using System;

namespace TestesUnitarios.NotaFiscal
{
    public class Envio : IEnvio
    {
        public NotaFiscal NotaFiscalEnviada { get; set; }
        public void EnviarEmail(NotaFiscal nota)
        {
            throw new NotImplementedException();
        }
    }
}
