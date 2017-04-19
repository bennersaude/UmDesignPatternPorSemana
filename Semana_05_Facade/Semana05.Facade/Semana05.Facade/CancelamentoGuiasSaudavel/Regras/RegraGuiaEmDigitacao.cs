using Semana05.Facade.CancelamentoGuias;

namespace Semana05.Facade.CancelamentoGuiasSaudavel.Regras
{
    public class RegraGuiaEmDigitacao : IRegraCancelamentoGuia
    {
        private readonly IConsultaGuias consultaGuias;

        public RegraGuiaEmDigitacao(IConsultaGuias consultaGuias)
        {
            this.consultaGuias = consultaGuias;
        }

        public bool PodeCancelar(long handleGuia)
        {
            return consultaGuias.GuiaEmDigitacao(handleGuia);
        }
    }
}
