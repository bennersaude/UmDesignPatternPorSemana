using Decorator.Base;
using Decorator.Decorator;

namespace Decorator.Adicionais
{
    public class Refrigerante : CoquetelDecorator
    {
        public Refrigerante(Coquetel coquetel) : base(coquetel)
        {
            Nome = "Refrigerante";
            Preco = 1;
        }
    }
}
 