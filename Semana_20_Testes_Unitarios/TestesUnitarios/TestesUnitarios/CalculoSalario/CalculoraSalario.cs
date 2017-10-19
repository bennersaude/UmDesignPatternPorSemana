namespace TestesUnitarios.CalculoSalario
{
    public class CalculoraSalario
    {
        public double Calcular(Funcionario funcionario)
        {
            if (funcionario.Cargo == Cargo.DBA) return funcionario.Salario * 0.75;

            return funcionario.Salario * 0.80;
        }
    }
}
