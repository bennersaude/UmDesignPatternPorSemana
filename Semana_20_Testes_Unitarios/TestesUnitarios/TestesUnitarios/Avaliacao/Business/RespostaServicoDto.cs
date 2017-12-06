using System.Collections.Generic;

namespace TestesUnitarios.Avaliacao.Business
{
    public class RespostaServicoDto
    {
        public bool Sucesso { get; set; }
        public IEnumerable<string> Erros { get; set; }
    }
}