- [Setup Bitcoin Core and Lightning Network Node Developer Environment](./bitcoin-env-setup.md)
- [Bitcoin Lightning networks for local app development & testing](https://github.com/jamaljsr/polar)
- [Bitcoin Regtest Client](https://github.com/bitcoinjs/regtest-client)


1. Run your own bitcoin node
    - You can connect to your node via RPC to get info about your wallet, but this requires that you add the address(es) to your node's wallet (you can do so as "watch-only" as well, without uploading the private key to the node, only the address)
    - You can run software on top on your node that indexes all addresses for you (so you can ask that software "what is the balance / utxos of this address?" for any address that exists.

2. Use an external API (You are trusting these site maintainer to not lie to you, be careful)
    - One example: Blockstream . info
    - Another: mempool . space


```bash
bitcoin-cli -regtest -getinfo

# Scan for unspent tx output set match certain output descriptor
bitcoin-cli -regtest scantxoutset start

# Scan for unspent tx output set match certain output descriptor
# This wallet reside on computer
bitcoin-cli -regtest createwallet <wallet-name>

bitcoin-cli -regtest -rpcwallet=okok -generate 2
bitcoin-cli -regtest -rpcwallet=okok getwalletinfo
bitcoin-cli -regtest -rpcwallet=okok getblockcount
```