using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Exemplo
{
    public class VeiculoDirector<T> where T : VeiculoBuilder, new()
    {
        private readonly T builder;

        public VeiculoDirector()
        {
            this.builder = new T();
        }

        public Veiculo ObterVeiculo()
        {
            return builder.ObterVeiculo();
        }
    }
}
