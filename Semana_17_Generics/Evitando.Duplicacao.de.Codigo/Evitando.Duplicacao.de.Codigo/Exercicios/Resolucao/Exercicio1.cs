namespace Evitando.Duplicacao.de.Codigo.Exercicios.Resolucao
{
    public abstract class ContatoBase
    {
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }

    public class Prestador : ContatoBase { }
    public class Beneficiario : ContatoBase { } 
    public class Contratante : ContatoBase { }
    public class ContatoDto : ContatoBase { }

    public class InformacoesContato<TEntidade> where TEntidade : ContatoBase
    {
        public ContatoDto ObterContato(TEntidade contato)
        {
            return new ContatoDto { Email = contato.Email, Endereco = contato.Endereco, Telefone = contato.Telefone };
        }
    }
}
