using System;

namespace PadraoChainOfResponsability.Chain.Contadores
{
    public abstract class ContadorCedulas
    {
        public ContadorCedulas Proximo { get; set; }

        protected double SacarCedulas(double montante, int valorCedula)
        {
            if (montante >= valorCedula)
            {
                var notas = (int)montante / valorCedula;
                Console.WriteLine(notas + " notas de " + valorCedula + " reais");
                montante -= notas * valorCedula;
            }

            return Proximo.Sacar(montante);
        }

        public abstract double Sacar(double montante);
    }
}
