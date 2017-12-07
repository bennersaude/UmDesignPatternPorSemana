using System.Collections.Generic;
using System.Linq;
using TestesUnitarios.Avaliacao.Business;
using TestesUnitarios.Avaliacao.Entidades;
using TestesUnitarios.Avaliacao.Validacao;

namespace TestesUnitarios.Avaliacao
{
    public class ProcessamentoGuia
    {
        private readonly IValidacaoGuia validacaoGuia;
        private readonly IServicoEnvioGuias servicoEnvio;

        public ProcessamentoGuia
            (IValidacaoGuia validacaoGuia, 
            IServicoEnvioGuias servicoEnvio)
        {
            this.validacaoGuia = validacaoGuia;
            this.servicoEnvio = servicoEnvio;
        }

        public RespostaProcessamentoDto Processar(IGuiaProperties guia)
        {
            var errors = validacaoGuia.ObterValidacoes(guia);
            if (errors.Any())
                return new RespostaProcessamentoDto{ Erros = errors};

            servicoEnvio.Enviar(guia);

            //TODO: FALTOU FAZER TESTES PARA CLASSE VALIDACAO GUIA
            //TODO: FALTOU FAZER ENVIO DO SERVIÇO, BEM COMO TRATAMENTO DE ERRO E TESTS
            //TODO: FALTOU FAZER O SALVAR DA GUIA, BEM COMO TESTS

            return new RespostaProcessamentoDto();
        }
    }
}
