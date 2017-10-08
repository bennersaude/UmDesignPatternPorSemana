namespace Evitando.Duplicacao.de.Codigo.Generics._2.ComGenerics
{
    public class ClassesGenericas<T> 
    {
    }

    public interface InterfacesGenericas<T>
    {
    }

	public class ClassesComuns
    {
        public void ComMetodosGenericos<T>(T meuTipo)
        {

        }

        public ClassesComuns()
        {
            ComMetodosGenericos(new object());
        }
    }

    public class EventosDelegates<T>
    {
        public delegate void DelegatesGenericos<T>(T value);

        public event DelegatesGenericos<T> EventosGenericos;
    }
}
