using System;
using System.Collections.Generic;

namespace TestesUnitarios._1.LojaVirtual.PrimeiroTeste
{
    public class CarrinhoDeCompras : List<Produto>
    {
        public void Imprimir()
        {
            foreach (var produto in this)
            {
                Console.WriteLine(produto.Nome + ", R$ " + produto.Valor);
            }
        }
    }
}