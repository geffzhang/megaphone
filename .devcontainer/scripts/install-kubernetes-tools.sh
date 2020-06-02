#!/bin/bash
################################################################################
##  File:  kubernetes-tools.sh
##  Desc:  Installs kubectl, helm
################################################################################

# Install kubectl
echo "Installing kubectl"
curl -sSL -o /usr/local/bin/kubectl https://storage.googleapis.com/kubernetes-release/release/$(curl -s https://storage.googleapis.com/kubernetes-release/release/stable.txt)/bin/linux/amd64/kubectl
chmod +x /usr/local/bin/kubectl
echo "kubectl installed"

# Install Helm
curl -s https://raw.githubusercontent.com/helm/helm/master/scripts/get-helm-3 | bash -

# Run tests to determine that the software installed as expected
echo "Testing to make sure that script performed as expected, and basic scenarios work"
if ! command -v kubectl; then
    echo "kubectl was not installed"
    exit 1
fi

if ! command -v helm; then
    echo "helm was not installed"
    exit 1
fi
