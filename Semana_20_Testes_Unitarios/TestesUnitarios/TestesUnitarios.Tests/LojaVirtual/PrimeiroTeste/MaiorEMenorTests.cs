using NUnit.Framework;
using TestesUnitarios.LojaVirtual.PrimeiroTeste;

namespace TestesUnitarios.Tests.LojaVirtual.PrimeiroTeste
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

            Assert.AreEqual("Jogo de pratos", algoritmo.Menor.Nome);
            Assert.AreEqual("Geladeira", algoritmo.Maior.Nome);
        }

        [Test]
        public void Deve_retornar_maior_e_menor_para_um_produto()
        {
            var carrinho = new CarrinhoDeCompras();
            carrinho.Add(new Produto("Liquidificador", 250.0));
            carrinho.Imprimir();

            var algoritmo = new MaiorEMenor();
            algoritmo.Encontra(carrinho);

            Assert.AreEqual("Liquidificador", algoritmo.Menor.Nome);
            Assert.AreEqual("Liquidificador", algoritmo.Maior.Nome);
        }

        [Test]
        public void Deve_retornar_maior_e_menor_para_lista_decrescente()
        {
            var carrinho = new CarrinhoDeCompras();
            carrinho.Add(new Produto("Geladeira", 450.0));
            carrinho.Add(new Produto("Liquidificador", 250.0));
            carrinho.Add(new Produto("Jogo de pratos", 70.0));
            carrinho.Imprimir();

            var algoritmo = new MaiorEMenor();
            algoritmo.Encontra(carrinho);

            Assert.AreEqual("Jogo de pratos", algoritmo.Menor.Nome);
            Assert.AreEqual("Geladeira", algoritmo.Maior.Nome);
        }

        [Test]
        public void Deve_retornar_maior_e_menor_para_lista_crescente()
        {
            var carrinho = new CarrinhoDeCompras();
            carrinho.Add(new Produto("Jogo de pratos", 70.0));
            carrinho.Add(new Produto("Liquidificador", 250.0));
            carrinho.Add(new Produto("Geladeira", 450.0));
            carrinho.Imprimir();

            var algoritmo = new MaiorEMenor();
            algoritmo.Encontra(carrinho);

            Assert.AreEqual("Jogo de pratos", algoritmo.Menor.Nome);
            Assert.AreEqual("Geladeira", algoritmo.Maior.Nome);
        }
    }
}
