using Benner.Tecnologia.Common;
using System.Collections;
using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business.Processamento
{
    public class ProcessadorGuia
    {
        private IProcessadorGuia _validador;
        private IDao<IGuiaProperties> _daoGuia;
        private IGuiaProperties _guia;
        private IProcessadorGuia _servicoEnvio;
        private IList<IProcessadorGuia> _listaProcessadores = new List<IProcessadorGuia>();

        public ProcessadorGuia(IList<IProcessadorGuia> listaProcessadores, IDao<IGuiaProperties> daoGuia)
        {
            _daoGuia = daoGuia;
            _listaProcessadores = listaProcessadores;
        }

        public ProcessadorGuia() : 
            this(new List<IProcessadorGuia>() { new ValidadorGuia(new Dao<DespesasGuia, IDespesasGuiaProperties>()), new ServicoEnvioGuias() }, new Dao<Guia, IGuiaProperties>())
        {
        }

        public RespostaProcessamentoDto Executar(IGuiaProperties guia)
        {
            _guia = guia;
            foreach (var processador in _listaProcessadores)
            {
                var respostaDTO = processador.Executar(guia);
                if (!respostaDTO.Sucesso)
                    return new RespostaProcessamentoDto()
                    {
                        Erros = respostaDTO.Erros,
                        Sucesso = respostaDTO.Sucesso
                    };
            }

            var handleGuiaSalva = Salvar();

            return new RespostaProcessamentoDto()
            {
                Sucesso = true,
                Handle = handleGuiaSalva
            };
        }

        private Handle Salvar()
        {
            _daoGuia.Save<Guia>(_guia);
            return _guia.Handle;
        }

        private RespostaProcessamentoDto ValidarGuia()
        {
            return _validador.Executar(_guia) as RespostaProcessamentoDto;
        }

        private RespostaProcessamentoDto EnviarGuia()
        {
            var retornoServico = _servicoEnvio.Executar(_guia);
            return new RespostaProcessamentoDto()
            {
                Erros = retornoServico.Erros,
                Sucesso = retornoServico.Sucesso
            };
        }
    }
}
