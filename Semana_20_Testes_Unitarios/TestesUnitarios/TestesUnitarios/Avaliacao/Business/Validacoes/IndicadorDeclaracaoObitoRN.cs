using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business.Validacoes
{
    public class IndicadorDeclaracaoObitoRN : IValidacoes
    {
        public string Validar(IGuiaProperties guia)
        {
            if (guia.IndicadorDeclaracaoObitoRn.HasValue 
                && guia.IndicadorDeclaracaoObitoRn.Value 
                && guia.NumeroDeclaracaoObito == string.Empty)
            {
                return "É necessário ter numero da declaracao do obito";
            }

            return string.Empty;
        }
    }
}