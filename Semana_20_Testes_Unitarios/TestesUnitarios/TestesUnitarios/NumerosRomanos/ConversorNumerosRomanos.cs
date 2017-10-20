using System;
using System.Collections.Generic;
using System.Linq;

namespace TestesUnitarios.NumerosRomanos
{
    public class ConversorNumerosRomanos
    {
        public int Converter(char numero)
        {
            switch (numero)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                default: throw new ArgumentException("Numero invalido");
            }
        }

        public int Converter(string numero)
        {
            return numero.ToCharArray().Select(Converter).Sum();
        }
    }
}