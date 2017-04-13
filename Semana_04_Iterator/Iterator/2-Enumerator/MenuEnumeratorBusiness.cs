namespace Iterator
{
    class MenuEnumeratorBusiness
    {
        MenuItem[] arrayMenuItem = new[]
           {
                new MenuItem("Beneficiários"),
                new MenuItem("Prestadores"),
                new MenuItem("Processamento de contas"),
                new MenuItem("Controle Financeiro"),
            };

        public void RunEnumerator()
        {
            var menuEnumerator = new MenuEnumerator(arrayMenuItem);
            while (menuEnumerator.MoveNext())
            {
                MenuItem menuItem = (MenuItem)menuEnumerator.Current;
            }

        }

        public void RunEnumeratorGeneric()
        {
            var menuIterator = new MenuEnumeratorGeneric(arrayMenuItem);

            while (menuIterator.MoveNext())
            {
                var menuItem = menuIterator.Current;
                
            }
        }

    }
}
