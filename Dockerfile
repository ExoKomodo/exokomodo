FROM mcr.microsoft.com/dotnet/sdk:5.0 as builder

WORKDIR /exokomodo/Server

COPY ./Server .

RUN dotnet publish --configuration Release

FROM mcr.microsoft.com/dotnet/aspnet:5.0

COPY --from=builder /exokomodo/Server /exokomodo/Server

RUN apt update
RUN apt install nginx -y

WORKDIR /exokomodo/nginx
COPY ./nginx .

RUN rm -f /etc/nginx/sites-enabled/*
RUN ln -f Server.conf /etc/nginx/sites-available/Server.conf
RUN ln -s /etc/nginx/sites-available/Server.conf /etc/nginx/sites-enabled/Server.conf

EXPOSE 80
ENV ASPNETCORE_URLS=http://+:5000

COPY ./deployment_scripts /exokomodo/deployment_scripts
WORKDIR /exokomodo
CMD ["deployment_scripts/run_net_app.sh", "Server"]
