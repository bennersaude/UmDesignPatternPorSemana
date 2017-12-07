using Benner.Tecnologia.Common;

namespace TestesUnitarios.Avaliacao.Entidades
{
    public interface IDespesasGuia
    {
        EntityAssociation<Guia> Guia { get; set; }
        decimal? ValorReducaoAcrescimo { get; set; }
        TipoReducaoAcrescimo? TipoReducaoAcrescimo { get; set; }
    }
}