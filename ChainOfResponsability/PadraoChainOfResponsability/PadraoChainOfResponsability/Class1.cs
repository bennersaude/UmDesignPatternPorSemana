using System;

namespace PadraoChainOfResponsability
{
    public class CaixaEletronico
    {
        public void Sacar(double quantia)
        {
            var saque = 0;
            if(quantia > 100)
            {
                var notas = quantia / 100;
                Console.WriteLine(notas + " notas de 100 reais");
                quantia -= notas * 100;
            }
            if(quantia > 50)
            {
                var notas = quantia / 50;
                Console.WriteLine(notas + " notas de 50 reais");
                quantia -= notas * 50;
            }

            Console.WriteLine("total restante: " + quantia);



        }
    }
}
