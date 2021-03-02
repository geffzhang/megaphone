docker-compose -p megaphone-app -f docker-compose-app.yml down --remove-orphans

docker-compose -p megaphone-infra -f docker-compose-infra.yml down --remove-orphans

docker volume prune -f