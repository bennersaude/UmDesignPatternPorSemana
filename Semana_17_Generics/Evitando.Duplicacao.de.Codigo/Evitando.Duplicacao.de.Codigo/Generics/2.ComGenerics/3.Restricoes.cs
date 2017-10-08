using Evitando.Duplicacao.de.Codigo.OO._1.Heranca._1.ComHeranca;
using Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._4.ReutilizandoEntidades.CodigoDuplicado;
using Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._4.ReutilizandoEntidades.Refatorado;

namespace Evitando.Duplicacao.de.Codigo.Generics._2.ComGenerics
{
    // Tipos de valor que não podem ser nulos
    public class Structs<T> where T : struct
    {
        public Structs()
        {
            new Structs<int>();
            new Structs<long>();
            new Structs<bool>();
        }
    }

    // Tipos de referencia como classes, interfaces, delegates, arrays e matrizes
    public class Classes<T> where T : class
    {
        public Classes()
        {
            new Classes<string>();
            new Classes<Guia>();
            new Classes<Sadt>();
            new Classes<IGuia>();
            new Classes<int[]>();
            new Classes<int[][]>();
        }
    }

    // Tipo devem ter construtor publico sem parametros
    public class ConstrutoresSemParametros<T> where T : new()
    {
        public ConstrutoresSemParametros()
        {
            new ConstrutoresSemParametros<Guia>();

            //new ConstrutoresSemParametros<ConstrutoresComParametros>();
            //new ConstrutoresSemParametros<IGuia>();

        }
    }

    public class ConstrutoresComParametros
    {
        public ConstrutoresComParametros(string valor) { }
    }

    //Tipos devem derivar da classe guia
    public class BaseClass<T> where T: Guia
    {
        public BaseClass()
        {
            new BaseClass<Sadt>();
            new BaseClass<Internacao>();
        }
    }

    //Argumentos devem implementar a interface declarada
    public class ImplementamInterface<T> where T : IGuia
    {
        public ImplementamInterface()
        {
            new ImplementamInterface<SamGuia>();
            new ImplementamInterface<SamAutoriz>();
        }
    }

    //Tipos que implementam ou derivam um do outro
    public class DependenciaEntreParametros<T, U> where T : U
    {
        public DependenciaEntreParametros()
        {
            new DependenciaEntreParametros<SamGuia, IGuia>();
            new DependenciaEntreParametros<Sadt, Guia>();
        }
    }
}
