# Short Coding Tasks

- (yes, _interviewee_ is an actual word, I googled it!)
- inform the interviewee **upfront** that he will have to solve a small coding task:
  - let him choose a programming language and IDE
  - kindly ask him to set his PC up for sharing his screen and solving the task

## What to look for

- able to solve the task in time?
- all given edge cases covered by tests?
- TDD or code first?
- structured working or creative chaos?
- structure of resulting code?
  - OOP not really mandatory for these small tasks
  - splitting into submethods where appropriate
  - good names for variables and methods
  - clean code and readability in general
  - take the conventions of the chosen language into account (e.g. snake_case vs. CamelCase)
- let interviewee point out possible improvements afterwards!

## Dictionary Parsing

- ~30min including introduction
- implement a class or method that will take an input string and save the contents as a dictionary
- the input format will be `"a=1;b=2;c=3;..."`
- the resulting dictionary should have these contents: `{'a': '1', 'b':'2', 'c': '3', ...}`
- cases given to the interviewee as "requirements":
  - `"a=1;b=2;c=3"` &rarr; `{'a': '1', 'b':'2', 'c': '3'}`
  - `"a = 1; b = 2"` &rarr; `{'a': '1', 'b':'2'}`
  - `"a=1;a=2"` &rarr; `{'a':'2'}`
  - `"a=1;;b=2"` &rarr; `{'a':'1', 'b':'2'}`
  - `"a="` &rarr; `{'a': ''}`
  - `""` &rarr; `{}`
  - `"a==1"` &rarr; `{'a': '=1'}`
  - `"=2"` &rarr; `Exception`
  - `"a"` &rarr; `Exception`