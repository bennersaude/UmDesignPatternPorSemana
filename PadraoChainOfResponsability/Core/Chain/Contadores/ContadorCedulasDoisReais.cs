﻿namespace PadraoChainOfResponsability.Chain.Contadores
{
    public class ContadorCedulasDoisReais : ContadorCedulas
    {
        public override double Sacar(double montante)
        {
            return SacarCedulas(montante, 2);
        }
    }
}