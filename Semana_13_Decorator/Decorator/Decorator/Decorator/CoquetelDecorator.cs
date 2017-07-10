using Decorator.Base;

namespace Decorator.Decorator
{
    public abstract class CoquetelDecorator : Coquetel
    {
        private readonly Coquetel coquetel;

        protected CoquetelDecorator(Coquetel coquetel)
        {
            this.coquetel = coquetel;
        }

        public override string GetNome()
        {
            return $"{coquetel.GetNome()} + {Nome}";
        }

        public override decimal GetPreco()
        {
            return coquetel.GetPreco() + Preco;
        }
    }
}
