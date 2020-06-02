#-------------------------------------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the MIT License. See https://go.microsoft.com/fwlink/?linkid=2090316 for license information.
#-------------------------------------------------------------------------------------------------------------
# Debian 10 base 
FROM mcr.microsoft.com/dotnet/core/sdk:3.1

# The node image includes a non-root user with sudo access. Use the 
# "remoteUser" property in devcontainer.json to use it. On Linux, update 
# these values to ensure the container user's UID/GID matches your local values.
# See https://aka.ms/vscode-remote/containers/non-root-user for details.
ARG USERNAME=vscode
ARG USER_UID=1000
ARG USER_GID=$USER_UID

# Docker Compose version
ARG COMPOSE_VERSION=1.24.0

# [Optional] Install Go 
ARG INSTALL_GO="true" 

# [Optional] Version of Node.js to install
ARG INSTALL_NODE="true"
ARG NODE_VERSION="lts/*"
ENV NVM_DIR=/home/vscode/.nvm

# [Optional] Install Python 
ARG INSTALL_PYTHON="true" 
ENV PIPX_HOME=/usr/local/py-utils
ENV PIPX_BIN_DIR=${PIPX_HOME}/bin
ENV PATH=${PATH}:${PIPX_BIN_DIR}

COPY scripts /scripts 

# Configure apt and install packages
RUN apt-get update \
    && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install --no-install-recommends apt-utils dialog 2>&1 \
    #
    # Verify git, process tools, lsb-release (common in install instructions for CLIs) installed
    && apt-get -y install git openssh-client less iproute2 procps apt-transport-https gnupg2 curl lsb-release \
    #
    # Install Docker CE CLI
    && apt-get install -y apt-transport-https ca-certificates curl gnupg-agent software-properties-common lsb-release \
    && curl -fsSL https://download.docker.com/linux/$(lsb_release -is | tr '[:upper:]' '[:lower:]')/gpg | (OUT=$(apt-key add - 2>&1) || echo $OUT) \
    && add-apt-repository "deb [arch=amd64] https://download.docker.com/linux/$(lsb_release -is | tr '[:upper:]' '[:lower:]') $(lsb_release -cs) stable" \
    && apt-get update \
    && apt-get install -y docker-ce-cli \
    #
    # Install Docker Compose
    && curl -sSL "https://github.com/docker/compose/releases/download/${COMPOSE_VERSION}/docker-compose-$(uname -s)-$(uname -m)" -o /usr/local/bin/docker-compose \
    && chmod +x /usr/local/bin/docker-compose \
    #
    # Install Dapr
    && wget -q https://raw.githubusercontent.com/dapr/cli/master/install/install.sh -O - | /bin/bash \
    #  
    # Create a non-root user to use if preferred - see https://aka.ms/vscode-remote/containers/non-root-user.
    && groupadd --gid $USER_GID $USERNAME \
    && useradd -s /bin/bash --uid $USER_UID --gid $USER_GID -m $USERNAME \
    # Add sudo support for the non-root user
    && apt-get install -y sudo \
    && echo $USERNAME ALL=\(root\) NOPASSWD:ALL > /etc/sudoers.d/$USERNAME\
    && chmod 0440 /etc/sudoers.d/$USERNAME \
    #
    && chmod +x /scripts/* \
    # Install the Azure CLI and k8s tools 
    && /scripts/install-azurecli.sh \
    && /scripts/install-kubernetes-tools.sh \
    #
    # Install Node.js for ASP.NET Core Web Applications
    && if [ "$INSTALL_NODE" = "true" ]; then \
        /scripts/install-node.sh; \
    fi \
    #
    # Install Go 
    && if [ "$INSTALL_GO" = "true" ]; then \
        /scripts/install-go.sh; \
    fi \
    #
    # Install Python 
    && if [ "$INSTALL_PYTHON" = "true" ]; then \
        /scripts/install-python.sh; \
    fi \
    # Clean up
    && apt-get autoremove -y \
    && apt-get clean -y \
    && rm -rf /var/lib/apt/lists/*
# GO  
ENV GOPATH /go
ENV PATH $GOPATH/bin:/usr/local/go/bin:$PATH
RUN mkdir -p "$GOPATH/src" "$GOPATH/bin" && chmod -R 777 "$GOPATH"
ENV GO111MODULE=auto

# Switch back to dialog for any ad-hoc use of apt-get
ENV DEBIAN_FRONTEND=dialog