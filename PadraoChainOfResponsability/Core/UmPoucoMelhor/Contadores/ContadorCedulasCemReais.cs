namespace PadraoChainOfResponsability.UmPoucoMelhor.Contadores
{
    public class ContadorCedulasCemReais : ContadorCedulas
    {
        public override double Sacar(double montante)
        {
            return SacarCedulas(montante, 100);
        }
    }
}
