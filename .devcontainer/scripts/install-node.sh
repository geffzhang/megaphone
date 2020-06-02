#!/bin/bash
################################################################################
##  File:  install-node.sh
##  Desc:  Installs nvm, node and yarn 
################################################################################
mkdir ${NVM_DIR}
curl -so- https://raw.githubusercontent.com/creationix/nvm/v0.34.0/install.sh | bash 2>&1
chown -R vscode:vscode ${NVM_DIR}
/bin/bash -c "source $NVM_DIR/nvm.sh \
    && nvm install ${NODE_VERSION} \
    && nvm alias default ${NODE_VERSION}" 2>&1
INIT_STRING='[ -s "$NVM_DIR/nvm.sh" ] && \\. "$NVM_DIR/nvm.sh"  && [ -s "$NVM_DIR/bash_completion" ] && \\. "$NVM_DIR/bash_completion"' \
echo $INIT_STRING >> /home/vscode/.bashrc
echo $INIT_STRING >> /home/vscode/.zshrc
echo $INIT_STRING >> /root/.zshrc
#
# Install yarn
curl -sS https://dl.yarnpkg.com/$(lsb_release -is | tr '[:upper:]' '[:lower:]')/pubkey.gpg | apt-key add - 2>/dev/null
echo "deb https://dl.yarnpkg.com/$(lsb_release -is | tr '[:upper:]' '[:lower:]')/ stable main" | tee /etc/apt/sources.list.d/yarn.list
apt-get update
apt-get -y install --no-install-recommends yarn;