namespace BridgePattern
{
    public class ControleRemotoAnteriorProximoCanal : ControleRemoto
    {
        private int canalAtual;

        public ControleRemotoAnteriorProximoCanal(ITV tv) 
            : base(tv)
        {
        }

        public void ProximoCanal()
        {
            SintonizarCanal(++canalAtual);
        }

        public void CanalAnterior()
        {
            SintonizarCanal(--canalAtual);
        }
    }
}