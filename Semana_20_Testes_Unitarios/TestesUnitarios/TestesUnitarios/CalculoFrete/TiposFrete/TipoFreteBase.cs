namespace TestesUnitarios.CalculoFrete.TiposFrete
{
    public abstract class TipoFreteBase
    {
        protected decimal DistanciaMinima;

        protected decimal PorcentagemDistanciaMinima;
        protected decimal PorcentagemDistanciaMaxima;

        public decimal Calcular(decimal distancia)
        {
            if (distancia < DistanciaMinima)
                return distancia * PorcentagemDistanciaMinima;

            return distancia * PorcentagemDistanciaMaxima;
        }
    }
}