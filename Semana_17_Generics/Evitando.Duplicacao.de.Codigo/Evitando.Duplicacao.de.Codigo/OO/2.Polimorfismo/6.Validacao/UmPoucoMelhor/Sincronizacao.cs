using Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._6.Validacao.CodigoDuplicado;

namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._6.Validacao.UmPoucoMelhor
{
    // Base Class

    public abstract class SincronizacaoUsuarioBase
    {
        protected abstract string ObterEmail(long handleUsuario);

        public ValidacaoDto VerificarAutenticidadeEmail(long handleUsuario, string emailInformado)
        {
            var emailSincronizado = ObterEmail(handleUsuario);

            if (string.IsNullOrEmpty(emailSincronizado))
                return new ValidacaoDto { Mensagem = "Não foi encontrado email em seu cadastro" };

            if (emailSincronizado != emailInformado)
                return new ValidacaoDto { Mensagem = "O email informado é diferente" };

            return new ValidacaoDto { Resultado = true, Mensagem = "Sucesso!" };
        }
    }

    // Beneficiario

    public class SincronizacaoBeneficiario : SincronizacaoUsuarioBase
    {
        protected override string ObterEmail(long handleUsuario)
        {
            return Beneficiario.Get(handleUsuario).Email;
        }
    }

    // Prestador 

    public class SincronizacaoPrestador : SincronizacaoUsuarioBase
    {
        protected override string ObterEmail(long handleUsuario)
        {
            return Prestador.Get(handleUsuario).Email;
        }
    }

    // Contratante

    public class SincronizacaoContratante : SincronizacaoUsuarioBase
    {
        protected override string ObterEmail(long handleUsuario)
        {
            return Contratante.Get(handleUsuario).Email;
        }
    }
}
