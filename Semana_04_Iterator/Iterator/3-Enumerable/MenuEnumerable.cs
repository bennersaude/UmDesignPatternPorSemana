using System.Collections;

namespace Iterator
{
    class MenuEnumerable : IEnumerable
    {
        private readonly MenuItem[] _menuItens;

        public MenuEnumerable(MenuItem[] menuItens)
        {
            _menuItens = menuItens;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public MenuEnumerator GetEnumerator()
        {
            return new MenuEnumerator(_menuItens);
        }
    }
}
