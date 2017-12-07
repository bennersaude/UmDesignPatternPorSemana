using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business.Processamento
{
    public class ProcessadorGuia
    {
        private IValidadorGuia _validador;
        private IDao<IGuiaProperties> _daoGuia;
        private IGuiaProperties _guia;
        private IServicoEnvioGuias _servicoEnvio;

        public ProcessadorGuia(IValidadorGuia validador, IDao<IGuiaProperties> daoGuia, IServicoEnvioGuias servicoEnvio)
        {
            _validador = validador;
            _daoGuia = daoGuia;
            _servicoEnvio = servicoEnvio;
        }

        public ProcessadorGuia() : 
            this(new ValidadorGuia(new Dao<DespesasGuia, IDespesasGuiaProperties>()), new Dao<Guia, IGuiaProperties>(), new ServicoEnvioGuias())
        {
        }

        public RespostaProcessamentoDto Processar(IGuiaProperties guia)
        {
            _guia = guia;
            var resposta = ValidarGuia();
            if (!resposta.Sucesso)
                return resposta;

            resposta = EnviarGuia();
            if (!resposta.Sucesso)
                return resposta;

            _daoGuia.Save<Guia>(guia);
            resposta.Handle = guia.Handle;

            return resposta;
        }

        private RespostaProcessamentoDto ValidarGuia()
        {
            return _validador.Validar(_guia);
        }

        private RespostaProcessamentoDto EnviarGuia()
        {
            var retornoServico = _servicoEnvio.EnviarGuia(_guia);
            return new RespostaProcessamentoDto()
            {
                Erros = retornoServico.Erros,
                Sucesso = retornoServico.Sucesso
            };
        }
    }
}
