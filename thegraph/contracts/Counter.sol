// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

contract Counter {
    uint256 private count = 0;

    // Define an event
    event CountChanged(uint256 newCount);


    function increment() public {
        count += 1;

         emit CountChanged(count); // Emit the event
    }

    function decrement() public {
        if (count > 0) {
            count -= 1;
            emit CountChanged(count); // Emit the event
        }
    }

    function getCount() public view returns (uint256) {
        return count;
    }
}