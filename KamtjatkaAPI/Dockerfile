FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /source

# Copy everything and build
COPY . ./
#RUN dotnet publish -c release -o out
RUN dotnet publish -c release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "KamtjatkaAPI.dll"]