using System.Linq;
using TEK_Careers.Application.ServicePattern;
using TEK_Careers.Application.Services.Core;
using TEK_Careers.Application.Services.Filters;
using TEK_Careers.Domain.Model;
using TEK_Careers.Domain.RepositoryPattern;
using TEK_Careers.Framework.GenericRepository;

namespace ALK_PromoDepot.Application.Services
{
    public class LocationService : SyncEntityService<Location>, ILocationService
    {
        #region Private Members

        private IUnitOfWork _unitOfWork;
        private ILocationRepository _locationRepository;

        #endregion

        #region Constructors

        public LocationService(IUnitOfWork unitOfWork, ILocationRepository locationRepository)
            : base(unitOfWork, locationRepository)
        {
            _unitOfWork = unitOfWork;
            _locationRepository = locationRepository;
        }

        #endregion

    }
}
