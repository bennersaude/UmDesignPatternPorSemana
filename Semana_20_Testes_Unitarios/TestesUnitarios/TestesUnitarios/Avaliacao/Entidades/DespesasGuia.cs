using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;

namespace TestesUnitarios.Avaliacao.Entidades
{
    public class DespesasGuia : BusinessEntity<DespesasGuia>, IDespesasGuiaProperties
    {
        public EntityAssociation<Guia> Guia { get; set; }
        public decimal? ValorReducaoAcrescimo { get; set; }
        public TipoReducaoAcrescimo? TipoReducaoAcrescimo { get; set; }
    }
}