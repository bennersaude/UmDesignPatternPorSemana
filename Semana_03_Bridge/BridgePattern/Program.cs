namespace BridgePattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var controleRemotoSony = new ControleRemoto(new Sony());
            controleRemotoSony.Ligar();
            controleRemotoSony.Desligar();
            
            var controleRemotoSamsung = new ControleRemotoAnteriorProximoCanal(new Samsung());
            controleRemotoSamsung.Ligar();
            controleRemotoSamsung.ProximoCanal();
            controleRemotoSamsung.ProximoCanal();
            controleRemotoSamsung.CanalAnterior();
            controleRemotoSamsung.Desligar();
        }
    }
}