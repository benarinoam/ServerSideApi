# WebApiRestful/dockerfile.server
# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src

# copy csproj and restore (cached)
COPY *.csproj ./
RUN dotnet restore

# copy everything and publish
COPY . .
RUN dotnet publish -c Release -o /app/publish /p:PublishTrimmed=false

# Stage 2: Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR /app
ENV ASPNETCORE_URLS=http://+:80

# Copy the published output
COPY --from=build /app/publish ./

EXPOSE 5000
ENTRYPOINT ["dotnet", "WebApiRestful.dll"]
