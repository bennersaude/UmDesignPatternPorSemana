using System.Collections;
using System.Collections.Generic;

namespace Iterator
{
    class MenuEnumeratorGeneric : IEnumerator<MenuItem>
    {
        MenuItem[] _arrayMenuItem;
        private int posicao;

        public MenuEnumeratorGeneric(MenuItem[] arrayMenuItem)
        {
            _arrayMenuItem = arrayMenuItem;
            posicao = -1;
        }
        public bool MoveNext()
        {
            posicao++;
            return posicao < _arrayMenuItem.Length;
        }

        public void Reset()
        {
            posicao = 0;
        }


        public void Dispose()
        {
            _arrayMenuItem = null;
        }

        public MenuItem Current
        {
            get { return _arrayMenuItem[posicao]; }
        }

        object IEnumerator.Current
        {
            get { return Current; }
        }
    }
}
