﻿namespace PadraoChainOfResponsability.Chain.Contadores
{
    public class ContadorCedulasCinquentaReais : ContadorCedulas
    {
        public override double Sacar(double montante)
        {
            return SacarCedulas(montante, 50);
        }
    }
}