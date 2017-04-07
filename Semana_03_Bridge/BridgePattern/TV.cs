using System;

namespace BridgePattern
{
    public interface ITV
    {
        void Ligar();
        void Desligar();
        void SintonizarCanal(int canal);
    }

    internal abstract class TV : ITV
    {
        public virtual void Ligar()
        {
            Console.WriteLine($"{GetType().Name}: Ligando...");
        }

        public virtual void Desligar()
        {
            Console.WriteLine($"{GetType().Name}: Desligando...");
        }

        public virtual void SintonizarCanal(int canal)
        {
            Console.WriteLine($"{GetType().Name}: Sintonizando Canal {canal}...");
        }
    }

    internal class Samsung : TV
    {
    }

    internal class Sony : TV
    {
    }
}