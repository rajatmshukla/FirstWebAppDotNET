IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'departments')        DROP  Table dbo.departmentsGOCREATE TABLE dept( deptno int NOT NULL,  dname varchar(50) NOT NULL,  loc varchar(50) NOT NULL,  CONSTRAINT departments_pk PRIMARY KEY (deptno));IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'Emp')        DROP  Table dbo.EmpGOCREATE TABLE Emp( EmpID int NOT NULL,  EmpName char(50) NOT NULL,  deptno int,  salary money,  CONSTRAINT employees_pk PRIMARY KEY (EmpID),  CONSTRAINT fk_departments    FOREIGN KEY (deptno)    REFERENCES dept(deptno));select * from Empselect * from deptinsert into dept values (1,'IT','Kolkata')insert into Emp values (1,'Rajat',1,1234)insert into Emp values (3,'Jaasir',1,3000)insert into Emp values (2,'Rahul',1,4000)update Emp set salary=1234 WHERE EmpID = 1;Use CompanyDB/////////////////////////////////////////////////////////////////Create Function  dbo.DeptFind (
            @deptno int
)
RETURNS int
AS
BEGIN
    RETURN (select count(*) from dept where deptno = @deptno)
    END

Create Function  dbo.EmpFind (
            @empid int
)
RETURNS int
AS
BEGIN
    RETURN (select count(*) from Emp where EmpID = @empid)
    END

////////////////////////////////////////////////////////

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmpUpdate]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[EmpUpdate]
GO
CREATE PROCEDURE EmpUpdate
@EmpId int,
@EmpName varchar(50)
AS
update Emp set EmpName=@EmpName where EmpID=@EmpId
Go

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InsertAllEmp]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[InsertAllEmp]
GO
 
CREATE PROCEDURE InsertAllEmp
@EmpId int,
@EmpName varchar(50),
@deptno int,
@salary money
AS
insert into Emp
values(@EmpId,@EmpName,@deptno,@salary)

IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UpdateEmp]') AND type in (N'P', N'PC'))
    DROP PROCEDURE [dbo].[UpdateEmp]
GO
CREATE PROCEDURE UpdateEmp
@EmpId int,
@EmpName varchar(50)
AS
update Emp set EmpName=@EmpName where EmpID=@EmpId
Go