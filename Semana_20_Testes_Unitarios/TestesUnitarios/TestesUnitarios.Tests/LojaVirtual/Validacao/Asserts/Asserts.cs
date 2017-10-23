using System;
using System.Collections.Generic;
using NUnit.Framework;
using TestesUnitarios.LojaVirtual.PrimeiroTeste;

namespace TestesUnitarios.Tests.LojaVirtual.Validacao.Asserts
{
    [TestFixture]
    public class Asserts
    {
        [TestCase(TestName = "Meu Super Teste")]
        public void Test()
        {
            var produto = new Produto("Produto", 1);

            // Utiliza objeto.Equals para comparar
            Assert.AreEqual(produto, produto);

            // Verifica se é a mesma referencia em memoria
            Assert.AreSame(produto, produto);

            Assert.Less(produto.Valor, 2);
            Assert.Greater(2, produto.Valor);

            Assert.IsTrue(true);
            Assert.IsFalse(false);

            Assert.IsEmpty(new CarrinhoDeCompras());
            Assert.IsEmpty("");

            // Podemos utilizar para testar o retorno de um factory
            // que pode retornar objetos de tipos diferentes
            // que herdam de uma mesma classe ou implementam umas mesma
            // interface.
            var factory = new FactoryParametrosSistemas();
            Assert.IsInstanceOf<ParametrosSistemaEntidade>(factory.ObterParametros(false));
            Assert.IsInstanceOf(typeof(ParametrosSistemaLocal), factory.ObterParametros(true));

            // Quando necessario podemos criar testes para garantir um cast
            Assert.IsAssignableFrom<CarrinhoDeCompras>(new List<Produto>());
            Assert.IsAssignableFrom(typeof(CarrinhoDeCompras), new List<Produto>());
            List<Produto> lista = new CarrinhoDeCompras();

            Assert.IsNull(null);
            Assert.IsNotNull(produto);
            Assert.IsNotNullOrEmpty("huehue");

            Assert.Throws<ArgumentNullException>(() => factory.ObterParametros(true));
        }
    }
}
