FROM mcr.microsoft.com/dotnet/sdk:5.0 as builder
WORKDIR /exokomodo

COPY . .

WORKDIR /exokomodo/Server
RUN dotnet publish --configuration Release

FROM mcr.microsoft.com/dotnet/aspnet:5.0

COPY --from=builder /exokomodo /exokomodo
WORKDIR /exokomodo/Server/bin/Release/net5.0/publish

CMD ["./Server"]
