namespace TestesUnitarios.LojaVirtual.PrimeiroTeste
{
    public class Produto
    {
        public Produto(string nome, double valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public double Valor { get; private set; }
        public string Nome { get; private set; }
    }
}