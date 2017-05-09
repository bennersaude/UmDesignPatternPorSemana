using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.PossivelUtilizacao
{
    public abstract class Guia
    {
        public Autorizacao Autorizacao { get; set; }
        public string Documentos { get; set; }
        public string Anexos { get; set; }
    }
}
