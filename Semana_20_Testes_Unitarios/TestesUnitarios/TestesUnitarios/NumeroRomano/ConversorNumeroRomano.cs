using System;
using System.Linq;

namespace TestesUnitarios.NumeroRomano
{
    public class ConversorNumeroRomano
    {
        public ConversorNumeroRomano()
        {
        }

        public int Converter(char numero)
        {
            switch (numero)
            {
                case 'I': return 1;
                case 'V': return 5;
                case 'X': return 10;
                case 'L': return 50;
                case 'C': return 100;
                case 'D': return 500;
                case 'M': return 1000;
                default: throw new ArgumentException("Número inválido!");
            }
        }

        public int Converter(string v)
        {
            return v.ToCharArray().Select(Converter).Sum();
        }
    }
}