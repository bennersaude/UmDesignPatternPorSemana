using NUnit.Framework;
using TestesUnitarios.CarrinhoCompras;

namespace TestesUnitarios.Tests.CarrinhoCompras
{
    [TestFixture]
    public class CarrinhoComprasListaTests
    {
        [Test]
        public void Deve_retornar_0_se_carrinho_vazio()
        {
            var carrinho = new CarrinhoComprasLista();
            var actual = carrinho.ObterMaiorValor();

            Assert.AreEqual(0, actual);
        }

        [Test]
        public void Deve_retornar_valor_do_item_quando_carrinho_com_apenas_um_item()
        {
            var expected = new Item("Itaipava", 3, 1.99);
            var carrinho = new CarrinhoComprasLista() { expected };
            var actual = carrinho.ObterMaiorValor();

            Assert.AreEqual(expected.ValorTotal, actual);
        }

        [Test]
        public void Deve_retornar_valor_do_item_de_maior_valor()
        {
            var item = new Item("Itaipava", 3, 1.99);
            var expected = new Item("Doritos", 3, 6);
            var carrinho = new CarrinhoComprasLista() { item, expected };
            var actual = carrinho.ObterMaiorValor();

            Assert.AreEqual(expected.ValorTotal, actual);
        }
    }
}
