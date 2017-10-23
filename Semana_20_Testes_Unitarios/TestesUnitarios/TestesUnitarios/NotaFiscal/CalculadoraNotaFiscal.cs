using System;

namespace TestesUnitarios.NotaFiscal
{
    public class CalculadoraNotaFiscal : ICalculadoraNotaFiscal
    {
        public CalculadoraNotaFiscal()
        {
        }

        public double Calcular(Pedido pedido)
        {
            return pedido.ValorTotal * pedido.QuantidadeItens * 0.94;
        }
    }
}