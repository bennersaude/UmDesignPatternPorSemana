using BuilderPattern.PossivelUtilizacao.Guias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.PossivelUtilizacao
{
    public class GuiaSadtBuilder : GuiaBuilder
    {
        public GuiaSadtBuilder()
        {
            guia = new GuiaSadt();
        }
    }
}
