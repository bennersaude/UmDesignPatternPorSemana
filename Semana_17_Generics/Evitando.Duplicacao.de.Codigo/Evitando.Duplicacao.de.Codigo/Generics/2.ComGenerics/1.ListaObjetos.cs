using Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._4.ReutilizandoEntidades.CodigoDuplicado;
using System.Collections;
using System.Collections.Generic;

namespace Evitando.Duplicacao.de.Codigo.Generics._2.ComGenerics
{
    public class ListaObjetos<T> : IEnumerable
    {
        private readonly T[] array;

        public ListaObjetos()
        {
            array = new T[] { };
        }

        public void Add(T valor)
        {
            array[array.Length + 1] = valor;
        }

        public T First()
        {
            return array[0];
        }

        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }

        public T this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var listaObjetos = new ListaObjetos<SamGuia> { new SamGuia() };
            var primeiraGuia = listaObjetos.First();
            primeiraGuia.Salvar();

            // Tipos Nativos C#

            var listaGuias = new List<SamGuia>();
            var filaGuias = new Queue<SamGuia>();
            var listaEncadeada = new LinkedList<SamGuia>();

            //System.Collections.Generic
        }
    }
}
