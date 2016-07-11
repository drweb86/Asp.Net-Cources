-- CRUD Create Read Update Delete
SELECT 
	Name, 
	Price, 
	Price*100 as KAKA 
FROM Good

SELECT 
	Name, 
	Price, 
	Price*100 as KAKA 
FROM Good
WHERE Good_UID = 2

SELECT 
	Name, 
	Price
FROM Good
WHERE Price * 13 > 2

SELECT 
	Name, 
	Price
FROM Good
WHERE 
	Name like '%a%' AND 
	Price < 1000000

-- Insert samples

INSERT INTO Good (Name, Price)
VALUES ('ChinePhone', 500)

-- Update

UPDATE Good
SET
	Name = 'Taiwan'
WHERE
	Name = 'ChinePhone'
	

-- Deletions!!!!

DELETE FROM Good
WHERE
	Name = 'ChinePhone' -- Sanctions!!!

-- Joins

SELECT 
	Good.Name as 'Good Name',
	Catalog.Name as 'Catalog Name'
FROM Good
INNER JOIN CatalogGood
	ON CatalogGood.Good_UID = Good.Good_UID
INNER JOIN Catalog
	ON Catalog.Catalog_UID = CatalogGood.Catalog_UID


SELECT Name
FROM [User]
Where 
	Name like 'u%'

SELECT [User].Name
FROM [User]
INNER JOIN
	UserRole
ON [User].UserUID = UserRole.UserUID
INNER JOIN
	[Role]
ON [Role].RoleUID = UserRole.RoleUID
WHERE 
	[Role].Name = 'Администраторы'

DELETE FROM [Role]
WHERE Name = 'Test'

UPDATE [Catalog]
SET
	Name = 'New name'
WHERE
	Name = 'Old name'

DELETE Good 
FROM Good
INNER JOIN
	CatalogGood
ON Good.Good_UID = CatalogGood.Good_UID
INNER JOIN
	Catalog
ON Catalog.Catalog_UID = CatalogGood.Catalog_UID
WHERE 
	Catalog.Name = 'Row';


DELETE FROM Catalog
WHERE Name = 'Row'