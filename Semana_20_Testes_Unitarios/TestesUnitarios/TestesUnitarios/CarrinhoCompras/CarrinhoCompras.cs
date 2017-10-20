using System.Collections.Generic;
using System.Linq;

namespace TestesUnitarios.CarrinhoCompras
{
    public class CarrinhoComprasLista : List<Item>
    {
        public double ObterMaiorValor()
        {
            if (!this.Any()) return 0;

            return this.Max(item => item.ValorTotal);
        }
    }
}
