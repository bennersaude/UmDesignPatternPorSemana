using System;

namespace TestesUnitarios.NotaFiscal
{
    public class CalculadoraNotaFiscal : ICalculadoraNotaFiscal
    {
        public double Calcular(Pedido pedido)
        {
            return pedido.ValorTotal * pedido.QuantidadeItens * 0.94;
        }
    }
}