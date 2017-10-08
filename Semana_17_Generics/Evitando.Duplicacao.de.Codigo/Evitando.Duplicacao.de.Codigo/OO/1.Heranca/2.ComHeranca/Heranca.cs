using System;

namespace Evitando.Duplicacao.de.Codigo.OO._1.Heranca._1.ComHeranca
{
    public class Guia
    {
        public DateTime DataCancelamento { get; set; }
    }

    public class Sadt : Guia { }
    public class Internacao : Guia { }

    class Program
    {
        static void Main(string[] args)
        {
            var sadt = new Sadt { DataCancelamento = DateTime.Today };
            var internacao = new Internacao { DataCancelamento = DateTime.Today };
        }
    }
}
