import {
  assert,
  describe,
  test,
  clearStore,
  beforeAll,
  afterAll
} from "matchstick-as/assembly/index"
import { BigInt } from "@graphprotocol/graph-ts"
import { CountChanged } from "../generated/schema"
import { CountChanged as CountChangedEvent } from "../generated/DemoCounterContract/DemoCounterContract"
import { handleCountChanged } from "../src/demo-counter-contract"
import { createCountChangedEvent } from "./demo-counter-contract-utils"

// Tests structure (matchstick-as >=0.5.0)
// https://thegraph.com/docs/en/developer/matchstick/#tests-structure-0-5-0

describe("Describe entity assertions", () => {
  beforeAll(() => {
    let newCount = BigInt.fromI32(234)
    let newCountChangedEvent = createCountChangedEvent(newCount)
    handleCountChanged(newCountChangedEvent)
  })

  afterAll(() => {
    clearStore()
  })

  // For more test scenarios, see:
  // https://thegraph.com/docs/en/developer/matchstick/#write-a-unit-test

  test("CountChanged created and stored", () => {
    assert.entityCount("CountChanged", 1)

    // 0xa16081f360e3847006db660bae1c6d1b2e17ec2a is the default address used in newMockEvent() function
    assert.fieldEquals(
      "CountChanged",
      "0xa16081f360e3847006db660bae1c6d1b2e17ec2a-1",
      "newCount",
      "234"
    )

    // More assert options:
    // https://thegraph.com/docs/en/developer/matchstick/#asserts
  })
})
