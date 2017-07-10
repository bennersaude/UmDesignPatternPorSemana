using System;
using Decorator.Adicionais;
using Decorator.Base;
using Decorator.Bebidas;

namespace Decorator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Coquetel meuCoquetel = new Cachaca();
            Console.WriteLine($"{meuCoquetel.GetNome()} = {meuCoquetel.GetPreco()}");

            meuCoquetel = new Refrigerante(meuCoquetel);
            Console.WriteLine($"{meuCoquetel.GetNome()} = {meuCoquetel.GetPreco()}");

            meuCoquetel = new Limao(meuCoquetel);
            Console.WriteLine($"{meuCoquetel.GetNome()} = {meuCoquetel.GetPreco()}");

            // Não é mais subclasse de coquetel
            Console.WriteLine(meuCoquetel is Coquetel);

            Console.ReadKey();
        }
    }
}
