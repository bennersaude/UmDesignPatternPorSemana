using System;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ProcessamentoGuia
    {
        private readonly IValidacaoGuia _validacaoGuia;
        private readonly IServicoEnvioGuias _servicoEnvioGuias;
        private readonly ISalvarGuia _salvarGuia;

        public ProcessamentoGuia(IValidacaoGuia validacaoGuia, IServicoEnvioGuias servicoEnvioGuias, ISalvarGuia salvarGuia)
        {
            _validacaoGuia = validacaoGuia;
            _servicoEnvioGuias = servicoEnvioGuias;
            _salvarGuia = salvarGuia;
        }

        public RespostaProcessamentoDto Processar(IGuiaProperties guia)
        {
            var respostaProcessamento = _validacaoGuia.Validar(guia);

            if (!respostaProcessamento.Sucesso)
                return respostaProcessamento;

            var respostaServico = _servicoEnvioGuias.EnviarGuia(guia);

            if (!respostaServico.Sucesso)
            {
                respostaProcessamento.Sucesso = false;
                respostaProcessamento.Erros = respostaServico.Erros;
                respostaProcessamento.Handle = 0;

                return respostaProcessamento;
            }

            respostaProcessamento.Handle = guia.Handle;

            _salvarGuia.Salvar(guia);

            return respostaProcessamento;
        }
    }
}