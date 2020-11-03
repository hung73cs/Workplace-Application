using Entities.DTOs;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.IServices
{
    public interface IPermissionService
    {
        //Detail Permission
        Detailpermission AddDetailPermission(Detailpermission detailpermission);
        Detailpermission UpdateDetailPermission(Detailpermission detailpermission);
        bool DeleteDetailPermission(GetObjectId deleteObjectViewModel);

        //Permisstion
        Permission AddPermission(Permission permission);
        Permission UpdatePermission(Permission permission);
        bool DeletePermission(GetObjectId deleteObjectViewModel);

        //Relationship between User and Permission
        Relationshipuserpermission AddRelationshipuserpermission(Relationshipuserpermission relationshipuserpermission);
        Relationshipuserpermission UpdateRelationshipuserpermission(Relationshipuserpermission relationshipuserpermission);
        bool DeleteRelationshipuserpermission(GetObjectId deleteObjectViewModel);

        //Other
        List<string> ListAllowPermission(long id);
        bool CheckPermission(long id, string permission);
    }
}
