using System.Collections;

namespace Iterator
{
    class MenuEnumerator : IEnumerator
    {

        readonly MenuItem[] _arrayMenuItem;
        private int posicao;

        public MenuEnumerator(MenuItem[] arrayMenuItem)
        {
            _arrayMenuItem = arrayMenuItem;
            Reset();
        }
        public bool MoveNext()
        {
            posicao++;
            return posicao < _arrayMenuItem.Length;
        }

        public void Reset()
        {
            posicao = -1;
        }

        public object Current
        {
            get
            {
                return _arrayMenuItem[posicao];
            }
        }
    }
}
