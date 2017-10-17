using Evitando.Duplicacao.de.Codigo.OO;

namespace Evitando.Duplicacao.de.Codigo.Exercicios.Resolucao
{
    public class ValidacaoDto
    {
        public bool Resultado { get; set; }
        public string Mensagem { get; set; }
    }

    public abstract class ValidacaoDocumentoBase
    {
        public abstract string ObterCadastrado(string documento);

        public ValidacaoDto Validar(string documentoInformado)
        {
            var cadastrado = ObterCadastrado(documentoInformado);

            if (string.IsNullOrEmpty(cadastrado))
                return new ValidacaoDto { Mensagem = "Não foi encontrado documento em seu cadastro" };

            if (cadastrado != documentoInformado)
                return new ValidacaoDto { Mensagem = "O documento informado é diferente" };

            return new ValidacaoDto { Resultado = true, Mensagem = "Sucesso!" };
        }
    }

    public class ValidarCpfBeneficiario : ValidacaoDocumentoBase
    {
        public override string ObterCadastrado(string documento)
        {
            var criteria = new Criteria("WHERE CPF = :CPF", documento);
            return SamBeneficiario.GetFirstOrDefault(criteria).Cpf;
        }
    }

    public class ValidarCnpjPrestador : ValidacaoDocumentoBase
    {
        public override string ObterCadastrado(string documento)
        {
            var criteria = new Criteria("WHERE CNPJ = :CNPJ", documento);
            return SamBeneficiario.GetFirstOrDefault(criteria).Cpf;
        }
    }

    public class ValidarCpfCnpjPrestador : ValidacaoDocumentoBase
    {
        public override string ObterCadastrado(string documento)
        {
            var criteria = new Criteria("WHERE CPF_CNPJ = :CPF_CNPJ", documento);
            return SamBeneficiario.GetFirstOrDefault(criteria).Cpf;
        }
    }

}
