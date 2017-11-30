using System;

namespace PadraoChainOfResponsability.UmPoucoMelhor.Contadores
{
    public abstract class ContadorCedulas
    {
        protected double SacarCedulas(double montante, int valorCedula)
        {
            if (montante >= valorCedula)
            {
                var notas = (int)montante / valorCedula;
                Console.WriteLine(notas + " notas de " + valorCedula + " reais");
                montante -= notas * valorCedula;
            }

            return montante;
        }

        public abstract double Sacar(double montante);
    }
}
