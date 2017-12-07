using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public interface IValidacaoGuia
    {
        RespostaProcessamentoDto Validar(IGuiaProperties guia);
    }
}