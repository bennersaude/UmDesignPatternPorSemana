using BuilderPattern.PossivelUtilizacao.Guias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.PossivelUtilizacao
{
    public class GuiaConsultaBuilder : GuiaBuilder
    {
        public GuiaConsultaBuilder()
        {
            guia = new GuiaConsulta();
        }
    }
}
