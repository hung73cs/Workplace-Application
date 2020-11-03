using Entities;
using Entities.DTOs;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Services.IServices;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;

namespace Services.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly DataContext _context;
        public PermissionService(DataContext context)
        {
            _context = context;
        }
        public List<string> ListAllowPermission(long id)
        {
            var listAllowPermission = _context.Detailpermissions.FromSqlRaw("call CheckPermission(", id, ");").ToList();
            var mylist = listAllowPermission.ConvertAll(x => Convert.ToString(x));
            return mylist;
        }

        public bool CheckPermission(long id, string permission)
        {
            List<string> listAllowPermission = ListAllowPermission(id);
            foreach (var item in listAllowPermission)
            {
                if (permission == item)
                { return true; }
                return false;
            }
            return false;
        }

        public bool DeleteRelationshipuserpermission(GetObjectId deleteObjectViewModel)
        {
            var item = _context.Relationshipuserpermissions.Find(deleteObjectViewModel.Id);
            if (item != null)
            {
                _context.Relationshipuserpermissions.Remove(item);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Detailpermission AddDetailPermission(Detailpermission detailpermission)
        {
            if (string.IsNullOrWhiteSpace(detailpermission.ActionCode))
            {
                throw new Exception("ActionCode la bat buoc");
            }
            if (_context.Detailpermissions.Any(x => x.ActionCode == detailpermission.ActionCode))
            {
                throw new Exception("ActionCode da ton tai!");
            }
            _context.Detailpermissions.Add(detailpermission);
            _context.SaveChanges();
            return detailpermission;
        }
        public Detailpermission UpdateDetailPermission(Detailpermission detailpermissionToUpdate)
        {
            Detailpermission detailpermission = _context.Detailpermissions.FirstOrDefault(x => x.Id == detailpermissionToUpdate.Id);
            if (detailpermission == null)
            {
                throw new Exception("Detail Permission can chinh sua khong ton tai");
            }
            if (_context.Detailpermissions.Any(x => x.ActionCode == detailpermissionToUpdate.ActionCode))
            {
                throw new Exception("Action Code da ton tai!");
            }
            detailpermission.ActionName = detailpermissionToUpdate.ActionName;
            detailpermission.ActionCode = detailpermissionToUpdate.ActionCode;
            detailpermission.PermissionId = detailpermissionToUpdate.PermissionId;
            detailpermission.CheckAction = detailpermissionToUpdate.CheckAction;
            _context.Update(detailpermission);
            _context.SaveChanges();
            return detailpermission;
        }

        public bool DeleteDetailPermission(GetObjectId deleteObjectViewModel)
        {
            Detailpermission detailpermission = _context.Detailpermissions.Find(deleteObjectViewModel.Id);
            if (detailpermission != null)
            {
               
                _context.Detailpermissions.Remove(detailpermission);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Permission AddPermission(Permission permission)
        {
            if (string.IsNullOrWhiteSpace(permission.Name))
            {
                throw new Exception("Permission Name la bat buoc");
            }
            if (_context.Permissions.Any(x => x.Name == permission.Name))
            {
                throw new Exception("Permission Name da ton tai!");
            }
            _context.Permissions.Add(permission);
            _context.SaveChanges();
            return permission;
        }

        public Permission UpdatePermission(Permission permissionToUpdate)
        {
            Permission permission = _context.Permissions.FirstOrDefault(x => x.Id == permissionToUpdate.Id);
            if (permission == null)
            {
                throw new Exception("Permission can chinh sua khong ton tai");
            }
            if (_context.Permissions.Any(x => x.Name == permissionToUpdate.Name))
            {
                throw new Exception("Permission Name da ton tai!");
            }
            permission.Name = permissionToUpdate.Name;
            permission.Description = permissionToUpdate.Description;         
            _context.Update(permission);
            _context.SaveChanges();
            return permission;
        }

        public bool DeletePermission(GetObjectId deleteObjectViewModel)
        {
            Permission permission = _context.Permissions.Find(deleteObjectViewModel.Id);
            if (permission != null)
            {
                var detailPermission = _context.Detailpermissions.FirstOrDefault(x => x.PermissionId == permission.Id);
                if (detailPermission != null)
                {
                    _context.Detailpermissions.Remove(detailPermission);
                }
                _context.Permissions.Remove(permission);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public Relationshipuserpermission AddRelationshipuserpermission(Relationshipuserpermission relationshipuserpermission)
        {
            if (relationshipuserpermission.UserId == null)
            {
                throw new Exception("User ID la bat buoc");
            }
            if (relationshipuserpermission.PermissionId==null)
            {
                throw new Exception("Permission ID la bat buoc");
            }
            
            _context.Relationshipuserpermissions.Add(relationshipuserpermission);
            _context.SaveChanges();
            return relationshipuserpermission;
        }

        public Relationshipuserpermission UpdateRelationshipuserpermission(Relationshipuserpermission relationshipuserpermissionToUpdate)
        {
            var relationshipuserpermission = _context.Relationshipuserpermissions.FirstOrDefault(x => x.Id == relationshipuserpermissionToUpdate.Id);
            if (relationshipuserpermission == null)
            {
                throw new Exception("Khong ton tai");
            }
            if (_context.Relationshipuserpermissions.Any(x => x.PermissionId == relationshipuserpermissionToUpdate.Id))
            {
                throw new Exception("Permission da co san!");
            }
            relationshipuserpermission.UserId = relationshipuserpermissionToUpdate.UserId;
            relationshipuserpermission.PermissionId = relationshipuserpermissionToUpdate.PermissionId;
            relationshipuserpermission.Suspended = relationshipuserpermissionToUpdate.Suspended;
            _context.Update(relationshipuserpermission);
            _context.SaveChanges();
            return relationshipuserpermission;
        }
    }
}