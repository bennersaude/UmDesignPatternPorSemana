namespace PadraoChainOfResponsability.UmPoucoMelhor.Contadores
{
    public class ContadorCedulasDezReais : ContadorCedulas
    {
        public override double Sacar(double montante)
        {
            return SacarCedulas(montante, 10);
        }
    }
}
