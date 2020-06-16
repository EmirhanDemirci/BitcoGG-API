FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /src
COPY . /src
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
EXPOSE 443
WORKDIR /app
COPY --from=build-env /src/out .
ENTRYPOINT ["dotnet", "BitcoGG-API.dll"]