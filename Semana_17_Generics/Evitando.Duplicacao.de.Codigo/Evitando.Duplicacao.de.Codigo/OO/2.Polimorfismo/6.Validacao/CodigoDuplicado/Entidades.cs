using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._6.Validacao.CodigoDuplicado
{
    public class Beneficiario : Entidade<Beneficiario>
    {
        public string Email { get; set; }
    }
    public class Prestador : Entidade<Prestador>
    {
        public string Email { get; set; }
    }
    public class Contratante : Entidade<Contratante>
    {
        public string Email { get; set; }
    }
    public class ValidacaoDto
    {
        public bool Resultado { get; set; }
        public string Mensagem { get; set; }
    }
}
