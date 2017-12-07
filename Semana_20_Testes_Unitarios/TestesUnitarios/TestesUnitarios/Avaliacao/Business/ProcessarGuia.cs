using System.Linq;
using TestesUnitarios.Avaliacao.Business.Validacoes;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ProcessarGuia : IProcessarGuia
    {
        private readonly IValidacoesGuia validacoesGuia;
        private readonly IServicoEnvioGuias servicoEnvioGuias;
        private readonly IDao<IGuiaProperties> guiaDao;

        public ProcessarGuia(IValidacoesGuia validacoesGuia, IServicoEnvioGuias servicoEnvioGuias, 
            IDao<IGuiaProperties> guiaDao)
        {
            this.validacoesGuia = validacoesGuia;
            this.servicoEnvioGuias = servicoEnvioGuias;
            this.guiaDao = guiaDao;
        }

        public RespostaProcessamentoDto Processar(IGuiaProperties guia)
        {
            var validacoes = validacoesGuia.Validar(guia);

            if (validacoes.Any())
            {
                return new RespostaProcessamentoDto {Erros = validacoes, Sucesso = false};
            }

            var retornoServico = servicoEnvioGuias.EnviarGuia(guia);

            if (!retornoServico.Sucesso)
                return MapearDtoServicoParaDtoProcessamento(retornoServico);

            guiaDao.Save<Guia>(guia);

            return new RespostaProcessamentoDto
            {
                Sucesso = true,
                Handle = guia.Handle
            };
        }

        private RespostaProcessamentoDto MapearDtoServicoParaDtoProcessamento(RespostaServicoDto respostaServicoDto)
        {
            return new RespostaProcessamentoDto
            {
                Sucesso = respostaServicoDto.Sucesso,
                Erros = respostaServicoDto.Erros
            };
        }
    }
}