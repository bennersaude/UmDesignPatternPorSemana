using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Validacoes
{
    public interface IValidacaoGuia
    {
        string ObterMensagemErro();
        bool Validar(IGuia guia);
    }
}
