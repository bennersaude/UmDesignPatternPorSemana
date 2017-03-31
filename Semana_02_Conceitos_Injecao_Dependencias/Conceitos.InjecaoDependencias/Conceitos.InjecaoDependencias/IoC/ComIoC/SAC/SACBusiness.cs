using Conceitos.InjecaoDependencias.IoC.Dummies.SAC;
using System.Collections.Generic;
using System.Linq;

namespace Conceitos.InjecaoDependencias.IoC.ComIoC.SAC
{
    public class SACBusiness
    {
        private PorSacDAO porSacDAO;

        public SACBusiness(PorSacDAO porSacDAO)
        {
            this.porSacDAO = porSacDAO;
        }

        public IEnumerable<SACModels> CarregarDadosSAC()
        {
            var listaPorSac = porSacDAO.RetornarListaSAC();

            return listaPorSac.Select(sac => new SACModels { Nome = sac.Nome });
        }
    }
}
