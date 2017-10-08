using System;

namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._3.Interfaces
{
    public interface IGuia
    {
        DateTime DataCancelamento { get; set; }
    }

    public class Sadt : IGuia
    {
        public DateTime DataCancelamento { get; set; }
    }

    public class Internacao : IGuia
    {
        public DateTime DataCancelamento { get; set; }
    }

    public class CancelamentoGuias
    {
        public void Cancelar(IGuia guia)
        {
            guia.DataCancelamento = DateTime.Today;
        }
    }
}
