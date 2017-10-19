using System;

namespace TestesUnitarios.CalculoSalario
{
    public class CalculadoraSalario
    {
        public double Calcular(Funcionario funcionario)
        {
            if (funcionario.Cargo == Cargo.DBA)
                return funcionario.Salario * (funcionario.Salario > 2500 ? 0.75 : 0.85);
            else if (funcionario.Cargo == Cargo.DESENVOLVEDOR)
                return funcionario.Salario * (funcionario.Salario > 3000 ? 0.8 : 0.9);

            return funcionario.Salario;

        }
    }
}