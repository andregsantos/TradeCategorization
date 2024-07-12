# Use the official .NET 8 SDK image as a build environment
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./

# Copy everything else and build
COPY . ./
RUN dotnet publish  -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Set environment variables
ENV DOTNET_ENVIRONMENT=Production
ENV JWT_KEY=3DAA9B05206964019C7C08A344095843C6B1A8974F902B04063A494B
ENV JWT_ISSUER=trade

# Expose port 3594
EXPOSE 3594

# Start the application
ENTRYPOINT ["dotnet", "TradeCategorization.API.dll"]
