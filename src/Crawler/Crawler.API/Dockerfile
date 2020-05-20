FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS final
EXPOSE 80
EXPOSE 443
COPY ["bin/Release/netcoreapp3.1/publish/", "app/"]
WORKDIR /app
ENTRYPOINT ["dotnet", "Crawler.API.dll"]