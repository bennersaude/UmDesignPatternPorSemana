using System;

namespace Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._6.Validacao.CodigoDuplicado
{
    // Beneficiario

    public class SincronizacaoBeneficiario
    {
        public ValidacaoDto VerificarAutenticidadeEmail(long handleUsuario, string emailInformado)
        {
            var usuario = Beneficiario.Get(handleUsuario);
            var emailSincronizado = usuario.Email;

            if (string.IsNullOrEmpty(emailSincronizado))
                return new ValidacaoDto { Mensagem = "Não foi encontrado email em seu cadastro" };

            if (emailSincronizado != emailInformado)
                return new ValidacaoDto { Mensagem = "O email informado é diferente"};

            return new ValidacaoDto { Resultado = true, Mensagem = "Sucesso!" };
        }
    }

    // Prestador

    public class SincronizacaoPrestador
    {
        public ValidacaoDto VerificarAutenticidadeEmail(long handleUsuario, string emailInformado)
        {
            var usuario = Prestador.Get(handleUsuario);
            var emailSincronizado = usuario.Email;

            if (string.IsNullOrEmpty(emailSincronizado))
                return new ValidacaoDto { Mensagem = "Não foi encontrado email em seu cadastro" };

            if (emailSincronizado != emailInformado)
                return new ValidacaoDto { Mensagem = "O email informado é diferente" };

            return new ValidacaoDto { Resultado = true, Mensagem = "Sucesso!" };
        }
    }

    //Contratante

    public class SincronizacaoContratante
    {
        public ValidacaoDto VerificarAutenticidadeEmail(long handleUsuario, string emailInformado)
        {
            var usuario = Contratante.Get(handleUsuario);
            var emailSincronizado = usuario.Email;

            if (string.IsNullOrEmpty(emailSincronizado))
                return new ValidacaoDto { Mensagem = "Não foi encontrado email em seu cadastro" };

            if (emailSincronizado != emailInformado)
                return new ValidacaoDto { Mensagem = "O email informado é diferente" };

            return new ValidacaoDto { Resultado = true, Mensagem = "Sucesso!" };
        }
    }
}
