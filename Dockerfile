# Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o out

# Run
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .
VOLUME ["/lyrics"]
ENV ASPNETCORE_URLS=http://*:80
ENV ASPNETCORE_HTTP_PORTS=80

EXPOSE ${ASPNETCORE_HTTP_PORTS}
CMD ./LyricAPI
