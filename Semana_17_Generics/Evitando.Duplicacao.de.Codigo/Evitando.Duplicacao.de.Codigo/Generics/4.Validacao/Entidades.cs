using Evitando.Duplicacao.de.Codigo.OO;

namespace Evitando.Duplicacao.de.Codigo.Generics._4.Validacao
{
    public interface IUsuarioComEmail
    {
        string Email { get; set; }
    }

    public class Beneficiario : Entidade<Beneficiario>, IUsuarioComEmail
    {
        public string Email { get; set; }
    }

    public class Prestador : Entidade<Prestador>, IUsuarioComEmail
    {
        public string Email { get; set; }
    }

    public class Contratante : Entidade<Contratante>, IUsuarioComEmail
    {
        public string Email { get; set; }
    }

    public class ValidacaoDto
    {
        public bool Resultado { get; set; }
        public string Mensagem { get; set; }
    }
}
