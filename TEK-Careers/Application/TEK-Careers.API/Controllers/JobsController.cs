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
    public class JobsController : BaseApiController
    {
        private readonly IJobService _jobsService;

        public JobsController(IJobService jobsService)
        {
            _jobsService = jobsService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<JobResponse> jobResponses = new List<JobResponse>();
                var jobs = _jobsService.GetAllActiveRecords();

                if (jobs.Any())
                {
                    jobResponses.AddRange(jobs.Select(job => new JobResponse()
                    {
                        Id = job.ID,
                        Title = job.Title,
                        Description = job.Description,
                        PostedDate = job.PostedDate,
                        ClosingDate = job.ClosingDate,
                        DepartmentName = job.Department.Title,
                        LocationName = job.Location.Title
                    }));

                    return Ok(jobResponses);
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

        [HttpGet]
        public IHttpActionResult Get(long id)
        {
            try
            {
                JobDetailsResponse jobResponse = new JobDetailsResponse();
                var job = _jobsService.GetByID(id);

                if (job != null)
                {
                    jobResponse = new JobDetailsResponse()
                    {
                        Id = job.ID,
                        Title = job.Title,
                        Description = job.Description,
                        PostedDate = job.PostedDate,
                        ClosingDate = job.ClosingDate,
                        Code = job.Code,
                        Department = new DepartmentDetails()
                        {
                            Id = job.Department.ID,
                            Title = job.Department.Title
                        },
                        Location = new LocationDetails()
                        {
                            Id = job.Location.ID,
                            Title = job.Location.Title,
                            City = job.Location.City,
                            Country = job.Location.Country,
                            State = job.Location.State,
                            Zip = job.Location.Zip
                        }
                    };

                    return Ok(jobResponse);
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

        [HttpGet]
        public IHttpActionResult List(string q, int pageNo, int pageSize, long? locationId, long? departmentId)
        {
            try
            {
                List<JobResponse> jobResponses = new List<JobResponse>();
                var jobs = _jobsService.GetAllActiveRecords();

                if (!string.IsNullOrEmpty(q))
                {
                    jobs = jobs.Where(x => x.Title.ToLower() == q.Trim().ToLower());
                }

                if (locationId.HasValue)
                {
                    jobs = jobs.Where(x => x.LocationID == locationId);
                }

                if (departmentId.HasValue)
                {
                    jobs = jobs.Where(x => x.DepartmentID == departmentId);
                }

                jobs = jobs.OrderBy(x=>x.Title).Skip((pageNo - 1) * pageSize).Take(pageSize);

                if (jobs.Any())
                {
                    jobResponses.AddRange(jobs.Select(job => new JobResponse()
                    {
                        Id = job.ID,
                        Title = job.Title,
                        Description = job.Description,
                        PostedDate = job.PostedDate,
                        ClosingDate = job.ClosingDate,
                        DepartmentName = job.Department.Title,
                        LocationName = job.Location.Title
                    }));

                    return Ok(jobResponses);
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
        public IHttpActionResult Post([FromBody] JobRequest jobRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                var job = new Job()
                {
                    Title = jobRequest.Title,
                    Description = jobRequest.Description,
                    PostedDate = jobRequest.PostedDate,
                    ClosingDate = jobRequest.ClosingDate,
                    DepartmentID = jobRequest.DepartmentId,
                    LocationID = jobRequest.LocationId,
                    Code = $"JOB-"
                };

                _jobsService.Create(job);


                // Updated Code with ID value autogenerated
                // Alternative is to maintain current code and autoincrement
                job.Code = $"JOB-{job.ID}";
                _jobsService.Update(job);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] JobRequest jobRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            try
            {
                var job = _jobsService.GetByID(id);

                if (job != null)
                {
                    job.Title = jobRequest.Title;
                    job.Description = jobRequest.Description;
                    job.PostedDate = jobRequest.PostedDate;
                    job.ClosingDate = jobRequest.ClosingDate;
                    job.DepartmentID = jobRequest.DepartmentId;
                    job.LocationID = jobRequest.LocationId;
                    _jobsService.Update(job);

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
