FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./src/AllPlay.Services.Identity.Api/AllPlay.Services.Identity.Api.csproj"
RUN dotnet publish "./src/AllPlay.Services.Identity.Api/AllPlay.Services.Identity.Api.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app ./
ENV ASPNETCORE_URLS http://*:5001
ENV ASPNETCORE_ENVIRONMENT docker

EXPOSE 5001

ENTRYPOINT ["dotnet", "AllPlay.Services.Identity.Api.dll"]