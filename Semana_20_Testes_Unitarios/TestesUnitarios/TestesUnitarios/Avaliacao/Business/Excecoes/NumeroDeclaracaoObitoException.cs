using System;

namespace TestesUnitarios.Avaliacao.Business.Excecoes
{
    public class NumeroDeclaracaoObitoException : Exception
    {
        public NumeroDeclaracaoObitoException()
            : base("Número de Declaração de Obito não informado!")
        {
        }
    }
}