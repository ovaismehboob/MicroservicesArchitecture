FROM microsoft/aspnetcore:2.0-nanoserver-1709 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-nanoserver-1709 AS build
WORKDIR /src
COPY *.sln ./
COPY src/CAS/Identity/Identity.AuthServer/Identity.AuthServer.csproj src/CAS/Identity/Identity.AuthServer/
RUN dotnet restore
COPY . .
WORKDIR /src/src/CAS/Identity/Identity.AuthServer
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Identity.AuthServer.dll"]
