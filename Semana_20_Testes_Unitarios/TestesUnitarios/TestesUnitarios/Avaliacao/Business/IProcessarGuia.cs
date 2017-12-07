using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public interface IProcessarGuia
    {
        RespostaProcessamentoDto Processar(IGuiaProperties guia);
    }
}