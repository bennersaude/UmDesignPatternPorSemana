namespace Iterator
{
    class MenuEnumerableBusiness
    {
        MenuItem[] arrayMenuItem = new MenuItem[]
           {
                new MenuItem("Beneficiários"),
                new MenuItem("Prestadores"),
                new MenuItem("Processamento de contas"),
                new MenuItem("Controle Financeiro"),
            };
        
        public void RunEnumerable()
        {
            var menuIterator = new MenuEnumerable(arrayMenuItem);

            foreach (MenuItem menuItem in menuIterator)
            {
                
            }
        }

    }
}
