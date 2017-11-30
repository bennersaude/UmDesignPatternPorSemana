using PadraoChainOfResponsability.UmPoucoMelhor.Contadores;
using System;

namespace PadraoChainOfResponsability.UmPoucoMelhor
{
    public class CaixaEletronico2
    {
        private ContadorCedulas contadorCem;
        private ContadorCedulas contadorCinquenta;
        private ContadorCedulas contadorVinte;
        private ContadorCedulas contadorDez;
        private ContadorCedulas contadorCinco;
        private ContadorCedulas contadorDois;

        public CaixaEletronico2()
        {
            contadorCem = new ContadorCedulasCemReais();
            contadorCinquenta = new ContadorCedulasCinquentaReais();
            contadorVinte = new ContadorCedulasVinteReais();
            contadorDez = new ContadorCedulasDezReais();
            contadorCinco = new ContadorCedulasCincoReais();
            contadorDois = new ContadorCedulasDoisReais();
        }

        public void Sacar(double quantia)
        {
            Console.WriteLine("Tentativa de Saque: " + quantia);

            quantia = contadorCem.Sacar(quantia);
            if (quantia > 0)
                quantia = contadorCinquenta.Sacar(quantia);
            if (quantia > 0)
                quantia = contadorVinte.Sacar(quantia);
            if (quantia > 0)
                quantia = contadorDez.Sacar(quantia);
            if (quantia > 0)
                quantia = contadorCinco.Sacar(quantia);
            if (quantia > 0)
                quantia = contadorDois.Sacar(quantia);
            if (quantia > 0)
                Console.WriteLine("Valor restante menor do que 2 reais. Impossivel sacar restante: " + quantia);
        }
    }
}
