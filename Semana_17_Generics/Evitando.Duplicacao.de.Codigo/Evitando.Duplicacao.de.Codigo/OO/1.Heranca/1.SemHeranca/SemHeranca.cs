using System;

namespace Evitando.Duplicacao.de.Codigo.OO._1.Heranca._1.SemHeranca
{
    public class Sadt
    {
        public DateTime DataCancelamento { get; set; }
    }

    public class Internacao
    {
        public DateTime DataCancelamento { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var sadt = new Sadt { DataCancelamento = DateTime.Today };
            var internacao = new Internacao { DataCancelamento = DateTime.Today };
        }
    }
}
