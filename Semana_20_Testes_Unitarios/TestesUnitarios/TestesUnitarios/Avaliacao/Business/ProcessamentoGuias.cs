using System;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ProcessamentoGuias
    {
        public ProcessamentoGuias()
        {
        }

        public RespostaProcessamentoDto Processar(IGuiaProperties guia)
        {
            return new RespostaProcessamentoDto();
        }
    }
}