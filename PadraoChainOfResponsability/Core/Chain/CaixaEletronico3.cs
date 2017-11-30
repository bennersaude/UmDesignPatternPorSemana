using PadraoChainOfResponsability.Chain.Contadores;
using System;

namespace PadraoChainOfResponsability.Chain
{
    public class CaixaEletronico3
    {
        private ContadorCedulas contadorCem;

        public CaixaEletronico3()
        {
            contadorCem = new ContadorCedulasCemReais();
            var contadorCinquenta = new ContadorCedulasCinquentaReais();
            var contadorVinte = new ContadorCedulasVinteReais();
            var contadorDez = new ContadorCedulasDezReais();
            var contadorCinco = new ContadorCedulasCincoReais();
            var contadorDois = new ContadorCedulasDoisReais();
            var contadorSemCedulas = new ContadorSemCedulas();

            contadorCem.Proximo = contadorCinquenta;
            contadorCinquenta.Proximo = contadorVinte;
            contadorVinte.Proximo = contadorDez;
            contadorDez.Proximo = contadorCinco;
            contadorCinco.Proximo = contadorDois;
            contadorDois.Proximo = contadorSemCedulas;
        }

        public void Sacar(double quantia)
        {
            Console.WriteLine("Tentativa de Saque: " + quantia);

            quantia = contadorCem.Sacar(quantia);
        }
    }
}
