namespace PadraoChainOfResponsability.UmPoucoMelhor.Contadores
{
    public class ContadorCedulasVinteReais : ContadorCedulas
    {
        public override double Sacar(double montante)
        {
            return SacarCedulas(montante, 20);
        }
    }
}
