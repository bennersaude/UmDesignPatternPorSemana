using BuilderPattern.ExemploBasico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    public class ExecutarBuilder
    {
        public void Executar()
        {
            var creatorEnzo = new VeiculoDirector(new EnzoBuilder());

            creatorEnzo.CriarVeiculo();

            var enzo = creatorEnzo.ObterVeiculo();

            var creatorFusca = new VeiculoDirector(new FuscaBuilder());

            creatorFusca.CriarVeiculo();

            var fusca = creatorFusca.ObterVeiculo();
        }
    }
}
