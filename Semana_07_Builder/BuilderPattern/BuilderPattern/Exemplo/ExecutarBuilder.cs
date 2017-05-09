using BuilderPattern.Exemplo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.Exemplo
{
    public class ExecutarBuilder
    {
        public void Executar()
        {
            var creatorEnzo = new VeiculoDirector<EnzoBuilder>();

            var enzo = creatorEnzo.ObterVeiculo();

            var creator = VeiculoDirectorGenerico<FuscaBuilder>
                .NovoVeiculo()
                .Cor("vermelho")
                .TipoDoAssento("Couro")
                .Gerar();

            var fusca = creator.ObterVeiculo();
        }
    }
}
