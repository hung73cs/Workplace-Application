ALTER TABLE `workplacedb`.`user` 
DROP FOREIGN KEY `user_ibfk_1`;
ALTER TABLE `workplacedb`.`user` 
CHANGE COLUMN `departmentID` `departmentID` BIGINT(20) NULL ;
ALTER TABLE `workplacedb`.`user` 
ADD CONSTRAINT `user_ibfk_1`
  FOREIGN KEY (`departmentID`)
  REFERENCES `workplacedb`.`department` (`id`);