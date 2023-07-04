# Find Anagrams

- ~30min including introduction
- implement a class or method that takes a string as input and finds all anagrams in the text
- an Anagram is a word formed by rearranging the letters of a different word
- example: "listen" and "silent"

## Requirements

- take a string containing words separated by white-spaces
- return a list of all anagrams grouped together
- return the anagrams in the following format: `List<List<string>>`
- casing should be ignored when determining if words are anagrams of each other
- duplicates of a word should be ignored, unless the casing is different
- additional white-spaces should be ignored

**Examples:**

- return `[[]]` for an empty string
- return `[[]]` for input `one two three`
- return `[[]]` for input `one one one`

- return `[[one, neo, eon]]` for input `one neo eon`
- return `[[one, neo, eon]]` for input ` one  neo   eon `
- return `[[one, ONE, oNe]]` for input `one ONE oNe`

- return `[[one, neo], [two, wot]]` for input `one two neo wot`
- return `[[one, NEO, ONE], [two, wot], [three, eerht]]` for input `one two  three NEO eerht   wot what ONE one`
