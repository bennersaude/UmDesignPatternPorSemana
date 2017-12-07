using System;
using System.Linq;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ProcessamentoGuia
    {
        private ValidacaoGuia validacaoGuia;
        private IServicoEnvioGuias servicoEnvioGuias;
        private IGuiaDAO guiaDAO;

        public ProcessamentoGuia(IGuiaDAO guiaDAO, IServicoEnvioGuias servicoEnvioGuias)
        {
            validacaoGuia = new FactoryValidacaoGuia().Obter();
            servicoEnvioGuias = new ServicoEnvioGuias();
            this.guiaDAO = guiaDAO;
        }

        public RespostaProcessamentoDto ProcessarGuia(Guia guia)
        {
            var respostaProcessamentoDto = new RespostaProcessamentoDto();

            respostaProcessamentoDto.Erros = validacaoGuia.ValidarGuia(guia);
            respostaProcessamentoDto.Sucesso = false;

            if (respostaProcessamentoDto.Erros.Any())
            {
                return respostaProcessamentoDto;
            }
            else
            {
                var respostaServico = servicoEnvioGuias.EnviarGuia(guia);

                if (respostaServico.Sucesso)
                {
                    respostaProcessamentoDto.Sucesso = true;
                    respostaProcessamentoDto.Handle = guiaDAO.GravarGuia(guia).Handle;
                }
            }

            return respostaProcessamentoDto;
        }
    }
}