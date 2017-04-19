using Semana05.Facade.CancelamentoGuias;

namespace Semana05.Facade.CancelamentoGuiasSaudavel.Regras
{
    public class RegraGuiaNaoEstaEmLote : IRegraCancelamentoGuia
    {
        private readonly IConsultaGuias consultaGuias;

        public RegraGuiaNaoEstaEmLote(IConsultaGuias consultaGuias)
        {
            this.consultaGuias = consultaGuias;
        }

        public bool PodeCancelar(long handleGuia)
        {
            return !consultaGuias.GuiaEstaNoLote(handleGuia);
        }
    }
}
