using System;

namespace TestesUnitarios.NotaFiscal
{
    public class Pedido
    {
        public string Cliente { get; private set; }
        public double ValorTotal { get; private set; }
        public int QuantidadeItens { get; private set; }
        public Pedido(String cliente, double valorTotal,
        int quantidadeItens)
        {
            this.Cliente = cliente;
            this.ValorTotal = valorTotal;
            this.QuantidadeItens = quantidadeItens;
        }
    }
}
