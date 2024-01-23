import { formatEther, parseEther } from "viem";
import hre from "hardhat";

const counterAddress = "0x939341a62f30cc50c108bdd506608e20cdbe6111"

async function main() {
  // const currentTimestampInSeconds = Math.round(Date.now() / 1000);
  // const unlockTime = BigInt(currentTimestampInSeconds + 60);

  // const lockedAmount = parseEther("0.002");

  // const counter = await hre.viem.deployContract("Counter", [], {});

  const counter = await hre.viem.getContractAt("Counter", counterAddress)

  console.log(await counter.read.getCount())
  console.log(await counter.write.increment())
  console.log(await counter.write.increment())
  console.log(await counter.read.getCount())
  
  console.log(
    `Counter at to ${counter.address}`
  );
}

// We recommend this pattern to be able to use async/await everywhere
// and properly handle errors.
main().catch((error) => {
  console.error(error);
  process.exitCode = 1;
});
