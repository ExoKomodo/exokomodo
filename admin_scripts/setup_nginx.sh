# /bin/bash

apt install nginx -y
rm -f /etc/nginx/sites-enabled/*
ln -f /app/nginx/Server.conf /etc/nginx/sites-available/Server.conf
ln -s /etc/nginx/sites-available/Server.conf /etc/nginx/sites-enabled/Server.conf

nginx