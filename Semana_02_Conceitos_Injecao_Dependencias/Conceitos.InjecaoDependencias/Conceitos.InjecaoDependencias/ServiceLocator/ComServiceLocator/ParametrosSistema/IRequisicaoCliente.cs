namespace Conceitos.InjecaoDependencias.ServiceLocator.ComServiceLocator.ParametrosSistema
{
    public interface IRequisicaoCliente
    {
        object GetSync(string uriServico);
    }
}