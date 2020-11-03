using Entities;
using Entities.DTOs;
using Entities.DTOs.ModelsNonEntities;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Services.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;
        public DepartmentService(DataContext context)
        {
            _context = context;
        }
        public List<Department> GetAll()
        {
            var products = _context.Departments.FromSqlRaw("call getalldepartments();").ToList();

            return products;
        }

        public string GetDepartmentByType()
        {
            throw new NotImplementedException();
        }

        public List<LevelDetailOfDepartment> GetDepartmentByWorkplace(GetObjectId id)
        {
            var departments = _context.Departments.FromSqlRaw("call getalldepartments(",id,");").ToList();
            List<LevelDetailOfDepartment> listLevelDetail = new List<LevelDetailOfDepartment>();
            foreach (var item in departments)
            {
                LevelDetailOfDepartment level = new LevelDetailOfDepartment();
                level.Id = item.Id;
                level.Department = item.Name;
                listLevelDetail.Add(level);
            }
            listLevelDetail.ToList();
            return listLevelDetail;
        }

        public string GetDepartmentByWorkplaceString(GetObjectId GetObjectId)
        {
            string store = "call workplacedb.GetLevelDetailOfDepartment(" + GetObjectId.Id + ");";
            var departments = _context.Departments.FromSqlRaw(store).ToList();

            string listString = string.Empty;
            foreach (var item in departments.AsEnumerable().Reverse())
            {
                listString += (item.Name + ".");
            }        
            return listString.TrimEnd(listString[listString.Length - 1]);
        }


    }
}
