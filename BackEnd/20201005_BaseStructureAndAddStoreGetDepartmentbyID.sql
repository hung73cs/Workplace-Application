create database workplacedb;

use workplacedb;

create table user
(
	ID bigint(20) primary key auto_increment,
    userName nvarchar(100) not null,
    passWord nvarchar(10000) not null,
    displayName nvarchar(100) not null,
    phoneNumber varchar(20),
    birthday date,
    departmentID bigint(20) not null
);


create table department
(
	ID bigint(20) primary key auto_increment,
    name nvarchar(100) not null,
    type nvarchar(100) not null,
    parentID bigint(20)
);


create table permission
(
	ID bigint(20) primary key auto_increment,
    name nvarchar(200) not null,
    description nvarchar(5000)
);


create table relationshipUserPermission
(
	ID bigint(20) primary key auto_increment,
    userID bigint(20) not null,
    permissionID bigint(20) not null,
    suspended bit
);

alter table user
add foreign key (departmentID) references department(ID);

alter table department
add foreign key (parentID) references department(ID);

alter table relationshipUserPermission
add foreign key (userID) references user(ID);

alter table relationshipUserPermission
add foreign key (permissionID) references permission(ID);


create table workspace
(
	ID bigint(20) primary key auto_increment,
    name nvarchar(100),
    locationID bigint(20) not null,
    status boolean not null default 0
);


create table location
(
	ID bigint(20) primary key auto_increment,
    name nvarchar(100),
    type nvarchar(100) not null,
    parentID bigint(20)
);

create table reservation
(
	ID bigint(20) primary key auto_increment,
    userID bigint(20) not null,
    workspaceID bigint(20) not null,
    beginTime datetime,
    endTime datetime
);

alter table workspace
add foreign key(locationID) references location(ID);

alter table location 
add foreign key(parentID) references location(ID);

alter table reservation
add foreign key(userID) references user(ID);

alter table reservation
add foreign key(workspaceID) references workspace(ID);


create table detailPermission
(
	ID bigint(20) primary key auto_increment,
	permissionID bigint(20),
    actionName nvarchar(100),
	acctionCode nvarchar(100) not null,
    checkAction boolean not null default 0
);

alter table detailPermission
add foreign key (permissionID) references permission(ID);



DELIMITER $$
CREATE PROCEDURE GetAllDepartments()
BEGIN
with recursive cte (ID, name,type, parentID) as (
  select     ID,
             name,
             type,
             parentID
  from       department
  where      parentID = 1
  union all
  select     p.ID,
             p.name,
             p.type,
             p.parentID
  from       department p
  inner join cte
          on p.parentID = cte.ID
)
select * from cte;
END; $$
DELIMITER ;

call getalldepartments();

show procedure status;