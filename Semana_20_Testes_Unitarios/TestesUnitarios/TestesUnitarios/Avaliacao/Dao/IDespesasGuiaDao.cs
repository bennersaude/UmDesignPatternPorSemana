﻿using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Dao
{
    public interface IDespesasGuiaDao
    {
        IEnumerable<IDespesasGuia> ObterDespesasDaGuia(long handleGuia);
    }
}
