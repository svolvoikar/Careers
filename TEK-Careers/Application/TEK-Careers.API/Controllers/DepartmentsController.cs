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
    public class DepartmentsController : BaseApiController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                List<DepartmentResponse> departmentResponses = new List<DepartmentResponse>();
                var departments = _departmentService.GetAllActiveRecords();

                if (departments.Any())
                {
                    departmentResponses.AddRange(departments.Select(department => new DepartmentResponse()
                    {
                        Id = department.ID,
                        Title = department.Title
                    }));

                    return Ok(departmentResponses);
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
        public IHttpActionResult Post([FromBody] DepartmentRequest deparmentRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            try
            {
                var department = new Department()
                {
                    Title = deparmentRequest.Title
                };

                _departmentService.Create(department);

                return Ok();
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] DepartmentRequest deparmentRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            try
            {
                var department = _departmentService.GetByID(id);

                if (department != null)
                {
                    department.Title = deparmentRequest.Title;
                    _departmentService.Update(department);

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
