namespace Iterator
{
    class MenuIteratorBusiness
    {
        MenuItem[] arrayMenuItem = new[]
            {
                new MenuItem("Beneficiários"),
                new MenuItem("Prestadores"),
                new MenuItem("Processamento de contas"),
                new MenuItem("Controle Financeiro"),
            };
        
        public void RunSimples()
        {
            for (int index = 0; index < arrayMenuItem.Length; index++)
            {
                var menuItem = arrayMenuItem[index];
            }
            
        }

        public void RunIterator()
        {
            var menuIterator = new MenuIterator(arrayMenuItem);
            
            while (menuIterator.HasNext())
            {
                var menuItem = (MenuItem)menuIterator.Next();
            }
        }

    }
}
