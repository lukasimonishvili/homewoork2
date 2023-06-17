-- გამოიტანეთ ევროპაში გამართულ მოვლენების რაოდენობა;

SELECT COUNT(*) AS EventCount
FROM dbo.Event e
JOIN dbo.Country c ON e.CountryId = c.CountryId
JOIN dbo.Continent ct ON c.ContinentId = ct.ContinentId
WHERE ct.ContinentName = 'Europe';

-- გამოიტანეთ აფრიკაში ყველაზე ადრე გამართული მოვლენის თარიღი;

SELECT MIN(e.EventDate) AS EarliestEventDate
FROM dbo.Event e
JOIN dbo.Country c ON e.CountryId = c.CountryId
JOIN dbo.Continent ct ON c.ContinentId = ct.ContinentId
WHERE ct.ContinentName = 'Africa';


-- გამოიტანეთ ჩრდილოეთ და სამხრეთ ამერიკაში არსებული ქვეყნების რაოდენობა;

SELECT COUNT(*) AS CountryCount
FROM dbo.Country c
JOIN dbo.Continent ct ON c.ContinentId = ct.ContinentId
WHERE ct.ContinentName IN ('North America', 'South America');


-- გამოიტანეთ ახალ წელს გამართული ეკონომიკასთან დაკავშირებული მოვლენების რაოდენობა;

SELECT COUNT(*) AS EventCount
FROM dbo.Event e
JOIN dbo.Category c ON e.CategoryId = c.CategoryId
WHERE c.CategoryName = 'Economy'
  AND MONTH(e.EventDate) = 12
  AND DAY(e.EventDate) = 31;


-- გამოიტანეთ ევროპაში ყველაზე გვიან გამართული, სპორტის კატეგორიასთან დაკავშირებული მოვლენის თარიღი.

SELECT MAX(e.EventDate) AS RecentEventDate
FROM dbo.Event e
JOIN dbo.Category c ON e.CategoryId = c.CategoryId
JOIN dbo.Country co ON e.CountryId = co.CountryId
JOIN dbo.Continent ct ON co.ContinentId = ct.ContinentId
WHERE c.CategoryName = 'Sports'
  AND ct.ContinentName = 'Europe';