using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TEK_Careers.Framework.GenericRepository
{
    public abstract class EntityService<T> : IEntityService<T>
         where T : BaseEntity
    {
        #region Private Members

        private IUnitOfWork _unitOfWork;
        private IGenericRepository<T> _repository;

        #endregion

        #region Constructors

        protected EntityService(IUnitOfWork unitOfWork, IGenericRepository<T> repository)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        #endregion

        #region Public Methods

        public virtual void Create(T entity)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }
            //SetBaseEntityProperties(entity);
            _repository.Add(entity);
            _unitOfWork.Commit();
        }

        public virtual void Create(List<T> entityList)
        {
            entityList.ForEach(entity =>
            {
                if (entity == null) { throw new ArgumentNullException("entity"); }
                //SetBaseEntityProperties(entity);
                _repository.Add(entity);
            });
            _unitOfWork.Commit();
        }

        public virtual void Update(T entity)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }
            // SetBaseEntityProperties(entity);
            _repository.Edit(entity);
            _unitOfWork.Commit();
        }

        public virtual void Update(List<T> entityList)
        {
            entityList.ForEach(entity =>
            {
                if (entity == null) { throw new ArgumentNullException("entity"); }
                // SetBaseEntityProperties(entity);
                _repository.Edit(entity);
            });
            _unitOfWork.Commit();
        }

        public virtual void Delete(T entity)
        {
            if (entity == null) { throw new ArgumentNullException("entity"); }
            // SetBaseEntityProperties(entity);
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }

        public virtual IQueryable<T> GetAll()
        {
            return _repository.GetAll();
        }

        #endregion

        public virtual void SetBaseEntityProperties(T entity)
        {

        }

    }
}
