using System;
using System.Collections.Generic;

namespace Conceitos.InjecaoDependencias.ServiceLocator
{
    public class ServiceLocator : IServiceLocator
    {
        private IDictionary<Type, Func<object>> services;

        public ServiceLocator()
        {
            services = new Dictionary<Type, Func<object>>();
        }

        public void Register<TAbstracao, TImplementacao>(Func<TImplementacao> instance) where TImplementacao : class
        {
            services.Add(typeof(TAbstracao), instance);
        }

        public TAbstracao Resolve<TAbstracao>() where TAbstracao : class
        {
            return services[typeof(TAbstracao)]() as TAbstracao;
        }
    }
}
