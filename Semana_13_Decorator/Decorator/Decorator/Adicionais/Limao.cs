using Decorator.Base;
using Decorator.Decorator;

namespace Decorator.Adicionais
{
    public class Limao : CoquetelDecorator
    {
        public Limao(Coquetel coquetel) : base(coquetel)
        {
            Nome = "Limão";
            Preco = 0.6m;
        }
    }
}
