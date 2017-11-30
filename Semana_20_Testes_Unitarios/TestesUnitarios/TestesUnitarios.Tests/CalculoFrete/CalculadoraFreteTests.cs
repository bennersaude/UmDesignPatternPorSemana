using FluentAssertions;
using NUnit.Framework;
using TestesUnitarios.CalculoFrete.Enum;
using TestesUnitarios.CalculoFrete.CalculadoraFretes;
using TestesUnitarios.CalculoFrete.CalculadoraFretesTemplate.Factory;

namespace TestesUnitarios.Tests.CalculoFrete
{
    /// <summary>
    ///    1. Ler capítulo 7 do livro, pág 97.
    ///    2. Precisamos calcular os valores de Frete de uma Loja Virtual seguindo as seguintes especificações:
    ///        2.1 Fretes via PAC cuja distância seja menor que 100 km custam a quantidade de quilômetros * 0.15
    ///                    fretes cuja distância seja maior custam a quantidade de quilômetros * 0.25
    ///        2.2 Fretes via Sedex cuja distância seja menor que 100 km custam a quantidade de quilômetros * 0.40
    ///                      fretes cuja distância seja maior custam a quantidade de quilômetros * 0.70
    ///        2.3 Fretes via Transportadora cuja distância seja maior que 400 km custam a quantidade de quilômetros * 0.35
    ///                               fretes cuja distância seja menor custam a quantidade de quilômetros * 0.30
    ///        2.4 Fretes selecionados como Retirada no local não tem custo.
    /// </summary>
    [TestFixture]
    public class CalculadoraFreteTests
    {
        [TestCase(TipoFrete.RetiradaLocal, 1, 0, TestName = "Deve ter custo zero com retirada local e distância curta")]
        [TestCase(TipoFrete.RetiradaLocal, 3502, 0, TestName = "Deve ter custo zero com retirada local e distância longa")]
        [TestCase(TipoFrete.ViaPAC, 99, 14.85, TestName = "Deve ter custo 14,85 via PAC com distância curta")]
        [TestCase(TipoFrete.ViaPAC, 100, 25, TestName = "Deve ter custo 25,00 via PAC e distância longa")]
        [TestCase(TipoFrete.ViaSedex, 99, 39.6, TestName = "Deve ter custo 39,60 via Sedex com distância curta")]
        [TestCase(TipoFrete.ViaSedex, 100, 70, TestName = "Deve ter custo 70,00 via Sedex e distância longa")]
        [TestCase(TipoFrete.ViaTransportadora, 399, 119.7, TestName = "Deve ter custo 119,7 via Transportadora com distância curta")]
        [TestCase(TipoFrete.ViaTransportadora, 400, 120, TestName = "Deve ter custo 120,00 via Transportadora e distância longa")]
        public void Deve_calcular_custo_frete(TipoFrete tipoFrete, double distanciaKm, double custoEsperado)
        {
            var calculadora = new CalculadoraFrete(tipoFrete);
            var custoFrete = calculadora.CalcularFrete(distanciaKm);
            custoFrete.Should().Be(custoEsperado);
        }

        [TestCase(TipoFrete.RetiradaLocal, 1, 0, TestName = "Deve ter custo zero com retirada local e distância curta (Template)")]
        [TestCase(TipoFrete.RetiradaLocal, 3502, 0, TestName = "Deve ter custo zero com retirada local e distância longa (Template)")]
        [TestCase(TipoFrete.ViaPAC, 99, 14.85, TestName = "Deve ter custo 14,85 via PAC com distância curta (Template)")]
        [TestCase(TipoFrete.ViaPAC, 100, 25, TestName = "Deve ter custo 25,00 via PAC e distância longa (Template)")]
        [TestCase(TipoFrete.ViaSedex, 99, 39.6, TestName = "Deve ter custo 39,60 via Sedex com distância curta (Template)")]
        [TestCase(TipoFrete.ViaSedex, 100, 70, TestName = "Deve ter custo 70,00 via Sedex e distância longa (Template)")]
        [TestCase(TipoFrete.ViaTransportadora, 399, 119.7, TestName = "Deve ter custo 119,7 via Transportadora com distância curta (Template)")]
        [TestCase(TipoFrete.ViaTransportadora, 400, 120, TestName = "Deve ter custo 120,00 via Transportadora e distância longa (Template)")]
        public void Deve_calcular_custo_frete_template(TipoFrete tipoFrete, double distanciaKm, double custoEsperado)
        {
            var calculadoraFreteFactory = new CalculadoraFreteTemplateFactory();
            var calculadora = calculadoraFreteFactory.ObterCalculadoraPorTipoFrete(tipoFrete);
            var custoFrete = calculadora.CalcularFrete(distanciaKm);
            custoFrete.Should().Be(custoEsperado);
        }
    }
}
