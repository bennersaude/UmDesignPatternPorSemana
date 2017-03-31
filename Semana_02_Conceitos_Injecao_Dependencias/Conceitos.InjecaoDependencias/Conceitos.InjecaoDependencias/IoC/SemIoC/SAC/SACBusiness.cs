using Conceitos.InjecaoDependencias.IoC.Dummies.SAC;
using System.Collections.Generic;

namespace Conceitos.InjecaoDependencias.IoC.SemIoC.SAC
{
    public class SACBusiness
    {
        public List<SACModels> CarregarDadosSAC()
        {
            var dadosSAC = new List<SACModels>();

            var listaPorSac = new PorSacDAO().RetornarListaSAC();

            foreach (var sac in listaPorSac)
            {
                dadosSAC.Add(new SACModels()
                {
                    Nome = sac.Nome
                    // Preenchendo propriedades
                }
                );
            }
            return dadosSAC;
        }
    }
}
