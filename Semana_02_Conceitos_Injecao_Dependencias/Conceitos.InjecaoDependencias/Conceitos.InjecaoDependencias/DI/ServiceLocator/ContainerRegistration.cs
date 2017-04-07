using Conceitos.InjecaoDependencias.DI.Dummies;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Conceitos.InjecaoDependencias.DI.ServiceLocator
{
    class ContainerRegistration
    {
        public void Register(IUnityContainer container)
        {
            container.RegisterType<IGeracaoLote, GeracaoLote<GuiaSadt>>(TipoGuia.Sadt.ToString());
            container.RegisterType<IGeracaoLote, GeracaoLote<GuiaInternacao>>(TipoGuia.Internacao.ToString());
            container.RegisterType<IGeracaoLoteResolver, GeracaoLoteResolver>();
        }
    }
}
