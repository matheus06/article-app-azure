CREATE ROLE db_create
GRANT CREATE TABLE TO db_create
GRANT CREATE VIEW TO db_create
GRANT CREATE FUNCTION TO db_create
GRANT CREATE PROCEDURE TO db_create
GRANT ALTER ANY SCHEMA TO db_create

CREATE USER [matheus-article-api] FROM EXTERNAL PROVIDER;
ALTER ROLE db_datareader ADD MEMBER [matheus-article-app];
ALTER ROLE db_datawriter ADD MEMBER [matheus-article-app];
ALTER ROLE db_create ADD MEMBER [matheus-article-app];