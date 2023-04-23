FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /app
WORKDIR /source

# Copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore "./KamtjatkaAPI/KamtjatkaAPI.csproj"

# Copy everything else and build
COPY . ./
#RUN dotnet publish -c release -o out
RUN dotnet publish -c release -o /app

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
#COPY --from=build /app/out .
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "KamtjatkaAPI.dll"]