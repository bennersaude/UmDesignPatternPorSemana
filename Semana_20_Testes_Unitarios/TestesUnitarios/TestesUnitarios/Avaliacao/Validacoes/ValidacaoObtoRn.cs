using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Validacoes
{
    public class ValidacaoObtoRn : IValidacaoGuia
    {
        public bool Validar(IGuia guia)
        {
            if (guia.IndicadorDeclaracaoObitoRn != null && (bool) guia.IndicadorDeclaracaoObitoRn)
                return !string.IsNullOrEmpty(guia.NumeroDeclaracaoObito);

            return true;
        }

        public string ObterMensagemErro()
        {
            return "É necessário informar o número da declaração de óbito do RN";
        }
    }
}
