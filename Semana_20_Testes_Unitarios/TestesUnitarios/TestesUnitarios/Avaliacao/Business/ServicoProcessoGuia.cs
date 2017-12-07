using System;
using System.Linq;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ServicoProcessoGuia : IServicoProcessoGuia
    {
        private IServicoEnvioGuias _servicoGuias;
        private IDao<IGuiaProperties> _daoBase;
        private IDao<IDespesasGuiaProperties> _daoBaseDespesas;

        public ServicoProcessoGuia(IServicoEnvioGuias servicoGuia, IDao<IGuiaProperties> daoBase, IDao<IDespesasGuiaProperties> daoBaseDespesas)
        {
            _servicoGuias = servicoGuia;
            _daoBase = daoBase;
            _daoBaseDespesas = daoBaseDespesas;
        }

        public ServicoProcessoGuia()
            : this(new ServicoEnvioGuias(), new Dao<Guia, IGuiaProperties>(), new Dao<DespesasGuia, IDespesasGuiaProperties>())
        {
        }

        public RespostaProcessamentoDto ProcessarGuia(Guia guia)
        {
            var repostaProcessamento = new RespostaProcessamentoDto();

            if (ValidacoesGuia(guia))
            {
                var repostaEnvioGuia = _servicoGuias.EnviarGuia(guia);

                if (repostaEnvioGuia.Sucesso)
                {
                    _daoBase.Save<Guia>(guia);
                    repostaProcessamento.Handle = guia.Handle;
                }
                else
                {
                    repostaProcessamento.Erros = repostaProcessamento.Erros.Concat(new[] { "Erro ao enviar a guia" });
                }
            }

            return repostaProcessamento;
        }

        private bool ValidacoesGuia(Guia guia)
        {
            //var listaValidacoes = new List<RespostaProcessamentoDto>();
            //var resposta = new RespostaProcessamentoDto();
            var dataAtendimentoMinima = new DateTime(2000, 01, 01);
            var guiaValida = true;

            if (guia.DataAtendimento.Value.Date > DateTime.Now.Date || guia.DataAtendimento.Value.Date < dataAtendimentoMinima)
            {
                guiaValida = false;
                //resposta.Sucesso = false;
                //resposta.Erros = resposta.Erros.Concat(new[] { "Data de atendimento inválida" });
                //listaValidacoes.Add(resposta);
            }

            if (guia.IndicadorDeclaracaoObitoRn == true && guia.NumeroDeclaracaoObito.Equals(string.Empty))
            {
                guiaValida = false;
                //resposta.Sucesso = false;
                //resposta.Erros = resposta.Erros.Concat(new[] { "Número da declaração de óbito deve ser preenchido" });
                //listaValidacoes.Add(resposta);
            }

            var guiaDespesas = _daoBaseDespesas.GetFirstOrDefault(guia.Handle);

            if (guiaDespesas != null)
            {
                if ((guiaDespesas.TipoReducaoAcrescimo.Value != TipoReducaoAcrescimo.ItemSemReducaoAcrescimo) && guiaDespesas.ValorReducaoAcrescimo > 100)
                    guiaValida = false;
            }

            return guiaValida;
        }
    }
}