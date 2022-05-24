Create database Project
go
use Project
go
--------StoreProcedure----------------
Create Table Logintable(
UserName varchar(30),
FirstName varchar(20),
LastName varchar(20),
Password varchar(15)

)
drop table Logintable
select * from Logintable
insert into  Logintable (UserName,FirstName,LastName,Password)values('Ramki0268','ram','kishore','9502762567') 
select * from Logintable

create proc inlog
@user varchar(30),
@Pass varchar(15)
as
select*from Logintable  where UserName like @user and Password=@Pass
drop proc inlog
---------------------------------------------------
create table Doctor(
DoctorId int identity(1,1),
FirstName varchar(20),
LastName varchar(20),
Sex varchar(7) constraint chk_sex check(Sex in ('Male','Female','Others')) ,
Specialization varchar(25),
VisitingHours varchar(25) 
)
select * from Doctor
drop table Doctor
create proc AddDoctor
@fname varchar(20),
@lname varchar(20),
@sex varchar(8),
@spec varchar(20),
@vis varchar(10)
as
insert into Doctor(FirstName,LastName,Sex,Specialization,Visitinghours)
 values(@fname,@lname,@sex,@spec,@vis)
 exec  AddDoctor
 drop proc AddDoctor

Create proc getdoc1
as
select [DoctorId],[FirstName],[LastName],[Sex],[Specialization]
from Doctor
 drop proc getdoc1
 drop table Doctor
 -------------------------------------------------------------

create table Patient(
PatientId int identity(1,1),
FirstName varchar(20),
LastName varchar(20),
Sex varchar(7) constraint chk_Gen check(Sex in ('Male','Female','Others')) ,
Age int,
Date_of_birth date
)
select DATEDIFF(YEAR,Date_of_birth,getdate()) from Patient
select*from Patient
drop table Patient


create proc addpatient
@fname varchar(10),
@lname varchar(10),
@sex varchar(8),
@dob date
as
begin
declare @age int
set @age=(select DATEDIFF(YEAR,@dob,getdate()))
insert into Patient(FirstName,LastName,Sex,Age,Date_of_birth)
values(@fname,@lname,@sex,@age,@dob)
end
exec addpatient 'ram','kishore','Male','2002-06-12'
drop proc addpatient

Create proc [dbo].[getpat]
as
select [PatientId],[FirstName],[LastName],[Sex],[Age],CONVERT(varchar(15),format(Date_of_Birth,'d','en-IN'))as [Date_of_birth]
from [dbo].[Patient]
--------------------------------------------------
Create table Appointment(

PatientId int  identity(1,1),
Specialization varchar(25),
DoctorName varchar(25),
VisitDate varchar(25),
AppointmentTime varchar(20)
)
select * from[dbo].[Appointment]

Create proc Schpro
@spec varchar(30),
@doctorname varchar(10),
@visitdate varchar(20),
@appointtime varchar(20)
as
insert into Appointment(Specialization,DoctorName,VisitDate,AppointmentTime)
values(@spec,@doctorname,@visitdate,@appointtime)
drop proc Schpro
drop table Appointment
select *from Appointment

create proc Showappointments
as 
select AppointmentId,PatientId,Specialization,DoctorName,VisitDate,AppointmentTime 
from Appointment
Showappointments
-------------------------------------
create proc Delapp
@id int 
as
delete from Appointment where PatientId=@id
----------------------------------------
create proc GetAppmnt
as select
PatientId  ,
Specialization ,
DoctorName ,
VisitDate ,
AppointmentTime from Appointment