FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env

WORKDIR /App

COPY . ./

RUN dotnet restore

RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0

EXPOSE 80

WORKDIR /App

COPY --from=build-env /App/out .

VOLUME [ "/logs" ]

CMD dotnet tool install --global dotnet-ef 

ENTRYPOINT ["dotnet", "Multiapi.dll"]