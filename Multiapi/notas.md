###Base de datos MySql
docker run -d --name mysql -e MYSQL_ROOT_PASSWORD=clase231 -p 3306:3306 mysql:latest

###Base de datos SqlServer
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Clase231" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest

###Base de datos Postgre
docker run --name some-postgres -e POSTGRES_PASSWORD=clase231 -p 5432:5432 -d postgres

###Instalar dependencias
dotnet tool install --global dotnet-ef

###Crear/Actualizar bases de datos
dotnet ef migrations add nombreMigracion
dotnet ef database update

#!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
#PARA EJECUTAR PROYECTO
#!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
docker-compose up -d 
dotnet ef database update --context UsersContextMySql
dotnet ef database update --context UsersContextPostgres
dotnet ef database update --context UsersContextSqlServer
luego ir a http://localhost:5000/swagger y interactuar con el swagger (Hasta que se cree una app que interactue con la api)