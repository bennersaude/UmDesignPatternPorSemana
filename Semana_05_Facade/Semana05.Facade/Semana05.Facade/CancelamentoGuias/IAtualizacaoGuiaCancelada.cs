namespace Semana05.Facade.CancelamentoGuias
{
    public interface IAtualizacaoGuiaCancelada
    {
        void AtualizarDados(long handleGuia);
        void AtualizarEventos(long handleGuia);
    }
}