using BuilderPattern.PossivelUtilizacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.PossivelUtilizacao
{
    public class ExecutarBuilder
    {
        public void Executar()
        {
            var creator = GuiaDirectorGenerico<GuiaSadtBuilder>
                .NovaGuia()
                .Autorizacao(new Autorizacao())
                .Documentos("documento")
                .Anexos("anexos")
                .Gerar();

            var guia = creator.ObterGuia();
        }
    }
}
