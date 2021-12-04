using System.Linq;
using TEK_Careers.Application.ServicePattern;
using TEK_Careers.Application.Services.Core;
using TEK_Careers.Application.Services.Filters;
using TEK_Careers.Domain.Model;
using TEK_Careers.Domain.RepositoryPattern;
using TEK_Careers.Framework.GenericRepository;

namespace ALK_PromoDepot.Application.Services
{
    public class DepartmentService : SyncEntityService<Department>, IDepartmentService
    {
        #region Private Members

        private IUnitOfWork _unitOfWork;
        private IDepartmentRepository _departmentRepository;

        #endregion

        #region Constructors

        public DepartmentService(IUnitOfWork unitOfWork, IDepartmentRepository departmentRepository)
            : base(unitOfWork, departmentRepository)
        {
            _unitOfWork = unitOfWork;
            _departmentRepository = departmentRepository;
        }

        #endregion

        #region Public Methods

        public Department GetByName(string name)
        {
            return _departmentRepository.GetAllActiveRecords().WithTitle(name).FirstOrDefault();
        }

        #endregion
    }
}
