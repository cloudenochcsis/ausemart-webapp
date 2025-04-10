FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AusemartApi/AusemartApi.csproj", "AusemartApi/"]
RUN dotnet restore "AusemartApi/AusemartApi.csproj"
COPY . .
WORKDIR "/src/AusemartApi"
RUN dotnet build "AusemartApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AusemartApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AusemartApi.dll"]