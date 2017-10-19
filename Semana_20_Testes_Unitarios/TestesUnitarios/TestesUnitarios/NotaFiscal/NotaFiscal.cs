using System;

namespace TestesUnitarios.NotaFiscal
{
    public class NotaFiscal
    {
        public string Cliente { get; private set; }
        public double Valor { get; private set; }
        public DateTime Data { get; private set; }
        public NotaFiscal(String cliente, double valor, DateTime data)
        {
            this.Cliente = cliente;
            this.Valor = valor;
            this.Data = data;
        }
    }
}
