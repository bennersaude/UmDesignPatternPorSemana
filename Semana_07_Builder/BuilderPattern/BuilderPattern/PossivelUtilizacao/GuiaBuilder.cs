using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.PossivelUtilizacao
{
    public abstract class GuiaBuilder
    {
        protected Guia guia;

        public void Autorizacao(Autorizacao autorizacao)
        {
            guia.Autorizacao = autorizacao;
        }

        public void Documentos(string documentos)
        {
            guia.Documentos = documentos;
        }

        public void Anexos(string anexos)
        {
            guia.Anexos = anexos;
        }

        public Guia ObterGuia()
        {
            return guia;
        }
    }
}
