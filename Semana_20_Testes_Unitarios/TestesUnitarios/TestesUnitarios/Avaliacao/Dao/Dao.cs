using Benner.Tecnologia.Business;
using Benner.Tecnologia.Common;
using System.Collections.Generic;

namespace TestesUnitarios.Avaliacao.Dao
{
    public sealed class Dao<TEntidadeConcreta, TInterfaceEntidadeProperties> : IDao<TInterfaceEntidadeProperties>
        where TEntidadeConcreta : EntityBase, TInterfaceEntidadeProperties, new()
    {
        public EntityDefinition ObterDefinicao()
        {
            return BusinessEntity<TEntidadeConcreta>.GetEntityDefinition();
        }

        public TInterfaceEntidadeProperties GetFirstOrDefault(Handle handle)
        {
            return GetFirstOrDefault(handle, GetMode.Raw);
        }

        public TInterfaceEntidadeProperties GetFirstOrDefault(Handle handle, GetMode getMode)
        {
            return BusinessEntity<TEntidadeConcreta>.GetFirstOrDefault(handle, getMode);
        }

        public TInterfaceEntidadeProperties GetFirstOrDefault(Criteria criteria)
        {
            return BusinessEntity<TEntidadeConcreta>.GetFirstOrDefault(criteria);
        }

        public TInterfaceEntidadeProperties GetFirstOrDefault(Criteria criteria, GetMode getMode)
        {
            return BusinessEntity<TEntidadeConcreta>.GetFirstOrDefault(criteria, getMode);
        }

        public TInterfaceEntidadeProperties Create()
        {
            return BusinessEntity<TEntidadeConcreta>.Create();
        }

        public void Save<TEntidade>(TInterfaceEntidadeProperties entidade) where TEntidade : EntityBase, TInterfaceEntidadeProperties, new()
        {
            ((TEntidade)entidade).Save();
        }

        public void DeleteMany(Criteria criteria)
        {
            BusinessEntity<TEntidadeConcreta>.DeleteMany(criteria);
        }

        public IEnumerable<TInterfaceEntidadeProperties> GetMany(Criteria criteria)
        {
            return BusinessEntity<TEntidadeConcreta>.GetMany(criteria);
        }

        public bool Exists(Criteria criteria)
        {
            return BusinessEntity<TEntidadeConcreta>.Exists(criteria);
        }

        public long CountMany(Criteria criteria)
        {
            return BusinessEntity<TEntidadeConcreta>.CountMany(criteria);
        }

        public IEnumerable<TInterfaceEntidadeProperties> GetMany(EntityDefinition entityDefinition, Criteria criteria)
        {
            return BusinessEntity<TEntidadeConcreta>.GetMany(entityDefinition, criteria);
        }

        public IEnumerable<TInterfaceEntidadeProperties> GetMany(Criteria criteria, GetMode getMode)
        {
            return BusinessEntity<TEntidadeConcreta>.GetMany(criteria, getMode);
        }
    }
}

