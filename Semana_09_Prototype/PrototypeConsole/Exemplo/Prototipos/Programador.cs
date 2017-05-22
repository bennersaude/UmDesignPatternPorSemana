using PrototypeConsole.Exemplo.Interface;

namespace PrototypeConsole.Exemplo.Prototipos
{
    public class Programador : FuncionarioAbstract, IFuncionario
    {
        public string Linguagem { get; set; }
        public Programador Afilhado { get; set; }

        public IFuncionario Clone()
        {
            var clone = (Programador)MemberwiseClone();

            clone.Afilhado = (Programador)Afilhado?.Clone();

            return clone;
        }

        public override string DetalhesFuncionario()
        {
            return $"Nome: {Nome} - Cargo: {Cargo}, Projeto: {Projeto}, Linguagem: {Linguagem}";
        }
    }
}