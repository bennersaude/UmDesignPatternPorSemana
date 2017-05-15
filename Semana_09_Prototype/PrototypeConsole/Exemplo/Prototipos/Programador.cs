using PrototypeConsole.Exemplo.Interface;

namespace PrototypeConsole.Exemplo.Prototipos
{
    public class Programador : FuncionarioAbstract, IFuncionario
    {
        public string Linguagem { get; set; }

        public IFuncionario Clone()
        {
            return (IFuncionario)MemberwiseClone();
        }

        public override string DetalhesFuncionario()
        {
            return $"Nome: {Nome} - Cargo: {Cargo}, Projeto: {Projeto}, Linguagem: {Linguagem}";
        }
    }
}