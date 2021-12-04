using System;
using System.Linq;
using TEK_Careers.Application.ServicePattern.Core;
using TEK_Careers.Domain.Model.Core;
using TEK_Careers.Domain.RepositoryPattern.Core;
using TEK_Careers.Framework.GenericRepository;

namespace TEK_Careers.Application.Services.Core
{
    public abstract class SyncEntityService<T> : EntityService<T>, ISyncEntityService<T>
        where T : SyncEntity
    {
        #region Private Members

        private ISyncRepository<T> _syncRepository;

        #endregion

        #region Constructor

        public SyncEntityService(IUnitOfWork unitOfWork, ISyncRepository<T> repository)
            : base(unitOfWork, repository)
        {
            _syncRepository = repository;
        }

        #endregion

        #region Public Methods

        public IQueryable<T> GetAllActiveRecords()
        {
            return _syncRepository.GetAllActiveRecords();
        }

        public T GetByID(long id)
        {
            return _syncRepository.GetByID(id);
        }
        public void InActivateRecord(T entity)
        {
            entity.IsActive = false;
            _syncRepository.Save();
        }


        #endregion

        #region Overrides

        public override void SetBaseEntityProperties(T entity)
        {
            base.SetBaseEntityProperties(entity);
            entity.UpdatedDate = DateTime.UtcNow;
        }

        #endregion

        #region Protected Methods

        protected decimal UltimateRoundingFunction(decimal amountToRound, decimal nearstOf, decimal fairness)
        {
            return nearstOf != 0 ? Math.Floor(amountToRound / nearstOf + fairness) * nearstOf : 0;
        }

        #endregion
    }
}
