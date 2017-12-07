using System;

namespace TestesUnitarios.Avaliacao.Business.Excecoes
{
    public class DataAtendimentoInvalidaException : Exception
    {
        public DataAtendimentoInvalidaException(string mensagem)
            : base(mensagem)
        {
        }
    }
}