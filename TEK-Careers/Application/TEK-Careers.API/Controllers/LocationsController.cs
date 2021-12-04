using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TEK_Careers.API.Models.RequestModels;
using TEK_Careers.API.Models.ResponseModels;
using TEK_Careers.Application.ServicePattern;
using TEK_Careers.Domain.Model;

namespace TEK_Careers.API.Controllers
{
    public class LocationsController : BaseApiController
    {
        private readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<LocationResponse> locationResponses = new List<LocationResponse>();
                var locations = _locationService.GetAllActiveRecords();

                if (locations.Any())
                {
                    locationResponses.AddRange(locations.Select(location => new LocationResponse()
                    {
                        Id = location.ID,
                        Title = location.Title,
                        City = location.City,
                        Country = location.Country,
                        State = location.State,
                        Zip = location.Zip
                    }));

                    return Ok(locationResponses);
                }
                else
                {
                    return NotFound();
                }

            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] LocationRequest locationRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                var location = new Location()
                {
                    Title = locationRequest.Title,
                    City = locationRequest.City,
                    Country = locationRequest.Country,
                    State = locationRequest.State,
                    Zip = locationRequest.Zip
                };

                _locationService.Create(location);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] LocationRequest locationRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            try
            {
                var location = _locationService.GetByID(id);

                if (location != null)
                {
                    location.Title = locationRequest.Title;
                    location.City = locationRequest.City;
                    location.Country = locationRequest.Country;
                    location.State = locationRequest.State;
                    location.Zip = locationRequest.Zip;
                    _locationService.Update(location);

                    return Ok();
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
