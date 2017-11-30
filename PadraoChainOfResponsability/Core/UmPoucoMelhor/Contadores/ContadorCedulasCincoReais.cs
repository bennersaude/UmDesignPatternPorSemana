namespace PadraoChainOfResponsability.UmPoucoMelhor.Contadores
{
    public class ContadorCedulasCincoReais : ContadorCedulas
    {
        public override double Sacar(double montante)
        {
            return SacarCedulas(montante, 5);
        }
    }
}
