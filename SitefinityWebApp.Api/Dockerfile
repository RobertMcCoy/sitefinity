FROM microsoft/dotnet:1.0.0-core
WORKDIR /app
ENV ASPNETCORE_URLS http://*:1190
EXPOSE 1190
ENTRYPOINT ["dotnet", "SitefinityWebApp.Api.dll"]
COPY . /app
