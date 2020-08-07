dotnet restore "./src/Crawler/Crawler.sln"

dotnet build "./src/Crawler/Crawler.sln" --configuration Release --no-restore

dotnet test "./src/Crawler/Crawler.Tests/Crawler.Tests.csproj" --no-restore --verbosity normal

dotnet publish "./src/Crawler/Crawler.API/Crawler.API.csproj" -c Release --no-restore --verbosity normal

docker build -f "./src/Crawler/Crawler.API/Dockerfile" --force-rm -t crawler-api "./src/Crawler/Crawler.API/"

# docker run --rm -it  -p 443:443/tcp -p 80:80/tcp crawler-api:latest