FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App

ENV ASPNETCORE_FORWARDEDHEADERS_ENABLED=true

# Copy everything
COPY ./src/ArticleAzureWebApp/ ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "ArticleWebApp.dll"]