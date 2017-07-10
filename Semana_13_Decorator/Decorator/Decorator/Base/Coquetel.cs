namespace Decorator.Base
{
    public abstract class Coquetel
    {
        protected string Nome;
        protected decimal Preco;

        public virtual string GetNome()
        {
            return Nome;
        }

        public virtual decimal GetPreco()
        {
            return Preco;
        }
    }
}
