CREATE TABLE University(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50),
    Description TEXT,
    ImagePath TEXT
);

DROP TABLE University;

CREATE TABLE City(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50),
    Created_at DATETIME,
    Updated_at DATETIME
);

DROP TABLE City;

CREATE TABLE Branch(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50),
    Address VARCHAR(50),
    PostCode VARCHAR(20),
    UniversityId INT,
    CityId INT,
    FOREIGN KEY (UniversityId) REFERENCES University(Id),
    FOREIGN KEY (CityId) REFERENCES City(Id)
);

DROP TABLE Branch;

CREATE TABLE Faculty(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50),
    Description TEXT,
    BranchId INT,
    FOREIGN KEY (BranchId) REFERENCES Branch(Id),
);

DROP TABLE Faculty;

CREATE TABLE Department(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50),
    FacultyId INT,
    FOREIGN KEY (FacultyId) REFERENCES Faculty(Id)
);

DROP TABLE Department;

CREATE TABLE AcadPosition(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50),
    Created_at DATETIME,
    Updated_at DATETIME
);

DROP TABLE AcadPosition;

CREATE TABLE ScienDegree(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50),
    Created_at DATETIME,
    Updated_at DATETIME
);

DROP TABLE ScienDegree;

CREATE TABLE Country(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50),
    Created_at DATETIME,
    Updated_at DATETIME
);

DROP TABLE Country;

CREATE TABLE PersonalData(
    Id INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    MiddleName VARCHAR(50),
    Email VARCHAR(50),
    Gender VARCHAR(30),
    PhoneNumber VARCHAR(15),
    ImagePath TEXT,
    Created_at DATETIME,
    Updated_at DATETIME,
    CityId INT,
    CountryId INT,
    FOREIGN KEY (CityId) REFERENCES City(Id),
    FOREIGN KEY (CountryId) REFERENCES  Country(Id)
);

DROP TABLE PersonalData;

CREATE TABLE Specialty(
    Id INT IDENTITY PRIMARY KEY,
    Name varchar(45),
    DepartmentId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Department(Id)
)

DROP TABLE Specialty;

CREATE TABLE EduForm(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50),
    IsActive TINYINT,
    Created_at DATETIME,
    Updated_at DATETIME,
);

DROP TABLE EduForm;

CREATE TABLE SpecialtyEduForm(
    Id INT IDENTITY PRIMARY KEY,
    EduFromId INT,
    SpecialtyId INT,
    FOREIGN KEY (EduFromId) REFERENCES EduForm(Id),
    FOREIGN KEY (SpecialtyId) REFERENCES Specialty(Id)
);

DROP TABLE SpecialtyEduForm;

CREATE TABLE Subjects(
    Id INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50),
    SpecialtyId INT,
    Created_at DATETIME,
    Updated_at DATETIME,
);

DROP TABLE Subjects;

CREATE TABLE Students(
    Id INT IDENTITY PRIMARY KEY,
    Course INT,
    IsActive TINYINT ,
    EduType VARCHAR(30),
    GroupNumber VARCHAR(30),
    Created_at DATETIME,
    Updated_at DATETIME,
    SubjectId  INT,
    SpecialtyEduFormId INT,
    PersonalDataId INT,
    FOREIGN KEY (SubjectId)  REFERENCES Subjects(Id),
    FOREIGN KEY (SpecialtyEduFormId) REFERENCES SpecialtyEduForm(Id),
    FOREIGN KEY (PersonalDataId) REFERENCES PersonalData(Id)
);

DROP TABLE Students;

CREATE TABLE Teachers(
    Id INT IDENTITY PRIMARY KEY,
    DepartmentId INT,
    PersonalDataId INT,
    AcadPositionId INT,
    ScientDegreeId INT,
    FOREIGN KEY (DepartmentId) REFERENCES Department(Id),
    FOREIGN KEY (PersonalDataId) REFERENCES PersonalData(Id),
    FOREIGN KEY (AcadPositionId) REFERENCES AcadPosition(Id),
    FOREIGN KEY (ScientDegreeId) REFERENCES ScienDegree(Id)
);

DROP TABLE Teachers;

CREATE TABLE Discipline(
    ID INT IDENTITY PRIMARY KEY,
    Name VARCHAR(50),
    LectureHours INT,
    PracticeHours INT,
    Created_at DATETIME,
    Updated_at DATETIME,
    DepartmentId INT,
    TeacherId INT,
    FOREIGN KEY(DepartmentId) REFERENCES Department(Id),
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
);

DROP TABLE Discipline;

CREATE TABLE Contract(
    Id INT IDENTITY PRIMARY KEY,
    Price DECIMAL,
    Created_at DATETIME,
    Updated_at DATETIME,
    FacultyId INT,
    StudentId INT,
    FOREIGN KEY (FacultyId) REFERENCES Faculty(Id),
    FOREIGN KEY (StudentId) REFERENCES Students(Id)
);

DROP TABLE Contract;