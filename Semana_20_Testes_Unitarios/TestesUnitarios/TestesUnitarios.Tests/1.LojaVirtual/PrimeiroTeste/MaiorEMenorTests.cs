using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesUnitarios._1.LojaVirtual.PrimeiroTeste;

namespace TestesUnitarios.Tests._1.LojaVirtual.PrimeiroTeste
{
    // Vamos converter o primeiro teste escrito antes para o nunit
    // Posteriormente com ajuda dos testes vamos corrigir a implementação
    [TestFixture]
    public class MaiorEMenorTests
    {
        [Test]
        public void Deve_retornar_maior_e_menor_para_lista_misturada()
        {
            var carrinho = new CarrinhoDeCompras();
            carrinho.Add(new Produto("Liquidificador", 250.0));
            carrinho.Add(new Produto("Geladeira", 450.0));
            carrinho.Add(new Produto("Jogo de pratos", 70.0));
            carrinho.Imprimir();

            var algoritmo = new MaiorEMenor();
            algoritmo.Encontra(carrinho);
        }
    }
}
