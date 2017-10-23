namespace TestesUnitarios.NotaFiscal
{
    public interface IEnvio
    {
        NotaFiscal NotaFiscalEnviada { get; set; }
        void EnviarEmail(NotaFiscal nota);
    }
}