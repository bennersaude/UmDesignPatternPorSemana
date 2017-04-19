namespace Semana05.Facade.CancelamentoGuias
{
    public interface IPermissoesUsuario
    {
        bool UsuarioPodeAlterar<T>(long handle);
    }
}