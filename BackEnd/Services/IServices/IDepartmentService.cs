using Entities.DTOs;
using Entities.DTOs.ModelsNonEntities;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IDepartmentService
    {
        List<Department> GetAll();
        List<LevelDetailOfDepartment> GetDepartmentByWorkplace(GetObjectId id);
        string GetDepartmentByWorkplaceString(GetObjectId id);
        string GetDepartmentByType();
    }
}
