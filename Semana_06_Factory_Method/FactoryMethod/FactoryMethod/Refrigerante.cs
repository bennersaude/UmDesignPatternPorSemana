using System;

namespace FactoryMethod
{
    public abstract class Refrigerante
    {
        private string nome;

        public string GetName()
        {
            return nome;
        }

        public void SetName(string nome)
        {
            this.nome = nome;
        }

        public void Abrir()
        {
            Console.WriteLine($"Você abriu uma lata de {this.GetName()}");
        }
    }
}
