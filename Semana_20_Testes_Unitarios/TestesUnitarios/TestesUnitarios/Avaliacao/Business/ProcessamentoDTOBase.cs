using System.Collections.Generic;

namespace TestesUnitarios.Avaliacao.Business
{
    public class ProcessamentoDTOBase
    {
        public bool Sucesso { get; set; }
        public IEnumerable<string> Erros { get; set; }
    }
}
