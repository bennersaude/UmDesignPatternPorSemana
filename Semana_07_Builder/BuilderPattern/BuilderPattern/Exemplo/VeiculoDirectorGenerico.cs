using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Exemplo
{
    public class VeiculoDirectorGenerico<T> where T : VeiculoBuilder, new()
    {
        private readonly T veiculo;

        protected VeiculoDirectorGenerico()
        {
            veiculo = new T();
        }

        public static VeiculoDirectorGenerico<T> NovoVeiculo()
        {
            return new VeiculoDirectorGenerico<T>();
        }

        public VeiculoDirectorGenerico<T> Cor(string cor)
        {
            veiculo.Cor(cor);
            return this;
        }

        public VeiculoDirectorGenerico<T> TipoDoAssento(string tipoAssento)
        {
            veiculo.TipoDoAssento(tipoAssento);
            return this;
        }

        public T Gerar()
        {
            return veiculo;
        }
    }
}
