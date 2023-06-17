-- TSQL 2012 


-- გამოიტანეთ ლონდონელი და მადრიდელი კლიენტების გვარი, სახელი, ქალაქი და შეკვეთების თარიღები

SELECT c.contactname, c.city, o.orderdate
FROM Sales.Customers AS c
JOIN Sales.Orders AS o ON c.custid = o.custid
WHERE c.city IN ('London', 'Madrid');


-- გამოიტანეთ იმ პროდუქტების სახელწოდება ზედა რეგისტრში, ფასი და კატეგორია, რომელთა ფასი 20-დან 40-მდეა; 

SELECT p.productname, p.unitprice, c.categoryname
FROM Production.Products AS p
JOIN Production.Categories AS c ON p.categoryid = c.categoryid
WHERE p.unitprice BETWEEN 20 AND 40;


-- გამოიტანეთ გაყიდვების მენეჯერების გვარი, სახელი და შეკვეთების იდენტიფიკატორი (orderid), რომელსაც Sales Manager მოემსახურნენ. გამოიტანეთ მხოლოდ 50 -ზე მეტი წონის შეკვეთები; 

SELECT e.firstname, e.lastname, o.orderid, o.freight
FROM HR.Employees as e
JOIN Sales.Orders as o ON e.empid = o.empid AND o.freight > 50
WHERE e.title = 'Sales Manager';


-- გამოიტანეთ შეკვეთის თარიღი, კლიენტის გვარი, სახელი, ქალაქი და მისამართი იმ შეკვეთებისათვის, რომლებიც გაკეთდა 2007 წელს ამერიკული კომპანიის მიერ; 

SELECT sup.country, cust.contactname, cust.city, cust.address, ord.orderdate
FROM Sales.Orders as ord
JOIN Sales.OrderDetails as ordd ON ordd.orderid = ord.orderid
JOIN Production.Products as prod ON ordd.productid = prod.productid
JOIN Production.Suppliers as sup ON prod.supplierid = sup.supplierid
JOIN Sales.Customers as cust ON ord.custid = cust.custid
WHERE sup.country = 'USA' AND YEAR(ord.orderdate) = 2007


-- გამოიტანეთ იმ ქალაქების სახელები, სადაც მოხდა კომპანიის თანამშრომელ Cameron -ის მიღებული შეკვეთების ტრანსპორტირება. მიღებულ ვირტუალურ ცხრილში ქალაქების სახელები არ განმეორდეს; 

SELECT DISTINCT ord.shipcity, emp.lastname
FROM Sales.Orders as ord
JOIN HR.Employees as emp ON ord.empid = emp.empid AND emp.lastname = 'Cameron'


-- გამოიტანეთ გადამზიდავი კომპანიების მიერ გერმანიაში და ავსტრიაში ტრანსპორტირებული შეკვეთების id (orderid), ასევე ქვეყანა და ქალაქი, სადაც მოხდა შეკვეთის ტრანსპორტირება;

SELECT ord.orderid, ord.shipcountry, ord.shipcity
FROM Sales.Orders as ord
WHERE shipcountry in ('Germany', 'Austria')


-- გამოიტანეთ სრული მონაცემები ტოკიოდან (Tokyo) მოწოდებული იმ პროდუქტების შესახებ, რომლებზეც მოქმედებს ფასდაკლება; 

SELECT prod.productid, prod.productname, prod.supplierid, prod.categoryid, prod.unitprice, prod.discontinued
FROM Production.Products as prod
JOIN Production.Suppliers as sup ON prod.supplierid = sup.supplierid 
WHERE prod.discontinued > 0 AND sup.city = 'Tokyo'


-- გამოიტანეთ იაპონიიდან მოწოდებული ზღვის პროდუქტების და სასმელების დასახელებები კატეგორიის სახელწოდებებთან ერთად; 

SELECT prod.productname, cat.categoryname
FROM Production.Products as prod
JOIN Production.Suppliers as sup ON prod.supplierid = sup.supplierid AND sup.country = 'Japan'
JOIN Production.Categories as cat ON prod.categoryid = cat.categoryid AND cat.categoryname IN ('Seafood', 'Beverages')


-- გამოიტანეთ კომპანიის თანამშრომლების სახელი და გვარი და გადამზიდავი კომპანიების სახელწოდებები,
-- რომლებმაც 2007 წელს გადაზიდეს შეკვეთები, რომლებსაც მოემსახურნენ სარა დევისი (Sara Davis) და მარია ქემერონი (Maria Cameron); 

SELECT emp.firstname, emp.lastname, shp.companyname
FROM HR.Employees as emp
JOIN Sales.Orders as ord ON emp.empid = ord.empid
JOIN Sales.Shippers as shp ON ord.shipperid = shp.shipperid
WHERE (emp.firstname = 'Sara' AND emp.lastname = 'Davis') OR (emp.firstname = 'Maria' AND emp.lastname = 'Cameron')


-- გამოიტანეთ ამერიკელი მწარმოებლების მიერ წარმოებული იმ პროდუქტების სახელწოდებები და კატეგორიები, რომლებიც არ მიეკუთვნება ზღვის პროდუქტების და წვენების კატეგორიას; 

SELECT prod.productname, cat.categoryname
FROM Production.Products as prod
JOIN Production.Suppliers as sup ON prod.supplierid = sup.supplierid
JOIN Production.Categories as cat ON prod.categoryid = cat.categoryid AND cat.categoryname NOT IN ('seafood', 'Beverages')


-- გამოიტანეთ შეკვეთის ნომერი, კომპანიის თანამშრომლის გვარი, სახელი და საცხოვრებელი ქალაქი, 
-- კლიენტის სახელი და გვარი იმ შეკვეთებისათვის, რომლის კლიენტი და კომპანიის თანამშრომელი ცხოვრობენ ერთ ქალაქში; 

SELECT ord.orderid, emp.empid, emp.city, cust.contactname, cust.city
FROM Sales.Orders as ord 
JOIN HR.Employees as emp ON emp.empid = ord.empid
JOIN Sales.Customers as cust ON cust.custid = ord.custid
WHERE emp.city = cust.city


-- გამოიტანეთ იმ კლიენტების სახელი და გვარი, რომლებმაც შეუკვეთეს სასმელები (Beverages) ან რძის პროდუქტები (Dairy Products). 
-- ერთი და იგივე კლიენტის სახელი და გვარი გამოიტანეთ მხოლოდ ერთხელ. 

SELECT DISTINCT cust.contactname
FROM Sales.Orders as ord 
JOIN Sales.Customers as cust ON cust.custid = ord.custid
JOIN Sales.OrderDetails as ordd ON ord.orderid = ordd.orderid
JOIN Production.Products as prod ON ordd.productid = prod.productid
JOIN Production.Categories as cat ON prod.categoryid = cat.categoryid AND cat.categoryname IN ('Beverages', 'Dairy Products')