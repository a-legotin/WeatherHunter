FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["WeatherHunter.Crawler/WeatherHunter.Crawler.csproj", "WeatherHunter.Crawler/"]
RUN dotnet restore "WeatherHunter.Crawler/WeatherHunter.Crawler.csproj"
COPY . .
WORKDIR "/src/WeatherHunter.Crawler"
RUN dotnet build "WeatherHunter.Crawler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherHunter.Crawler.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherHunter.Crawler.dll"]
