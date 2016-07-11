
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
WHERE Name = 'Администраторы'




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