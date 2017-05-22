using System;
using PrototypeConsole.Exemplo.Prototipos;

namespace PrototypeConsole
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var afilhado = new Programador
            {
                Nome = "Santana",
                Cargo = "Programador",
                Projeto = "RoadMap",
                Linguagem = "C#"
            };

        var programador = new Programador()
            {
                Nome = "Nakahara",
                Cargo = "Programador",
                Projeto = "RoadMap",
                Linguagem = "C#",
                Afilhado = afilhado
            };

            var programadorClone = (Programador)programador.Clone();

            programadorClone.Nome = "Santana";
            programadorClone.Afilhado.Nome = "Outro";

            var testador = new Testador()
            {
                Nome = "Testador1",
                Cargo = "Testador",
                Projeto = "RoadMap"
            };

            var testadorClone = (Testador)testador.Clone();

            testadorClone.Nome = "Testador2";

            Console.WriteLine(programador.DetalhesFuncionario());
            Console.WriteLine(programadorClone.DetalhesFuncionario());

            Console.WriteLine(testador.DetalhesFuncionario());
            Console.WriteLine(testadorClone.DetalhesFuncionario());

            Console.ReadKey();
        }
    }
}