using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.ExemploBasico
{
    public class EnzoBuilder : IVeiculoBuilder
    {
        private Veiculo Enzo;

        public EnzoBuilder()
        {
            Enzo = new Veiculo();
        }

        public void Fabricante()
        {
            Enzo.Fabricante = "Ferrari";
        }

        public void VelocidadeMax()
        {
            Enzo.VelocidadeMax = "355km";
        }

        public Veiculo ObterVeiculo()
        {
            return Enzo;
        }
    }
}
