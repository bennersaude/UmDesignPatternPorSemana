namespace Semana05.Facade.CancelamentoGuias
{
    public class CancelamentoGuias : ICancelamentoGuias
    {
        private readonly IPermissoesUsuario permissoesUsuario;
        private readonly IConsultaGuias consultaGuias;
        private readonly IAtualizacaoGuiaCancelada atualizacaoGuiaCancelada;


        public CancelamentoGuias(
            IPermissoesUsuario permissoesUsuario, 
            IConsultaGuias consultaGuias, 
            IAtualizacaoGuiaCancelada atualizacaoGuiaCancelada)
        {
            this.permissoesUsuario = permissoesUsuario;
            this.consultaGuias = consultaGuias;
            this.atualizacaoGuiaCancelada = atualizacaoGuiaCancelada;
        }

        public void CancelarGuia(long handleGuia)
        {
            if (!permissoesUsuario.UsuarioPodeAlterar<Guia>(handleGuia)) return;
            if (!consultaGuias.GuiaEmDigitacao(handleGuia)) return;
            if (consultaGuias.GuiaEstaNoLote(handleGuia)) return;

            atualizacaoGuiaCancelada.AtualizarDados(handleGuia);
            atualizacaoGuiaCancelada.AtualizarEventos(handleGuia);
        }
    }
}
