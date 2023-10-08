FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["program-workflow-service/program-workflow-service.csproj", "program-workflow-service/"]
RUN dotnet restore "program-workflow-service/program-workflow-service.csproj"
COPY . .
WORKDIR "/src/program-workflow-service"
RUN dotnet build "program-workflow-service.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "program-workflow-service.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "program-workflow-service.dll"]
