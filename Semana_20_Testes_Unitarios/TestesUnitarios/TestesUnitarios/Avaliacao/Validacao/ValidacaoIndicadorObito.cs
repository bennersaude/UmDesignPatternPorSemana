using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Validacao
{
    public class ValidacaoIndicadorObito : IValidacao
    {
        public string Validar(IGuiaProperties guia)
        {
            if (guia.IndicadorDeclaracaoObitoRn.HasValue 
                && guia.IndicadorDeclaracaoObitoRn.Value 
                && string.IsNullOrWhiteSpace(guia.NumeroDeclaracaoObito))
                return "Numero Declaração Óbito deve estar preenchido";
            return null;
        }
    }
}
