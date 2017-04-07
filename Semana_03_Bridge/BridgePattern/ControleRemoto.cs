namespace BridgePattern
{
    public class ControleRemoto
    {
        private readonly ITV tv;

        public ControleRemoto(ITV tv)
        {
            this.tv = tv;
        }

        public void Ligar()
        {
            tv.Ligar();
        }

        public void Desligar()
        {
            tv.Desligar();
        }

        public void SintonizarCanal(int canal)
        {
            tv.SintonizarCanal(canal);
        }
    }
}