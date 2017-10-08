using System;
using Evitando.Duplicacao.de.Codigo.OO._1.Heranca._1.SemHeranca;

namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._1.SemPolimorfismo
{
    // Não esquece de abrir os slides antes do código!!!!

    public class CancelamentoSadt
    {
        public void Cancelar(Sadt guia)
        {
            guia.DataCancelamento = DateTime.Today;
        }
    }

    public class CancelamentoInternacao
    {
        public void Cancelar(Internacao guia)
        {
            guia.DataCancelamento = DateTime.Today;
        }
    }
}
