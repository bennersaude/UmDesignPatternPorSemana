using System;
using Evitando.Duplicacao.de.Codigo.OO._1.Heranca._1.ComHeranca;

namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._2.Classes
{
    public class CancelamentoGuias
    {
        public void Cancelar(Guia guia)
        {
            guia.DataCancelamento = DateTime.Today;
        }
    }
}
