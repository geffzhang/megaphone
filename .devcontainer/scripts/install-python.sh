#!/bin/bash
################################################################################
##  File:  install-python.sh
##  Desc:  Installs Python utils
################################################################################
DEFAULT_UTILS="\
    pylint \
    flake8 \
    autopep8 \
    black \
    pytest \
    yapf \
    mypy \
    pydocstyle \
    pycodestyle \
    bandit \
    virtualenv"

mkdir -p ${PIPX_BIN_DIR} 
export PYTHONUSERBASE=/tmp/pip-tmp 
apt-get -y install --no-install-recommends python3-venv python3-pip;
pip3 install --disable-pip-version-check --no-warn-script-location --no-cache-dir --user pipx 
/tmp/pip-tmp/bin/pipx install --pip-args=--no-cache-dir pipx 
echo "${DEFAULT_UTILS}" | xargs -n 1 /tmp/pip-tmp/bin/pipx install --system-site-packages --pip-args=--no-cache-dir 
chown -R ${USER_UID}:${USER_GID} ${PIPX_HOME}
rm -rf /tmp/pip-tmp 