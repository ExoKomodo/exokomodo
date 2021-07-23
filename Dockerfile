FROM mcr.microsoft.com/dotnet/sdk:5.0 as builder
WORKDIR /exokomodo

COPY . .

WORKDIR /exokomodo
RUN dotnet publish ExoKomodo.sln --configuration Release

FROM mcr.microsoft.com/dotnet/aspnet:5.0

COPY --from=builder /exokomodo /exokomodo
WORKDIR /exokomodo/bin/Release/net5.0/publish

CMD ["ExoKomodo"]
