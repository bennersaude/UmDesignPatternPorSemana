using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Exemplo
{
    public abstract class VeiculoBuilder
    {
        protected Veiculo veiculo;

        public VeiculoBuilder()
        {
            veiculo = new Veiculo();
            Fabricante();
            VelocidadeMax();
        }

        public abstract void Fabricante();
        public abstract void VelocidadeMax();

        public void Cor(string cor)
        {
            veiculo.Cor = cor;
        }

        public void TipoDoAssento(string tipoAssento)
        {
            veiculo.Assento = tipoAssento;
        }

        public Veiculo ObterVeiculo()
        {
            return veiculo;
        }
    }
}
