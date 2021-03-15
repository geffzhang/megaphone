#!/bin/bash

echo "deploy infra"
sudo docker-compose -p dev-infra -f docker-compose-infra.yml up -d