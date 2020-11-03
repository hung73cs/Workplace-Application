using AutoMapper;
using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.IServices;
using System.Collections.Generic;

namespace WorkplaceManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IMapper _mapper;
        public DepartmentController(IDepartmentService departmentService, IMapper mapper)
        {
            _departmentService = departmentService;
            _mapper = mapper;
        }

        [HttpGet("GetAllDepartment")]
        public IActionResult GetAll()
        {
            var departments = _departmentService.GetAll();
            List<DepartmentVM> departmentDTOs = _mapper.Map<List<DepartmentVM>>(departments);
            return Ok(departmentDTOs);
        }

        [HttpGet("StringDepartment")]
        public IActionResult StringDepartment([FromBody] GetObjectId id)
        {
            var stringDepartment = _departmentService.GetDepartmentByWorkplaceString(id);
            return Ok(new { department = stringDepartment });
        }
    }
}
