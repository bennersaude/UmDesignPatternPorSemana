using Evitando.Duplicacao.de.Codigo.OO._2.Polimorfismo._4.ReutilizandoEntidades.CodigoDuplicado;
using System.Collections;

namespace Evitando.Duplicacao.de.Codigo.Generics._1.SemGenerics
{
    // Não esquece de abrir os slides antes do código!!!!

    public class ListaObjetos : IEnumerable
    {
        private readonly object[] array;

        public ListaObjetos()
        {
            array = new object[] { };
        }

        public void Add(object valor)
        {
            array[array.Length + 1] = valor;
        }

        public object First()
        {
            return array[0];
        }

        // Precisamos implementar IEnumerable para
        // inicializar a lista como new Lista {1, 2, 3}
        public IEnumerator GetEnumerator()
        {
            return array.GetEnumerator();
        }

        public object this[int index]
        {
            get { return array[index]; }
            set { array[index] = value; }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var listaObjetos = new ListaObjetos {new SamGuia()};

            var primeiraGuia = listaObjetos.First();

            //SamGuia primeiraGuia = listaObjetos.First();
            //primeiraGuia.Salvar();

            //var agoraEhGuia = (SamGuia) primeiraGuia;
            //agoraEhGuia.Salvar();
        }
    }
}
