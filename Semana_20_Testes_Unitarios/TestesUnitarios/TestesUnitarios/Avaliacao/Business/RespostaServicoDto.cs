using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class RespostaServicoDto
    {
        public bool Sucesso { get; set; }
        public IGuia GuiaProcessada { get; set; }
        public IEnumerable<string> Erros { get; set; }
    }
}