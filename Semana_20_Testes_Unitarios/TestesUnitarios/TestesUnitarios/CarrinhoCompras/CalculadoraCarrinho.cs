using System.Linq;

namespace TestesUnitarios.CarrinhoCompras
{
    public class CalculadoraCarrinho
    {
        public double ObterMaiorValor(CarrinhoComprasLista carrinho)
        {
            if (!carrinho.Any()) return 0;

            return carrinho.Max(item => item.ValorTotal);
        }
    }
}
