namespace Conceitos.InjecaoDependencias.DIP.Dummies.ParametrosSistema
{
    public class PorConfigPortal
    {
        public static PorConfigPortal GetFirstOrDefault()
        {
            return null;
        }

        public string EnderecoCliente { get; set; }

        public string DiretorioTemporario { get; set; }
    }
}
