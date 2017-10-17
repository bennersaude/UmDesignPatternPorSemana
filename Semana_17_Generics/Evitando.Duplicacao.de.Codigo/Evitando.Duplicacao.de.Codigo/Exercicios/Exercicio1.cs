using Evitando.Duplicacao.de.Codigo.OO;

namespace Evitando.Duplicacao.de.Codigo.Exercicios
{
    // Exercicio 1: Precisamos preencher as informações de contato do prestador,
    // beneficiário e contratante em um dto, atualmente nosso código esta duplicado
    // para cada uma das entidades, como podemos melhorar isso?

    public interface IContato
    {
        string Email { get; set; }
        string Telefone { get; set; }
        string Endereco { get; set; }
    }

    public class Prestador : Entidade<Prestador>, IContato
    {
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }

    public class Beneficiario : Entidade<Beneficiario>, IContato
    {
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }

    public class Contratante : Entidade<Contratante>, IContato
    {
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }

    public class ContatoDto : IContato
    {
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }

    public class InformacoesContato
    {
        public IContato ObterContato(IContato contato)
        {
            return new ContatoDto
            {
                Email = contato.Email,
                Endereco = contato.Endereco,
                Telefone = contato.Telefone
            };
        }
    }
}