# Dictionary Parsing

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