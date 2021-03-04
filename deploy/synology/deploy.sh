#!/bin/bash

echo "deploy infra"
docker-compose -p megaphone-infra -f docker-compose-infra.yml pull
docker-compose -p megaphone-infra -f docker-compose-infra.yml up -d --force-recreate

echo "wait (1 minute) for SQL to be ready"
sleep 45s

echo "create megaphone database"
docker exec -it sqlserver /opt/mssql-tools/bin/sqlcmd \
   -S localhost -U sa -P "Qwerty1!" \
   -Q 'CREATE DATABASE megaphone'

echo "deploy app"
docker-compose -p megaphone-app -f docker-compose-app.yml pull
docker-compose -p megaphone-app -f docker-compose-app.yml up -d --force-recreate

docker image prune -a -f
docker volume prune -f