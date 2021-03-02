#!/bin/bash

echo "deploy app only"
docker-compose -p megaphone-app -f docker-compose-app.yml up -d --force-recreate