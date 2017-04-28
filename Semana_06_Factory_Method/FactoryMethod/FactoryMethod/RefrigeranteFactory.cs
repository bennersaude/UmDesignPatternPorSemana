namespace FactoryMethod
{
    public class RefrigeranteFactory 
    {
        public Refrigerante FazerRefrigerante(string tipo)
        {
            if (tipo.Equals("k"))
                return new RefrigeranteCola();
            if (tipo.Equals("p"))
                return new RefrigeranteLaranja();
            return null;
        }
    }
}
