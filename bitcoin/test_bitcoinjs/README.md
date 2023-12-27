```bash
# add wallet without private key
bitcoin-cli createwallet "wallet-without-privkey" true

# checksum descriptor
bitcoin-cli getdescriptorinfo "addr(bcrt1q4dck54ksfskl566ck8puhvqkuujj7djjjrldmd)"

# add the checksum in the end of desc field
bitcoin-cli -rpcwallet="wallet-without-privkey" importdescriptors '[{ "desc": "addr(bcrt1q4dck54ksfskl566ck8puhvqkuujj7djjjrldmd)#jfa3fzny", "watchonly":true, "timestamp": "now"}]'

# get address info
bitcoin-cli -rpcwallet="wallet-without-privkey" getaddressinfo bcrt1q4dck54ksfskl566ck8puhvqkuujj7djjjrldmd

# get receive balance by address
bitcoin-cli -rpcwallet="wallet-without-privkey" getreceivedbyaddress bcrt1q4dck54ksfskl566ck8puhvqkuujj7djjjrldmd 6
bitcoin-cli -rpcwallet="wallet-without-privkey" getbalances
```