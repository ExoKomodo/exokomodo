############
# Builder #
############
FROM mcr.microsoft.com/dotnet/sdk:5.0 as builder

COPY ./src/Server /Server

WORKDIR /Server

RUN dotnet publish --configuration Release

############
# Deployer #
############
FROM mcr.microsoft.com/dotnet/aspnet:5.0 as deployer

COPY --from=builder /Server /Server

RUN apt update -y
RUN apt install nginx -y

RUN rm -f /etc/nginx/sites-enabled/*
RUN ln -f /Server/nginx/Server.conf /etc/nginx/sites-available/Server.conf
RUN ln -s /etc/nginx/sites-available/Server.conf /etc/nginx/sites-enabled/Server.conf

EXPOSE 80
ENV ASPNETCORE_URLS=http://+:5000

WORKDIR /Server
CMD ["bash", "./deploy.sh"]
