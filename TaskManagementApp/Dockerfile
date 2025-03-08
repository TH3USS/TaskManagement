# Definir a imagem base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Definir a imagem de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TaskManagementApp/TaskManagementApp.csproj", "TaskManagementApp/"]
RUN dotnet restore "TaskManagementApp/TaskManagementApp.csproj"
COPY . .
WORKDIR "/src/TaskManagementApp"
RUN dotnet build "TaskManagementApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManagementApp.csproj" -c Release -o /app/publish

# Definir a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagementApp.dll"]
# Definir a imagem base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Definir a imagem de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["TaskManagementApp/TaskManagementApp.csproj", "TaskManagementApp/"]
RUN dotnet restore "TaskManagementApp/TaskManagementApp.csproj"
COPY . .
WORKDIR "/src/TaskManagementApp"
RUN dotnet build "TaskManagementApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TaskManagementApp.csproj" -c Release -o /app/publish

# Definir a imagem final
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TaskManagementApp.dll"]
