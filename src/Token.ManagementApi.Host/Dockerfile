FROM mcr.microsoft.com/dotnet/aspnet:6.0.3-alpine3.15-amd64 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0.201-alpine3.15-amd64 AS build
WORKDIR /src
COPY ["src/Token.ManagementApi.Host/Token.ManagementApi.Host.csproj", "src/Token.ManagementApi.Host/"]
COPY ["src/Token.Infrastructure/Token.Infrastructure.csproj", "src/Token.Infrastructure/"]
COPY ["src/Token.Mangement.Domain/Token.Mangement.Domain.csproj", "src/Token.Mangement.Domain/"]
COPY ["src/Token.Management.Domain.Shared/Token.Management.Domain.Shared.csproj", "src/Token.Management.Domain.Shared/"]
COPY ["src/Token.HttpApi/Token.HttpApi.csproj", "src/Token.HttpApi/"]
COPY ["src/Token.Management.Application/Token.Management.Application.csproj", "src/Token.Management.Application/"]
COPY ["src/Token.Management.Application.Contracts/Token.Management.Application.Contracts.csproj", "src/Token.Management.Application.Contracts/"]
COPY ["src/Token.Management.EntityFrameworkCore/Token.Management.EntityFrameworkCore.csproj", "src/Token.Management.EntityFrameworkCore/"]
RUN dotnet restore "src/Token.ManagementApi.Host/Token.ManagementApi.Host.csproj"
COPY . .
WORKDIR "/src/src/Token.ManagementApi.Host"
RUN dotnet build "Token.ManagementApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Token.ManagementApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Token.ManagementApi.Host.dll"]
