using Benner.Tecnologia.Common;

namespace TestesUnitarios.Avaliacao.Entidades
{
    public interface IDespesasGuiaProperties
    {
        EntityAssociation<Guia> Guia { get; set; }
        decimal? ValorReducaoAcrescimo { get; set; }
        TipoReducaoAcrescimo? TipoReducaoAcrescimo { get; set; }
    }
}
