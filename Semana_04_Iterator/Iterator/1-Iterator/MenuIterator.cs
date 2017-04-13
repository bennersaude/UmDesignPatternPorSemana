
namespace Iterator
{
    class MenuIterator : IIterator
    {
        readonly MenuItem[] _arrayMenuItem;
        private int posicao;
        public MenuIterator(MenuItem[] arrayMenuItem)
        {
            _arrayMenuItem = arrayMenuItem;
            posicao = 0;
        }

        public bool HasNext()
        {
            return posicao >= _arrayMenuItem.Length;
        }

        public object Next()
        {
            var menuItem = _arrayMenuItem[posicao];
            posicao++;
            return menuItem;
        }
    }
}
