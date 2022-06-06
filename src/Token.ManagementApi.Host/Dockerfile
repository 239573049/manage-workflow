FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Token.ManagementApi.Host/Token.ManagementApi.Host.csproj", "Token.ManagementApi.Host/"]
RUN dotnet restore "Token.ManagementApi.Host/Token.ManagementApi.Host.csproj"
COPY . .
WORKDIR "/src/Token.ManagementApi.Host"
RUN dotnet build "Token.ManagementApi.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Token.ManagementApi.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Token.ManagementApi.Host.dll"]
