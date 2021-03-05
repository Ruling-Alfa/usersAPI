# Build Stage

FROM mcr.microsoft.com/dotnet/sdk:5.0 as build

WORKDIR /source

COPY . .

RUN dotnet restore 

RUN dotnet publish --output /app --configuration Release

# Publish Stage

FROM mcr.microsoft.com/dotnet/aspnet:5.0 as final

COPY --from=build ./app /app

WORKDIR /app

ENTRYPOINT ["dotnet", "UsersApi.dll"]