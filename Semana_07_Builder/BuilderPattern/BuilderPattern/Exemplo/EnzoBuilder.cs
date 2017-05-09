using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Exemplo
{
    public class EnzoBuilder : VeiculoBuilder
    {
        public override void Fabricante()
        {
            veiculo.Fabricante = "Ferrari";
        }

        public override void VelocidadeMax()
        {
            veiculo.VelocidadeMax = "355km";
        }
    }
}
