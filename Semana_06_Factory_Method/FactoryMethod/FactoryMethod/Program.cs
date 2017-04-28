using System;

namespace FactoryMethod
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rf = new RefrigeranteFactory();
            Refrigerante refrigerante = null;

            Console.WriteLine("Qual refrigerante você quer? (k / p)");
            var escolha = Console.ReadLine();

            refrigerante = rf.FazerRefrigerante(escolha);

            if (refrigerante != null)
                Executar(refrigerante);
            else
                Console.WriteLine("Digite k ou p ...");

            Console.ReadKey();
        }

        public static void Executar(Refrigerante refri)
        {
            refri.Abrir();
        }
    }
}
