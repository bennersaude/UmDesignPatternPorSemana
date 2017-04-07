using System;

namespace Conceitos.InjecaoDependencias.ServiceLocator
{
    public interface IServiceLocator
    {
        void Register<TAbstracao, TImplementacao>(Func<TImplementacao> instance) where TImplementacao : class;
        TAbstracao Resolve<TAbstracao>() where TAbstracao : class;
    }
}