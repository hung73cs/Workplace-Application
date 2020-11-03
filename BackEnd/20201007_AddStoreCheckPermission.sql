use workplacedb;

DELIMITER $$
CREATE PROCEDURE CheckPermission(in useID bigint(20))
BEGIN
   SELECT detailpermission.actionCode FROM detailpermission
INNER join relationshipuserpermission
on detailpermission.permissionID = relationshipuserpermission.permissionID and relationshipuserpermission.userID = useID;
END; $$
DELIMITER ;

call CheckPermission(2);