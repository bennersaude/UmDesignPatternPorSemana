using System;

namespace TestesUnitarios.NotaFiscal
{
    public class GeracaoNotaFiscal
    {
        private ICalculadoraNotaFiscal calculadora;
        private IEnvio envio;
        private INotaFiscalDao notaFiscalDao;

        public GeracaoNotaFiscal(ICalculadoraNotaFiscal calculadora, IEnvio envio, INotaFiscalDao notaFiscalDao)
        {
            this.calculadora = calculadora;
            this.envio = envio;
            this.notaFiscalDao = notaFiscalDao;
        }

        public NotaFiscal Gerar(Pedido pedido)
        {
            var valor = calculadora.Calcular(pedido);
            var notaFiscal = new NotaFiscal(pedido.Cliente, valor, DateTime.Today);
            notaFiscalDao.Salvar(notaFiscal);
            envio.EnviarEmail(notaFiscal);

            return notaFiscal;
        }
    }
}