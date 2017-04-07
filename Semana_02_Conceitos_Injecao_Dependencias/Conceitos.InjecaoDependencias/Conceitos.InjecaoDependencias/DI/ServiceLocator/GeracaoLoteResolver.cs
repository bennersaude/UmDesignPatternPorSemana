using Conceitos.InjecaoDependencias.DI.Dummies;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos.InjecaoDependencias.DI.ServiceLocator
{
    public class GeracaoLoteResolver : IGeracaoLoteResolver
    {
        private IUnityContainer container;

        public GeracaoLoteResolver(IUnityContainer container)
        {
            this.container = container;
        }

        public IGeracaoLote ObterGeracaoLote(TipoGuia tipo)
        {
            return container.Resolve<IGeracaoLote>(tipo.ToString());
        }
    }
}
