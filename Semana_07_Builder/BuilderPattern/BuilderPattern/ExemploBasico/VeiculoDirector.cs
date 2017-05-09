using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.ExemploBasico
{
    public class VeiculoDirector
    {
        private IVeiculoBuilder builder;

        public VeiculoDirector(IVeiculoBuilder builder)
        {
            this.builder = builder;
        }

        public void CriarVeiculo()
        {
            builder.Fabricante();
            builder.VelocidadeMax();
        }

        public Veiculo ObterVeiculo()
        {
            return builder.ObterVeiculo();
        }
    }
}
