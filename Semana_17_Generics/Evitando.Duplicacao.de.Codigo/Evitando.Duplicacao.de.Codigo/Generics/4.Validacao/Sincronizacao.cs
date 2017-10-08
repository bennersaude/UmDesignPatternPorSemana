using Evitando.Duplicacao.de.Codigo.OO;

namespace Evitando.Duplicacao.de.Codigo.Generics._4.Validacao
{
    // Sincronizacao

    public class SincronizacaoUsuarios<T> where T : Entidade<T>, IUsuarioComEmail
    {
        public ValidacaoDto VerificarAutenticidadeEmail(long handleUsuario, string emailInformado)
        {
            var usuario = Entidade<T>.Get(handleUsuario);
            var emailSincronizado = usuario.Email;

            if (string.IsNullOrEmpty(emailSincronizado))
                return new ValidacaoDto { Mensagem = "Não foi encontrado email em seu cadastro" };

            if (emailSincronizado != emailInformado)
                return new ValidacaoDto { Mensagem = "O email informado é diferente" };

            return new ValidacaoDto { Resultado = true, Mensagem = "Sucesso!" };
        }
    }

    // Utilizando

    class Program
    {
        static void Main(string[] args)
        {
            new SincronizacaoUsuarios<Beneficiario>();
            new SincronizacaoUsuarios<Contratante>();
            new SincronizacaoUsuarios<Prestador>();
        }
    }
}
