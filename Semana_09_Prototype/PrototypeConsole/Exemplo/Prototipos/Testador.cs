using PrototypeConsole.Exemplo.Interface;

namespace PrototypeConsole.Exemplo.Prototipos
{
    public class Testador : FuncionarioAbstract, IFuncionario
    {
        public IFuncionario Clone()
        {
            return (IFuncionario)MemberwiseClone();
        }

        public override string DetalhesFuncionario()
        {
            return $"Nome: {Nome} - Cargo: {Cargo}, Projeto: {Projeto}";
        }
    }
}