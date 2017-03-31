namespace Conceitos.InjecaoDependencias.IoC.ComIoC.Entregas
{
    public class EntregaFrutas
    {
        private Fruta fruta;

        public EntregaFrutas(Fruta fruta)
        {
            this.fruta = fruta;
        }

        public Fruta Entregar()
        {
            return fruta;
        }
    }
}
