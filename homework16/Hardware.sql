-- გამოიტანეთ იმ პროდუქტების სახელწოდება და ღირებულება, რომელთა მწარმოებელი არის Hewlett-Packard;

SELECT Name, Price
FROM Products
WHERE ManufacturerId IN (
    SELECT ManufacturerId
    FROM Manufacturers as man
    WHERE Name = 'Hewlett-Packard'
);


-- გამოიტანეთ იმ პროდუქტების სახელწოდება და ღირებულება, რომლებიც არ უწარმოებია Fujitsu -ს;

SELECT Name, Price 
FROM dbo.Products
WHERE ManufacturerId IN (
	SELECT ManufacturerId FROM dbo.Manufacturers WHERE Name != 'Fujitsu'
);


-- გამოიტანეთ იმ პროდუქტების სახელწოდება და ღირებულება, რომელთა მწარმოებელი არის Sony, Fujitsu, IBM ან Intel;

SELECT Name, Price 
FROM dbo.Products
WHERE ManufacturerId IN (
	SELECT ManufacturerId FROM dbo.Manufacturers WHERE Name IN ('Sony', 'Fujitsu', 'IBM', 'Intel')
);


-- გამოიტანეთ იმ კომპანიების სახელწოდებები, რომლებმაც აწარმოეს 200 -ზე უფრო მაღალი ღირებულების მქონე პროდუქტები;

SELECT DISTINCT Name 
FROM dbo.Manufacturers
WHERE ManufacturerId IN (
	SELECT ManufacturerId FROM dbo.Products WHERE Price > 200
)


-- გამოიტანეთ იმ პროდუქტების სახელწოდება და ღირებულება, რომლებსაც არ აწარმოებს Genius და Dell

SELECT Name, Price 
FROM dbo.Products
WHERE ManufacturerId IN (
	SELECT ManufacturerId FROM dbo.Manufacturers WHERE Name NOT IN ('Genius', 'Dell')
);


-- გამოიტანეთ იმ მწარმოებელთა რაოდენობა, რომლებიც აწარმოებენ drive -ებს

SELECT COUNT(DISTINCT ManufacturerId) AS ManufacturerCount
FROM dbo.Manufacturers 
WHERE ManufacturerId IN (
	SELECT ManufacturerId FROM dbo.Products WHERE Name LIKE '%drive%'
)


-- გამოიტანეთ Intel -ის მიერ წარმოებული იმ პროდუქტების რაოდენობა, რომელთა ფასი აღემატება Intel -ის მიერ წარმოებული პროდუქტების საშუალო ფასს.

SELECT COUNT(*) AS ProductCount
FROM Products
WHERE ManufacturerId = (
    SELECT ManufacturerId
    FROM Manufacturers
    WHERE Name = 'Intel'
)
AND Price > (
    SELECT AVG(Price)
    FROM Products
    WHERE ManufacturerId = (
        SELECT ManufacturerId
        FROM Manufacturers
        WHERE Name = 'Intel'
    )
);