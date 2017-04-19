using Semana05.Facade.CancelamentoGuias;

namespace Semana05.Facade.CancelamentoGuiasSaudavel.Regras
{
    public class RegraPermissaoUsuario : IRegraCancelamentoGuia
    {
        private readonly IPermissoesUsuario permissoesUsuario;

        public RegraPermissaoUsuario(IPermissoesUsuario permissoesUsuario)
        {
            this.permissoesUsuario = permissoesUsuario;
        }

        public bool PodeCancelar(long handleGuia)
        {
            return permissoesUsuario.UsuarioPodeAlterar<Guia>(handleGuia);
        }
    }
}
