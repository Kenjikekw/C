Base de datos MySql
docker run -d --name mysql -e MYSQL_ROOT_PASSWORD=clase231 -p 3306:3306 mysql:latest

Base de datos SqlServer
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Clase231" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

Base de datos Postgre
docker run --name some-postgres -e POSTGRES_PASSWORD=clase231 -d postgres

Crear/Actualizar bases de datos
dotnet ef migrations add nombreMigracion
dotnet ef database update