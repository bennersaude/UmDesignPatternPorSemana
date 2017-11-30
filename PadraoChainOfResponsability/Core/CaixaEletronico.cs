using System;

namespace PadraoChainOfResponsability
{
    public class CaixaEletronico
    {
        private const int CEM_REAIS = 100;
        private const int CINQUENTA_REAIS = 50;
        private const int VINTE_REAIS = 20;
        private const int DEZ_REAIS = 10;
        private const int CINCO_REAIS = 5;
        private const int DOIS_REAIS = 2;

        public void Sacar(double quantia)
        {
            Console.WriteLine("Tentativa de Saque: " + quantia);

            if (quantia > CEM_REAIS)
            {
                var notas = (int)quantia / CEM_REAIS;
                Console.WriteLine(notas + " notas de 100 reais");
                quantia -= notas * CEM_REAIS;
            }
            if (quantia > CINQUENTA_REAIS)
            {
                var notas = (int)quantia / CINQUENTA_REAIS;
                Console.WriteLine(notas + " notas de 50 reais");
                quantia -= notas * CINQUENTA_REAIS;
            }
            if (quantia > VINTE_REAIS)
            {
                var notas = (int)quantia / VINTE_REAIS;
                Console.WriteLine(notas + " notas de 20 reais");
                quantia -= notas * VINTE_REAIS;
            }
            if (quantia > DEZ_REAIS)
            {
                var notas = (int)quantia / DEZ_REAIS;
                Console.WriteLine(notas + " notas de 10 reais");
                quantia -= notas * DEZ_REAIS;
            }
            if (quantia > CINCO_REAIS)
            {
                var notas = (int)quantia / CINCO_REAIS;
                Console.WriteLine(notas + " notas de 5 reais");
                quantia -= notas * CINCO_REAIS;
            }
            if (quantia > DOIS_REAIS)
            {
                var notas = (int)quantia / DOIS_REAIS;
                Console.WriteLine(notas + " notas de 2 reais");
                quantia -= notas * DOIS_REAIS;
            }

            Console.WriteLine("total restante: " + quantia);
        }
    }
}
