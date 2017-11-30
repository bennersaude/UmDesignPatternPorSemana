using PadraoChainOfResponsability;
using PadraoChainOfResponsability.Chain;
using PadraoChainOfResponsability.UmPoucoMelhor;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var caixa = new CaixaEletronico();
            //var caixa = new CaixaEletronico2();
            //var caixa = new CaixaEletronico3();

            caixa.Sacar(489);
            Console.WriteLine("--------");
            caixa.Sacar(1237);
            Console.WriteLine("--------");
            caixa.Sacar(598);
            Console.WriteLine("--------");
            caixa.Sacar(2695.89);

            Console.ReadKey();
        }
    }
}