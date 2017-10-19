using System;

namespace TestesUnitarios.Tests.LojaVirtual.Validacao.Asserts
{
    public class Pessoa : IEquatable<Pessoa>
    {
        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public string Nome { get; private set; }

        public bool Equals(Pessoa other)
        {
            return other.Nome == Nome;
        }
    }
}
