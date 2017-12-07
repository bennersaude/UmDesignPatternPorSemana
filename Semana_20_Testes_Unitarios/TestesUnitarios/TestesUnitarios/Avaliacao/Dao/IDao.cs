using Benner.Tecnologia.Common;
using System.Collections.Generic;
using TestesUnitarios.Avaliacao.Entidades;

namespace TestesUnitarios.Avaliacao.Dao
{
    public interface IDao<TInterfaceEntidadeProperties>
    {
        TInterfaceEntidadeProperties GetFirstOrDefault(Handle handle);

        TInterfaceEntidadeProperties GetFirstOrDefault(Handle handle, GetMode getMode);

        EntityDefinition ObterDefinicao();

        TInterfaceEntidadeProperties GetFirstOrDefault(Criteria criteria);

        TInterfaceEntidadeProperties GetFirstOrDefault(Criteria criteria, GetMode getMode);

        TInterfaceEntidadeProperties Create();

        void Save<TEntidadeConcreta>(TInterfaceEntidadeProperties entidade) where TEntidadeConcreta : EntityBase, TInterfaceEntidadeProperties, new();

        void DeleteMany(Criteria criteria);

        IEnumerable<TInterfaceEntidadeProperties> GetMany(Criteria criteria);

        IEnumerable<TInterfaceEntidadeProperties> GetMany(Criteria criteria, GetMode getMode);

        IEnumerable<TInterfaceEntidadeProperties> GetMany(EntityDefinition entityDefinition, Criteria criteria);

        bool Exists(Criteria criterio);

        long CountMany(Criteria criterio);
    }
}

