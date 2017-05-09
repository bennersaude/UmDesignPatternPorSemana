using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern.PossivelUtilizacao
{
    public class GuiaDirectorGenerico<T> where T : GuiaBuilder, new()
    {
        private readonly T guia;

        protected GuiaDirectorGenerico()
        {
            guia = new T();
        }

        public static GuiaDirectorGenerico<T> NovaGuia()
        {
            return new GuiaDirectorGenerico<T>();
        }

        public GuiaDirectorGenerico<T> Autorizacao(Autorizacao autorizacao)
        {
            guia.Autorizacao(autorizacao);
            return this;
        }

        public GuiaDirectorGenerico<T> Documentos(string documentos)
        {
            guia.Documentos(documentos);
            return this;
        }

        public GuiaDirectorGenerico<T> Anexos(string anexos)
        {
            guia.Anexos(anexos);
            return this;
        }

        public T Gerar()
        {
            return guia;
        }
    }
}
