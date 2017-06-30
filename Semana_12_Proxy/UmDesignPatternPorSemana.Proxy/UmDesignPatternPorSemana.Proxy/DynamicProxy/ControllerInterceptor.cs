using Castle.DynamicProxy;

namespace UmDesignPatternPorSemana.Proxy.DynamicProxy
{
    public class ControllerInterceptor : IInterceptor
    {
        public string Metodo { get; set; }
        public string Classe { get; set; }
        public object[] Argumentos { get; set; }

        public void Intercept(IInvocation invocation)
        {
            Metodo = invocation.Method.Name;
            Classe = invocation.Method.DeclaringType?.Name.TrimStart('I').Replace("Controller", string.Empty);
            Argumentos = invocation.Arguments;
        }
    }
}