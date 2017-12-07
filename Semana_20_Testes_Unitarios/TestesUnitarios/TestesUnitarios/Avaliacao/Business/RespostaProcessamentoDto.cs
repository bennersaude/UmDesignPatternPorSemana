using System;
using System.Collections.Generic;

namespace TestesUnitarios.Avaliacao.Business
{
    public class RespostaProcessamentoDto
    {
        public bool Sucesso { get; set; }
        public long? Handle { get; set; }
        public IEnumerable<Exception> Erros { get; set; }
    }
}