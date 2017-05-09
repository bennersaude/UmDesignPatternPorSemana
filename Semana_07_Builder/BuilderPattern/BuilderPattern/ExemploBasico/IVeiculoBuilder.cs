using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.ExemploBasico
{
    public interface IVeiculoBuilder
    {
        void Fabricante();
        void VelocidadeMax();

        Veiculo ObterVeiculo();
    }
}
