using System;
using System.Linq;
using TestesUnitarios.Avaliacao.Entidades;
using TestesUnitarios.Avaliacao.Validacoes;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ServicoEnvioGuias
    {
        private readonly IFactoryValidacoes factoryValidacoes;

        public ServicoEnvioGuias(IFactoryValidacoes factoryValidacoes)
        {
            this.factoryValidacoes = factoryValidacoes;
        }

        public void ProcessarGuia(Guia guia)
        {
            var respostaProcessamento = ValidarGuia(guia);
            if (respostaProcessamento.Sucesso)

                EnviarGuia(guia);
        }

        public RespostaServicoDto EnviarGuia(Guia guia)
        {
            return new RespostaServicoDto();
        }

        public RespostaProcessamentoDto ValidarGuia(Guia guia)
        {
            var respostaProcessamento = new RespostaProcessamentoDto();
            var validacoes = factoryValidacoes.ObeterValidacoes();

            foreach (var validacaoGuia in validacoes)
            {
                if (validacaoGuia.Validar(guia)) continue;
                respostaProcessamento.Sucesso = false;
                respostaProcessamento.Erros.Add(validacaoGuia.ObterMensagemErro());
            }

            return respostaProcessamento;
        }
    }
}
