# TODO: Change dockerfile to use our own image
FROM mcr.microsoft.com/dotnet/aspnet:5.0 as deployment

COPY . /app

WORKDIR /app/src/Server
RUN bash /app/compose_scripts/build.sh

WORKDIR /app/src/Server/bin/Release/net5.0/build

RUN Server
