# Dictionary Parsing

- ~30min including introduction
- implement a class or method that will take an input string and save the contents as a dictionary
- the input format will be `"a=1;b=2;c=3;..."`
- the resulting dictionary should have these contents: `{'a': '1', 'b':'2', 'c': '3', ...}`
- cases given to the interviewee as "requirements"

## Requirements

  1. `"a=1;b=2;c=3"` &rarr; `{'a': '1', 'b':'2', 'c': '3'}`
  1. `"a = 1; b = 2"` &rarr; `{'a': '1', 'b':'2'}`
  1. `"a=1;a=2"` &rarr; `{'a':'2'}`
  1. `"a=1;;b=2"` &rarr; `{'a':'1', 'b':'2'}`
  1. `"a="` &rarr; `{'a': ''}`
  1. `""` &rarr; `{}`
  1. `"a==1"` &rarr; `{'a': '=1'}`
  1. `"=2"` &rarr; `Exception`
  1. `"a"` &rarr; `Exception`
  1. `" a = 1 ; ; c =  ; ; b = = 2 "` &rarr; `{'a': '1', 'b':'= 2', 'c': ''}`