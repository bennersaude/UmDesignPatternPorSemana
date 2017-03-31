namespace Conceitos.InjecaoDependencias.DIP.ComDip.ParametrosSistema
{
    public interface IHttpClient
    {
        object GetSync(object parametros);
    }
}