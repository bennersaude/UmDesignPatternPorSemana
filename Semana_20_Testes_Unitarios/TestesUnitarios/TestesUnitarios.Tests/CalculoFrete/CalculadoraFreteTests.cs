using FluentAssertions;
using NUnit.Framework;
using TestesUnitarios.CalculoFrete;

namespace TestesUnitarios.Tests.CalculoFrete
{
    [TestFixture]
    public class CalculadoraFreteTests
    {
        [TestCase(TipoFrete.PAC, 10, 1.5, TestName = "Deve calcular frete Pac corretamente se distancia menor que 100 km")]
        [TestCase(TipoFrete.PAC, 110, 27.5, TestName = "Deve calcular frete Pac corretamente se distancia maior que 100 km")]
        [TestCase(TipoFrete.Sedex, 10, 4, TestName = "Deve calcular frete Sedex corretamente se distancia menor que 100 km")]
        [TestCase(TipoFrete.Sedex, 120, 84, TestName = "Deve calcular frete Sedex corretamente se distancia maior que 100 km")]
        [TestCase(TipoFrete.Transportadora, 605.5, 211.92, TestName = "Deve calcular frete Transportadora corretamente se distancia maior que 400 km")]
        [TestCase(TipoFrete.Transportadora, 15, 4.5, TestName = "Deve calcular frete Transportadora corretamente se distancia menor que 400 km")]
        [TestCase(TipoFrete.RetiradaLocal, 100, 0, TestName = "Deve gerar frete com valor 0 se Retirada no Local")]
        public void Deve_calcular_frete_corretamente(TipoFrete tipoFrete, double distancia, double freteEsperado)
        {
            var calculadoraFrete = new CalculadoraFrete();
            var valorFrete = calculadoraFrete.CalcularFrete(distancia, tipoFrete);

            valorFrete.Should().Be(freteEsperado);     
        }
    }
}
