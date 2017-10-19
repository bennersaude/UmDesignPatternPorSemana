namespace TestesUnitarios.Tests.LojaVirtual.Validacao.Asserts
{
    public class FactoryParametrosSistemas
    {
        public IParametrosSistema ObterParametros(bool debug)
        {
            if (debug) return new ParametrosSistemaLocal();

            return new ParametrosSistemaEntidade();
        }
    }

    public interface IParametrosSistema { }

    public class ParametrosSistemaEntidade : IParametrosSistema { }

    public class ParametrosSistemaLocal : IParametrosSistema { }
}
