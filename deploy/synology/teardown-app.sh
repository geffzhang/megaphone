docker-compose -p megaphone-app -f docker-compose-app.yml down --remove-orphans

docker image prune -a -f
docker volume prune -f
docker system prune -f