using System.Linq;
using TEK_Careers.Application.ServicePattern;
using TEK_Careers.Application.Services.Core;
using TEK_Careers.Application.Services.Filters;
using TEK_Careers.Domain.Model;
using TEK_Careers.Domain.RepositoryPattern;
using TEK_Careers.Framework.GenericRepository;

namespace ALK_PromoDepot.Application.Services
{
    public class JobService : SyncEntityService<Job>, IJobService
    {
        #region Private Members

        private IUnitOfWork _unitOfWork;
        private IJobRepository _JobRepository;

        #endregion

        #region Constructors

        public JobService(IUnitOfWork unitOfWork, IJobRepository JobRepository)
            : base(unitOfWork, JobRepository)
        {
            _unitOfWork = unitOfWork;
            _JobRepository = JobRepository;
        }

        #endregion
    }
}
