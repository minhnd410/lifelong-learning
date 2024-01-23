import { CountChanged as CountChangedEvent } from "../generated/DemoCounterContract/DemoCounterContract"
import { CountChanged } from "../generated/schema"

export function handleCountChanged(event: CountChangedEvent): void {
  let entity = new CountChanged(
    event.transaction.hash.concatI32(event.logIndex.toI32())
  )
  entity.newCount = event.params.newCount

  entity.blockNumber = event.block.number
  entity.blockTimestamp = event.block.timestamp
  entity.transactionHash = event.transaction.hash

  entity.save()
}
