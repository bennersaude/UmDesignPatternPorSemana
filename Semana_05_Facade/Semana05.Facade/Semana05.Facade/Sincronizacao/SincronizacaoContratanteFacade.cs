namespace Semana05.Facade.Sincronizacao
{
    public class SincronizacaoContratanteFacade : IImportacaoDados
    {
        private readonly ISincronizacaoContratante sincronizacaoContratante;
        private readonly ISincronizacaoContrato sincronizacaoContrato;
        private readonly ISincronizacaoContratoEFamilia sincronizacaoContratoEFamilia;

        public SincronizacaoContratanteFacade(
            ISincronizacaoContratante sincronizacaoContratante,
            ISincronizacaoContrato sincronizacaoContrato,
            ISincronizacaoContratoEFamilia sincronizacaoContratoEFamilia)
        {
            this.sincronizacaoContratante = sincronizacaoContratante;
            this.sincronizacaoContrato = sincronizacaoContrato;
            this.sincronizacaoContratoEFamilia = sincronizacaoContratoEFamilia;
        }

        public void PosImportacao()
        {
            sincronizacaoContratante.PosImportacao();
            sincronizacaoContrato.PosImportacao();
            sincronizacaoContratoEFamilia.PosImportacao();
        }

        public void PreImportacao()
        {
            sincronizacaoContratante.PreImportacao();
            sincronizacaoContrato.PreImportacao();
            sincronizacaoContratoEFamilia.PreImportacao();
        }

        public void SalvarRegistro(object registro)
        {
            sincronizacaoContratante.SalvarRegistro(registro);
            sincronizacaoContrato.SalvarRegistro(registro);
            sincronizacaoContratoEFamilia.SalvarRegistro(registro);
        }
    }
}
