using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public interface IServicoProcessoGuia
    {
        RespostaProcessamentoDto ProcessarGuia(Guia guia);
    }
}