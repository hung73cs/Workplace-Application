use workplacedb;

alter table detailPermission
CHANGE acctionCode actionCode nvarchar(100);

INSERT INTO `workplacedb`.`permission` (`name`, `description`) VALUES ('admin', 'Nhóm quyền cao nhất, quản lý mọi thứ trong hệ thống');
INSERT INTO `workplacedb`.`permission` (`name`, `description`) VALUES ('user', 'Nhóm quyền người dùng bình thường bị hạn chế truy cập một vài tính năng.');

INSERT INTO `workplacedb`.`detailpermission` (`permissionID`, `actionName`, `actionCode`, `checkAction`) VALUES ('1', 'Tạo mới user', 'createuser', '1');
INSERT INTO `workplacedb`.`detailpermission` (`permissionID`, `actionName`, `actionCode`, `checkAction`) VALUES ('1', 'Đổi mật khẩu', 'changepassword', '1');
INSERT INTO `workplacedb`.`detailpermission` (`permissionID`, `actionName`, `actionCode`, `checkAction`) VALUES ('1', 'Sửa thông tin user', 'updateuser', '1');
INSERT INTO `workplacedb`.`detailpermission` (`permissionID`, `actionName`, `actionCode`, `checkAction`) VALUES ('1', 'Đăng nhập', 'login', '1');
INSERT INTO `workplacedb`.`detailpermission` (`permissionID`, `actionName`, `actionCode`, `checkAction`) VALUES ('1', 'Xóa user', 'deleteuser', '1');
INSERT INTO `workplacedb`.`detailpermission` (`permissionID`, `actionName`, `actionCode`, `checkAction`) VALUES ('1', 'Xem danh sách user', 'getalluser', '1');
INSERT INTO `workplacedb`.`detailpermission` (`permissionID`, `actionName`, `actionCode`, `checkAction`) VALUES ('1', 'Xem user theo id', 'getuserbyid', '1');

INSERT INTO `workplacedb`.`detailpermission` (`permissionID`, `actionName`, `actionCode`, `checkAction`) VALUES ('2', 'Đăng nhập', 'login', '1');
INSERT INTO `workplacedb`.`detailpermission` (`permissionID`, `actionName`, `actionCode`, `checkAction`) VALUES ('2', 'Sửa thông tin cá nhân', 'updatemyselfinfo', '1');
