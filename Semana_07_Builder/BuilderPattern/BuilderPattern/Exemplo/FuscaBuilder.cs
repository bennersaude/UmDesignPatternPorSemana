using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Exemplo
{
    public class FuscaBuilder : VeiculoBuilder
    {
        public override void Fabricante()
        {
            veiculo.Fabricante = "Volkswagen";
        }

        public override void VelocidadeMax()
        {
            veiculo.VelocidadeMax = "100km";
        }
    }
}
