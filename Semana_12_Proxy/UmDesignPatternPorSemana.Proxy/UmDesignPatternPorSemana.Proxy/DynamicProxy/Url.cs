using System;
using Castle.DynamicProxy;

namespace UmDesignPatternPorSemana.Proxy.DynamicProxy
{
    public class Url
    {
        public string For<TController, TReturn>(Func<TController, TReturn> expression) where TController : class
        {
            var interceptor = new ControllerInterceptor();
            var generator = new ProxyGenerator();

            var proxy = typeof(TController).IsInterface
                ? generator.CreateInterfaceProxyWithoutTarget<TController>(interceptor)
                : generator.CreateClassProxy<TController>(interceptor);

            expression(proxy);

            return $"minha-aplicacao/{interceptor.Classe}/{interceptor.Metodo}/{interceptor.Argumentos[0]}";
        }
    }
}