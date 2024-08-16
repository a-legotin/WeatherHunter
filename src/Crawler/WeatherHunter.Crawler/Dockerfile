FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Crawler/WeatherHunter.Crawler/WeatherHunter.Crawler.csproj", "Crawler/WeatherHunter.Crawler/"]
COPY ["Crawler/Sources/WeatherHunter.Crawler.Sources.Abstractions/WeatherHunter.Crawler.Sources.Abstractions.csproj", "Crawler/Sources/WeatherHunter.Crawler.Sources.Abstractions/"]
COPY ["WeatherHunter.Abstractions/WeatherHunter.Abstractions.csproj", "WeatherHunter.Abstractions/"]
COPY ["Crawler/Sources/WeatherHunter.Crawler.Sources.RandomSource/WeatherHunter.Crawler.Sources.RandomSource.csproj", "Crawler/Sources/WeatherHunter.Crawler.Sources.RandomSource/"]
RUN dotnet restore "Crawler/WeatherHunter.Crawler/WeatherHunter.Crawler.csproj"
COPY . .
WORKDIR "/src/Crawler/WeatherHunter.Crawler"
RUN dotnet build "WeatherHunter.Crawler.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherHunter.Crawler.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherHunter.Crawler.dll"]
