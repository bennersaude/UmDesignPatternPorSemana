using System;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ProcessamentoGuias
    {
        private IValidadorGuias validador;
        private IServicoEnvioGuias envioGuias;

        public ProcessamentoGuias(IValidadorGuias validador, IServicoEnvioGuias envioGuias)
        {
            this.validador = validador;
            this.envioGuias = envioGuias;
        }

        public RespostaProcessamentoDto Processar(IGuiaProperties guia)
        {
            if (!validador.GuiaEhValida(guia))
                throw new Exception("Guia não possui dados validos");

            var respostaEnvio = this.envioGuias.Enviar(guia);

            var respostaProcessamento = new RespostaProcessamentoDto();

            if (respostaEnvio != null)
                respostaProcessamento.Sucesso = true;

            return respostaProcessamento;
        }
    }
}