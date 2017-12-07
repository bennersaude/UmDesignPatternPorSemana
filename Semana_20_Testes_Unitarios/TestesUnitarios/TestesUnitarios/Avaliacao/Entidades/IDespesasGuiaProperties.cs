using Benner.Tecnologia.Common;

namespace TestesUnitarios.Avaliacao.Entidades
{
    public interface IDespesasGuiaProperties : IEntityBaseProperties
    {
        EntityAssociation<Guia> Guia { get; set; }
        TipoReducaoAcrescimo? TipoReducaoAcrescimo { get; set; }
        decimal? ValorReducaoAcrescimo { get; set; }
    }
}