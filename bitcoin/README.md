## Bip

- `BIP39` Mnemonic
- `BIP32` Key Derivation & Hierarchical Tree Structure
- `BIP44` for legacy `(P2PKH)` `(m/44/0/0/0/0)`
- `BIP49` for Nested-SegWit `(P2SH-P2WPKH)` `(m/49/0/0/0/0)`
- `BIP84` for Native Segwit `(P2WPKH)` `(m/84'/0'/0'/0)`
- `BIP86` for Taproot `(P2TR)` `(m/86/0/0/0/0)`

## Helpful links

- [Setup Bitcoin Core and Lightning Network Node Developer Environment](./bitcoin-env-setup.md)
- [Bitcoin Lightning networks for local app development & testing](https://github.com/jamaljsr/polar)
- [Bitcoin Regtest Client](https://github.com/bitcoinjs/regtest-client)


## Run your own bitcoin node

- You can connect to your node via RPC to get info about your wallet, but this requires that you add the address(es) to your node's wallet (you can do so as "watch-only" as well, without uploading the private key to the node, only the address)
- You can run software on top on your node that indexes all addresses for you (so you can ask that software "what is the balance / utxos of this address?" for any address that exists.


## Use an external API (You are trusting these site maintainer to not lie to you, be careful)

- One example: Blockstream.info
- Another: mempool.space


## Common commands

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


## How to get default privkey of bitcoin core wallet

[Procedure](requires https://github.com/iancoleman/bip39):

1. List all received by address filter out the empty ones
```bash
bitcoin-cli listreceivedbyaddress 6
```

2. Get address info and take note of the address "parent_desc" and "ischange" values.
```bash
bitcoin-cli getaddressinfo "address_1"
```

3. Get master private key
- list descriptors and find the (private) descriptor with the matching script type of your address' parent descriptor. (your address' should be "wpkh")
- there'll be at least two desc with that script type, based from your address "ischange" value of 'true' or 'false', pick the descriptor with "internal" of the same value.
- From the correct descriptor, copy it's master private key which is the long "xprv" key. Do not include the script type and '(' before and '/' after it.
```bash
bitcoin-cli listdescriptors true
```

4. Derive the address' private key
- Open your iancoleman's BIP39 tool in an offline machine and paste your xprv key in "BIP32 Root Key".
- Scroll down a bit and select the correct script type: `BIP44` for legacy, `BIP49` for Nested-SegWit and `BIP84` for Native Segwit.
- The default should be already correct for receiving addresses (internal: false), else, change the internal/external path from '0' to '1'.
- Scroll-down to the derived addresses and it should be there along with its private key.
- If your address' "address_index" is more than 20, you should derive more addresses in BIP39 tool by using the button: "Show ___ more rows" below the address list for it to show.


## Add wallet without private key

- Create empty wallet 
```bash
bitcoin-cli createwallet "public_wallet" true true
```

- checksum descriptor: get the `checksum` property from the output of the following command
```bash
bitcoin-cli getdescriptorinfo "addr(bcrt1q4dck54ksfskl566ck8puhvqkuujj7djjjrldmd)"
```

- using the `checksum` and add the `#{checksum}` in the end of desc field (in this case jfa3fzny)
```bash
bitcoin-cli -rpcwallet="public_wallet" importdescriptors '[{ "desc": "addr(bcrt1q4dck54ksfskl566ck8puhvqkuujj7djjjrldmd)#jfa3fzny", "watchonly":true, "timestamp": "now"}]'
```

# get address info
```bash
bitcoin-cli -rpcwallet="public_wallet" getaddressinfo bcrt1q4dck54ksfskl566ck8puhvqkuujj7djjjrldmd
```

# get receive balance by address
```bash
bitcoin-cli -rpcwallet="public_wallet" getreceivedbyaddress bcrt1q4dck54ksfskl566ck8puhvqkuujj7djjjrldmd 6

bitcoin-cli -rpcwallet="public_wallet" getbalances
```
