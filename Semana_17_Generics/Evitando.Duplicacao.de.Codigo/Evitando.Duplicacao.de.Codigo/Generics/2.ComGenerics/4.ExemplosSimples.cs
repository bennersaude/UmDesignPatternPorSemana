using System;

namespace Evitando.Duplicacao.de.Codigo.Generics._2.ComGenerics
{
    // Encontrar o maior entre objetos comparaveis
    public class Calculadora
    {
        public static T Maior<T>(T a, T b) where T : IComparable
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public Calculadora()
        {
            var maiorInteiro = Maior(24, 50);
            var maiorDouble = Maior(24.5, 50.7);
            var maiorDecimal = Maior(24.5m, 50.7m);
        }
    }

    // Validar se valores atendem requisitos de negocio
    public class ValorNegocio<T> where T : struct
    {
        private readonly T? valor;

        public ValorNegocio(T? valor)
        {
            this.valor = valor;
        }

        public bool EhValido
        {
            get { return !valor.Equals(null) && !valor.Equals(default(T)); }
        }

        public void Exemplo()
        {
            var valorInteiro = new ValorNegocio<int>(0);
            var inteiroInvalido = valorInteiro.EhValido; // False

            var valorDecimal = new ValorNegocio<decimal>(0m);
            var decimalInvalido = valorDecimal.EhValido; // False

            var valorInteiroNulo = new ValorNegocio<int>(null);
            var inteiroNulo = valorInteiro.EhValido; // False
        }
    }
}
