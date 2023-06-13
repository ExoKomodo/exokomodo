FROM mcr.microsoft.com/dotnet/sdk:7.0

COPY . /app

WORKDIR /app

EXPOSE 80
ENV JENKINS_USER=112
ENV JENKINS_GROUP=119
ENV ASPNETCORE_URLS=http://+:5000

RUN apt update -y

RUN bash admin_scripts/setup_jenkins_user.sh
