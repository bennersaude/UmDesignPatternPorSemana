using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.ExemploBasico
{
    public class FuscaBuilder : IVeiculoBuilder
    {
        private Veiculo Fusca;

        public FuscaBuilder(){
            Fusca = new Veiculo();
        }

        public void Fabricante()
        {
            Fusca.Fabricante = "Volkswagen";
        }

        public void VelocidadeMax()
        {
            Fusca.VelocidadeMax = "100km";
        }

        public Veiculo ObterVeiculo()
        {
            return Fusca;
        }
    }
}
