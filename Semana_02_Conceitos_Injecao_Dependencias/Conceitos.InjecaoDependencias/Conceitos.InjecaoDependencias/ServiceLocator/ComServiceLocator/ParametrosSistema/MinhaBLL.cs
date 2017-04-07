namespace Conceitos.InjecaoDependencias.ServiceLocator.ComServiceLocator.ParametrosSistema
{
    public class MinhaBLL
    {
        public void Executar()
        {
            var requisicao = ServiceLocatorRegistration.Locator.Resolve<IRequisicaoCliente>();
            requisicao.GetSync("Minha-URL");
        }
    }
}
