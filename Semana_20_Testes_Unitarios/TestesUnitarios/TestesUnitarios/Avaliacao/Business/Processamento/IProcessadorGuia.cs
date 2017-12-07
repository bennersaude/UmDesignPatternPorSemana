using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business.Processamento
{
    public interface IProcessadorGuia
    {
        ProcessamentoDTOBase Executar(IGuiaProperties guia);
    }
}