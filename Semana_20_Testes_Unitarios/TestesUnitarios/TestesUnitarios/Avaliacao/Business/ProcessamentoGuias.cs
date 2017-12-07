using System;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ProcessamentoGuias
    {
        private IValidadorGuias validador;

        public ProcessamentoGuias(IValidadorGuias validador)
        {
            this.validador = validador;
        }

        public RespostaProcessamentoDto Processar(IGuiaProperties guia)
        {
            if(validador.GuiaEhValida(guia))
                return new RespostaProcessamentoDto()
                {
                    Sucesso = true
                };

            throw new Exception("Guia não possui dados validos");
        }
    }

    public interface IValidadorGuias
    {
        bool GuiaEhValida(IGuiaProperties guia);
    }
}