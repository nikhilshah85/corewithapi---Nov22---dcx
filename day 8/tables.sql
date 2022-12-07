create database EmployeeDB


create table DeptInfo
(
	dId int primary key,
	dName varchar(20),
	dLocation varchar(20)
	)
insert into DeptInfo values(10,'IT','New York')
insert into DeptInfo values(20,'Accounts','San Fransico')
insert into DeptInfo values(30,'HR','Mumbai')
insert into DeptInfo values(40,'Sales','Paris')

insert into DeptInfo values(50,'IT A','New York')
insert into DeptInfo values(60,'B Accounts','Mumbai')
insert into DeptInfo values(70,'C HR','Mumbai')
insert into DeptInfo values(80,'D Sales','New York')
------------------------------------------------------------------------------------
create table EmployeeInfo
(
	empNo int primary key,
	empName varchar(20),
	empDesignation varchar(20),
	empSalary int,
	empDept int,
	empIsPermenant bit,

	constraint fk_empDept foreign key(empDept) references DeptInfo
)

insert into EmployeeInfo values(1,'Kriti','Sales Manager',18000,40,1)
insert into EmployeeInfo values(2,'A Kriti A','Manager',18000,10,1)
insert into EmployeeInfo values(3,'B Kriti B',' Manager',18000,20,1)
insert into EmployeeInfo values(4,'C Kriti','Sales Manager',18000,40,1)
insert into EmployeeInfo values(5,'D Kriti','Sales Manager',18000,30,1)
insert into EmployeeInfo values(6,'E Kriti','Sales Manager',18000,40,1)
insert into EmployeeInfo values(7,'F Kriti','Sales Manager',18000,10,1)
insert into EmployeeInfo values(8,'G Kriti','Sales Manager',18000,40,1)
insert into EmployeeInfo values(9,'HKriti','Sales Manager',18000,20,1)
insert into EmployeeInfo values(10,'I Kriti','Sales Manager',18000,40,1)
insert into EmployeeInfo values(11,'J Kriti','Sales Manager',18000,30,1)


select * from EmployeeInfo
select * from deptinfo







