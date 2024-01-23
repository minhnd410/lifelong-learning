import { HardhatUserConfig } from "hardhat/config";
import "@nomicfoundation/hardhat-toolbox-viem";

const privateKey1 = "0x8436a641d3225e7ee5bb10188e795e4bf6b71bcfecc9fb51d2ca171b281fbebd"

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

export default config;
