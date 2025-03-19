FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["tcc1_api.csproj", "."]
RUN dotnet restore "./tcc1_api.csproj"
COPY . .
RUN dotnet build "tcc1_api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "tcc1_api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tcc_api.dll"]