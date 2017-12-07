using System.Collections.Generic;

namespace TestesUnitarios.Avaliacao.Business
{
    public class RespostaProcessamentoDto
    {
        public RespostaProcessamentoDto()
        {
            Sucesso = true;
            Erros = new List<string>();
        }

        public bool Sucesso { get; set; }
        public long? Handle { get; set; }
        public List<string> Erros { get; set; }
    }
}
