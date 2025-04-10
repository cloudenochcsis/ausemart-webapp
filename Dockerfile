# We use this stage to build/prepare the dotnet app
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-stage
WORKDIR /ausemartweb

# Copy everything (AusemartApi is excluded via .dockerignore)
COPY . ./

RUN dotnet restore ausemartweb.csproj
RUN dotnet publish ausemartweb.csproj -c Release -o out

# We use this stage to serve the app
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /ausemartweb
COPY --from=build-stage /ausemartweb/out .
ENTRYPOINT ["dotnet", "ausemartweb.dll"]