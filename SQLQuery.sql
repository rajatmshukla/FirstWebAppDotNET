IF EXISTS (SELECT * FROM sysobjects WHERE type = 'U' AND name = 'departments')
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