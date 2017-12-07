using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestesUnitarios.Avaliacao.Dao;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Business
{
    public class FactoryValidacaoGuia
    {
        public ValidacaoGuia Obter()
        {
            return new ValidacaoGuia(new DespesasGuiaDao(new Dao<DespesasGuia, IDespesasGuiaProperties>()));
        }
    }
}
