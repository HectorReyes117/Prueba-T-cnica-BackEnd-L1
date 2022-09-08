CREATE TABLE Professor(
ProfessorId int not null primary key identity,
FirstName varchar(100) not null,
LastName varchar(100) not null,
States varchar(60) not null,
Turn varchar(60) not null,
DateCrete varchar(60) not null,
DateDelete varchar(60),
Matter varchar(200) not null,
ClassroomId int foreign key references Classroom(ClassroomId) 
)

CREATE TABLE Student(
StudentId int not null primary key identity,
FirstName varchar(100) not null,
LastName varchar(100) not null,
ClassroomId int foreign key references Classroom(ClassroomId)
)

CREATE TABLE Classroom(
ClassroomId int not null primary key identity,
Course varchar(100) not null
)


Create table ScheduleWeek(
IdSchedule int primary key identity,
Dayss int not null,
Weeks varchar(200) not null,
Months varchar(200) not null,
Years int not null,
ProfessorId int foreign key references Professor(ProfessorId) not null
)