FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /app
#
# copy csproj and restore as distinct layers

COPY *.sln .
COPY ./src/Jaya.API/*.csproj ./src/Jaya.API/
COPY ./src/Jaya.Application/*.csproj ./src/Jaya.Application/
COPY ./src/Jaya.Domain/*.csproj ./src/Jaya.Domain/
COPY ./src/Jaya.Infrastructure/*.csproj ./src/Jaya.Infrastructure/
COPY ./tests/*.csproj ./tests/

#
RUN dotnet restore 
#
# copy everything else and build app
COPY ./src/Jaya.API/. ./src/Jaya.API/
COPY ./src/Jaya.Application/. ./src/Jaya.Application/
COPY ./src/Jaya.Domain/. ./src/Jaya.Domain/
COPY ./src/Jaya.Infrastructure/. ./src/Jaya.Infrastructure/
COPY ./tests/. ./tests/
#
WORKDIR /app
RUN dotnet publish -c Release -o out 
#
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS runtime
WORKDIR /app
#
COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Jaya.API.dll"]