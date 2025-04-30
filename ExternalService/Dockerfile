# Base runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0-jammy AS base
WORKDIR /app
EXPOSE 2000
ENV ASPNETCORE_URLS=http://+:2000
ENV ASPNETCORE_ENVIRONMENT=Development

# Build image
FROM mcr.microsoft.com/dotnet/sdk:8.0-jammy AS build
WORKDIR /src
COPY ["ExternalService/ExternalService*.csproj", "ExternalService/"]
RUN dotnet restore "ExternalService/ExternalService.csproj"
COPY . .
WORKDIR "/src/ExternalService"
RUN dotnet build "ExternalService.csproj" -c Release -o /app/build

# Publish image
FROM build AS publish
RUN dotnet publish "ExternalService.csproj" -c Release -o /app/publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExternalService.dll"]