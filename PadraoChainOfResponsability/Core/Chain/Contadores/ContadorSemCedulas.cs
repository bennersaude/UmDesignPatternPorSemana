using System;

namespace PadraoChainOfResponsability.Chain.Contadores
{
    public class ContadorSemCedulas : ContadorCedulas
    {
        public override double Sacar(double montante)
        {
            if(montante != 0)
                Console.WriteLine("Valor restante menor do que 2 reais. Impossivel sacar restante: " + montante);

            return montante;
        }
    }
}
