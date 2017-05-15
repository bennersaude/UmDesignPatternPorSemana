namespace PrototypeConsole.Exemplo.Prototipos
{
    public abstract class FuncionarioAbstract
    {
        public string Nome { get; set; }
        public string Cargo { get; set; }
        public string Projeto { get; set; }

        public FuncionarioAbstract Clone<FuncionarioAbstract>()
        {
            return (FuncionarioAbstract)MemberwiseClone();
        }

        public abstract string DetalhesFuncionario();
    }
}