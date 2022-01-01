FROM mcr.microsoft.com/dotnet/sdk:5.0

COPY . /app

WORKDIR /app/src/Server
RUN bash /app/compose_scripts/build.sh

WORKDIR /app/src/Server/bin/Release/net5.0/build

RUN Server
