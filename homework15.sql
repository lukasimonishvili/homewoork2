-- Students

-- task #1
SELECT * FROM dbo.Students WHERE DoB > '1990-12-21';

-- task #2
DECLARE @currentYear INT;
SET @currentYear = YEAR(GETDATE());
SELECT Firstname, Lastname, (@currentYear - YEAR(DoB)) as Age  FROM dbo.Students WHERE Country = 'Georgia' or Country = 'Libya';

-- task #3
INSERT INTO dbo.Students (Lastname, Firstname, Dob, Email, Quiz1, Quiz2, MiddleTest, FinalTest, Country)
VALUES ('Simonishvili', 'Luka', '1998-05-11', 'simonishvililuka@gmail.com', 10, 10, 35, 40, 'Georgia');

SELECT * FROM dbo.Students WHERE Email = 'simonishvililuka@gmail.com';


-- task #4
SELECT TOP 5 * from dbo.Students ORDER BY MiddleTest desc;


-- task #5 
DELETE FROM dbo.Students WHERE FinalTest = 19;
SELECT * FROM dbo.Students;

-- task #6
UPDATE dbo.Students SET FinalTest = 0 WHERE MiddleTest = 1;


-- Persons

-- task #1
SELECT * FROM dbo.Persons WHERE PrivateId LIKE '163%';

-- task #2
SELECT * FROM dbo.Persons WHERE Lastname = City;

-- task #3
SELECT * FROM dbo.Persons WHERE Country IN ('Canada', 'Monaco');

-- task #4 
SELECT FirstName, LastName, PrivateId FROM dbo.Persons WHERE Email IS NULL;

-- task #5
SELECT * FROM dbo.Persons WHERE (Country NOT IN ('Spain', 'Turkey')) AND (Salary BETWEEN 1000 AND 3000);

-- taks #6
SELECT * FROM dbo.Persons WHERE WorkPlace LIKE '%LLC%' OR WorkPlace LIKE '%LLP%' OR WorkPlace LIKE '%PC%';

-- task #7
SELECT Email,
       CASE
           WHEN LEN(Email) - LEN(REPLACE(Email, '.', '')) > 2 THEN 'more than 2 dots'
           ELSE 'less than 2 dots'
       END AS MAILINFO
FROM dbo.Persons;

-- task #8
SELECT * FROM dbo.Persons WHERE PINcode LIKE '%51';

-- tasl #9
SELECT Country, AVG(Salary) AS AverageSalary
FROM dbo.Persons
GROUP BY Country;