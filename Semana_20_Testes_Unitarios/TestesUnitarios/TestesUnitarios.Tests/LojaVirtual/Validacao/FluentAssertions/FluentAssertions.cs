using FluentAssertions;
using NUnit.Framework;
using TestesUnitarios.LojaVirtual.PrimeiroTeste;

namespace TestesUnitarios.Tests.LojaVirtual.Validacao.FluentAssertions
{
    [TestFixture]
    public class FluentAssertions
    {
        [Test]
        public void Deve_utilizar_fluent_assertions()
        {
            var produto = new Produto("Itaipava", 2.99);
            var outroProduto = new Produto("Itaipava", 2.99);

            // Compara as propriedades publicas do objeto
            produto.ShouldBeEquivalentTo(outroProduto);

            // Strings

            produto.Should().NotBeNull();
            produto.Nome.Should().NotBeNullOrWhiteSpace();
            produto.Nome.Should().NotBeNullOrEmpty();

            // Numeros

            produto.Valor.Should().BeGreaterThan(2);
            produto.Valor.Should().BeLessThan(3);

            // Listas

            var carrinho = new CarrinhoDeCompras();

            carrinho.Should().BeEmpty();
            carrinho.Should().NotContain(produto);
            carrinho.Should().NotContainNulls();

            //Vamos adicionar um produto

            carrinho.Add(produto);

            carrinho.ShouldBeEquivalentTo(new CarrinhoDeCompras { produto });
            carrinho.Should().ContainSingle();
            carrinho.Should().HaveCount(1);
            carrinho.Should().OnlyContain(produtos => produtos.Valor < 3);
            carrinho.Should().StartWith(produto);

            //Vamos adicionar mais um produto

            carrinho.Add(outroProduto);

            carrinho.ShouldBeEquivalentTo(new CarrinhoDeCompras { produto, outroProduto });
            carrinho.ShouldBeEquivalentTo(new CarrinhoDeCompras { outroProduto, produto });
            carrinho.Should().NotBeEquivalentTo(new CarrinhoDeCompras { new Produto("", 0), produto });

            carrinho.Should().HaveElementSucceeding(produto, outroProduto);
            carrinho.Should().EndWith(outroProduto);    
            // Esse utiliza o equals
            carrinho.Should().ContainInOrder(new CarrinhoDeCompras { produto, outroProduto });
        }
    }
}
