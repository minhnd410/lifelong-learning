## Pre-requisites

- Recommended using nvm
- [Ganache](https://github.com/trufflesuite/ganache) Local blockchain
- [Graph Node](https://github.com/graphprotocol/graph-node)
- [Graph CLI](https://github.com/graphprotocol/graph-tooling/tree/main/packages/cli)
- [Hardhat](https://hardhat.org/hardhat-runner/docs/getting-started#quick-start)

```bash
npm install ganache --global
```

## Prepare demo graph with smart contract at local

1. Create project using hardhat
```bash
npx hardhat init
```

2. In `hardhat.config.ts` add 
```js
const privateKey1 = "..."

const config: HardhatUserConfig = {
  solidity: "0.8.19",
  defaultNetwork: "localhost",
  networks: {
    localhost: {
      url: "http://127.0.0.1:8545",
      accounts: [privateKey1]
    }
  },
};
```

3. Prepare environment
```bash
# Start Ganache
ganache

# Start Graph Node
git clone https://github.com/graphprotocol/graph-node.git
cd graph-node/docker
docker-compose up
```

4. Compile and deploy hardhat project
```bash
npx hardhat compile
npx hardhat run scripts/deploy.ts
```

5. Init graph project
```bash
graph init graph-counter --node http://127.0.0.1:8030
cd graph-counter
# create the subgraph in graph node 
yarn create-local
# deploy the subgraph to graph node 
yarn deploy-local
```

6. Query
```bash
# Query list
{
  countChangeds {
    id
    newCount
    blockNumber
  }
}

# Query by id
{
  countChanged(id: "0x31f8fcc7b4f7e560d0e92385fba8f2519a8e749e12eb8abc589a8f0efa5ee07200000000") {
    id
    newCount
    blockNumber
    blockTimestamp
    transactionHash
  }
}
```