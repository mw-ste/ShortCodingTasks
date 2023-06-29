# Reverse Polish Notation

- ~30min including introduction
- implement a class or method that takes a string as input and finds all anagrams in the text

## Requirements

- return a list of all anagrams grouped together
- duplicates of a word don't count as anagram
- different casing means a different word
- additional whitespaces should be ignored
- return the anagrams in the following format: `List<List<string>>`

- **Examples:**
  - return `[[]]` for an emtpy string
  - return `[[]]` for input `one two three`
  - return `[[]]` for input `one one one`

  - return `[[one, neo, eon]]` for input `one neo eon`
  - return `[[one, neo, eon]]` for input ` one  neo   eon `
  - return `[[one, ONE, oNe]]` for input `one ONE oNe`
  
  - return `[[one, neo], [two, wot]]` for input `one two neo wot`
  - return `[[one, NEO, ONE], [two, wot], [three, eerht]]` for input `one two  three NEO eerht   wot what ONE one`
