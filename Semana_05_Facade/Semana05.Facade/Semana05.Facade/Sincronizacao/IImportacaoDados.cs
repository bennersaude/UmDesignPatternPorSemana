namespace Semana05.Facade.Sincronizacao
{
    public interface IImportacaoDados
    {
        void PreImportacao();
        void PosImportacao();
        void SalvarRegistro(object registro);
    }

    public interface ISincronizacaoContratante : IImportacaoDados
    {
    }

    public interface ISincronizacaoContrato : IImportacaoDados
    {
    }

    public interface ISincronizacaoContratoEFamilia : IImportacaoDados
    {
    }
}
