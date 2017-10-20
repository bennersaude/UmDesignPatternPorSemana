using System;

namespace TestesUnitarios.NotaFiscal
{
    public class GeracaoNotaFiscal
    {
        private readonly ICalculadoraNotaFiscal calculadora;
        private readonly IEnvio envio;
        private readonly INotaFiscalDao dao;

        public GeracaoNotaFiscal(
            ICalculadoraNotaFiscal calculadora, 
            IEnvio envio,
            INotaFiscalDao dao)
        {
            this.calculadora = calculadora;
            this.envio = envio;
            this.dao = dao;
        }

        public void Gerar(Pedido pedido)
        {
            var valorCalculado = calculadora.Calcular(pedido);
            var notaFiscal = new NotaFiscal(pedido.Cliente, valorCalculado, DateTime.Today);

            envio.EnviarEmail(notaFiscal);
            dao.Salvar(notaFiscal);
        }
    }
}