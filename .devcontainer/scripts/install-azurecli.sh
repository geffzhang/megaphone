#!/bin/bash
################################################################################
##  File:  azurecli.sh
##  Desc:  Installs Azure CLI
################################################################################
echo "deb [arch=amd64] https://packages.microsoft.com/repos/azure-cli/ $(lsb_release -cs) main" > /etc/apt/sources.list.d/azure-cli.list
curl -sL https://packages.microsoft.com/keys/microsoft.asc | apt-key add - 2>/dev/null 
apt-get update 
apt-get install -y azure-cli

echo "Testing to make sure that script performed as expected, and basic scenarios work"
if ! command -v az; then
    echo "azure-cli was not installed"
    exit 1
fi