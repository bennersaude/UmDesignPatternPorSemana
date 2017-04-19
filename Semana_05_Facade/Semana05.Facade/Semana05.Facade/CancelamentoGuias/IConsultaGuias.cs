namespace Semana05.Facade.CancelamentoGuias
{
    public interface IConsultaGuias
    {
        bool GuiaEstaNoLote(long handleGuia);
        bool GuiaEmDigitacao(long handleGuia);
    }
}