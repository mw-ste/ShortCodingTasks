# Reverse Polish Notation

- ~30min including introduction
- implement a class or method that takes a string as input, which expresses a calculation in Reverse Polish Notation, and returns the result of the calculation

## How it works

In reverse Polish notation, the operators follow their operands.
For example, to add 3 and 4 together, the expression is `3 4 +` rather than `3 + 4`.
The expression `3 − 4 + 5` in conventional notation is `3 4 − 5 +` in reverse Polish notation:
4 is first subtracted from 3, then 5 is added to it.

*Source:* [Wikipedia](https://en.wikipedia.org/wiki/Reverse_Polish_notation#Explanation), *2023-06-27*

## Requirements

- supported operands should be `+` and `-`
- operands `*` and `/` can be supported if there is enough time
- ignore additional spaces in calculations

- **Examples:**
  - return `5` for input `5`
  - return `7` for input `4 3 +`
  - return `1` for input `4 3 -`
  - return `-1` for input `3 4 -`
  - return `7` for input ` 4   3  + `
  - return `-7` for input `-3 -4 +`
  - return `-10` for input ` 4  3 +    5 + 11  + 33 - `

- **Error cases:**
  - raise `ArgumentExceptions` for invalid calculations
  - for input ` `
  - for input `4 3 x`
  - for input `1 b +`
  - for input `1 + 2`
  - for input `4 3 + 5`
