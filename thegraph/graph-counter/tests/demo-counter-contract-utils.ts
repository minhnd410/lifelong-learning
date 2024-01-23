import { newMockEvent } from "matchstick-as"
import { ethereum, BigInt } from "@graphprotocol/graph-ts"
import { CountChanged } from "../generated/DemoCounterContract/DemoCounterContract"

export function createCountChangedEvent(newCount: BigInt): CountChanged {
  let countChangedEvent = changetype<CountChanged>(newMockEvent())

  countChangedEvent.parameters = new Array()

  countChangedEvent.parameters.push(
    new ethereum.EventParam(
      "newCount",
      ethereum.Value.fromUnsignedBigInt(newCount)
    )
  )

  return countChangedEvent
}
