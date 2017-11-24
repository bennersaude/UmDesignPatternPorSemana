namespace TestesUnitarios.EnvioLote
{
    public interface IServicoEnvioLote
    {
        RespostaEnvioLoteDto Enviar(Lote lote);
    }
}
