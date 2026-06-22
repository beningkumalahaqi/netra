FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY Directory.Packages.props ./
COPY src/Netra.Api/Netra.Api.csproj src/Netra.Api/
COPY src/Netra.Core/Netra.Core.csproj src/Netra.Core/
COPY src/Netra.Infrastructure/Netra.Infrastructure.csproj src/Netra.Infrastructure/
RUN dotnet restore src/Netra.Api/Netra.Api.csproj

COPY . .
RUN dotnet publish src/Netra.Api/Netra.Api.csproj -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
EXPOSE 8080

RUN adduser --disabled-password --gecos '' appuser && chown -R appuser /app
USER appuser

COPY --from=build /app/publish .

HEALTHCHECK --interval=15s --timeout=5s --retries=3 \
  CMD curl --fail http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "Netra.Api.dll"]
