using Microsoft.Practices.EnterpriseLibrary.Validation;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business.Processamento
{
    public interface IValidadorGuia
    {
        RespostaProcessamentoDto Validar(IGuiaProperties guia);
    }
}