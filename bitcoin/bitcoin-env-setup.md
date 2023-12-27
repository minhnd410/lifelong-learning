## Setup on Mac
Prerequisites
```bash
Git
python
Home Brew
Sqlite
```

Dependencies
```bash
# Install Xcode
xcode-select -—install

# Addusing home-brew, install automate, lib tool, boost, png-config, and libevent
brew install automake libtool boost pkg-config libevent

# Ensuring that python is installed
pip3 install ds_store mac_alias.
```

Optional Dependencies
```bash
# install berkeley-db@4 if you want to support legacy wallets
brew install berkeley-db@4

# install qt@5 if you intend to compile GUI:
brew install qt@5

# To build in QR support for the GUI, install qrencode:
brew install qrencode

# To support UPnP port mapping, install miniupnpc:
brew install miniupnpc

# To support NAT-PMP port mapping
install libnatpmp: brew install libnatpmp

# To support for ZMQ notifications
install ZMQ: brew install zeromq
```

## Building Bitcoin Core

1. Clone code
```bash
git clone https://github.com/bitcoin/bitcoin.git
```

2. Configure Bitcoin Core: We will be configuring our Bitcoin Core to support Wallet (BDB + SQlite) without a GUI
```bash
cd bitcoin
./autogen.sh
./configure --with-gui=no
```

**Please note that:** if you did not install berkeley-db@4 stated above, kindly install before running the above command to avoid errors.

3. Compile Bitcoin Core

```bash
- make
- make check (to run tests)
```

## Setting up Bitcoin Core to use Regtest
If you are setting up Bitcoin core primarily for development, there is no need to connect to `mainnet` and download the entire block. Therefore, we will be configuring ours to use `regtest`.

Run the below commands to create Bitcoin directory, its configuration file `bitcoin.conf` and grant appropriate permissions.

```bash
mkdir -p "/Users/${USER}/Library/Application Support/Bitcoin"

touch "/Users/${USER}/Library/Application Support/Bitcoin/bitcoin.conf"

chmod 600 "/Users/${USER}/Library/Application Support/Bitcoin/bitcoin.conf"
```

open the Bitcoin configuration file in your editor and add the following:

```bash
# Daemon Options
server=1
daemon=1
fallbackfee=0.00072
txconfirmtarget=6
# Network Options
regtest=1
#signet=1
#testnet=1
[regtest]
# RPC Options
rpcport=18443
rpcuser=bitcoin
rpcpassword=bitcoin
# ZMQ Options
zmqpubrawblock=tcp://127.0.0.1:28332
zmqpubrawtx=tcp://127.0.0.1:28333
zmqpubhashtx=tcp://127.0.0.1:28332
zmqpubhashblock=tcp://127.0.0.1:28332
```

save and close the above configuration. With the above in place, you can now run your bitcoin core with:

```bash
bitcoind


# add path to your zsh
export PATH="/Users/${USER}/Developer/demo-btc/bitcoin/src:$PATH"
```

## Setup Lightning network
```bash
# install go
brew install go

# clone lnd repo
git clone https://github.com/lightningnetwork/lnd

cd lnd

make install

# To check that lnd was installed properly run the following command:
make check
```

Similar to our bitcoin core installation, we want to configure `lnd` to use `regtest` and connect to our Bitcoin core, so we'll create it's config file in the following directory with the below configuration:

```bash
mkdir -p "/Users/${USER}/Library/Application Support/Lnd"

touch "/Users/${USER}/Library/Application Support/Lnd/lnd.conf"

chmod 600 "/Users/${USER}/Library/Application Support/Lnd/lnd.conf"
```

Paste the following configuration details in the configuration file:

```conf
[Application Options]
debuglevel=trace
maxpendingchannels=10

[Bitcoin]
bitcoin.active=1
bitcoin.node=bitcoind
bitcoin.regtest=1    
```