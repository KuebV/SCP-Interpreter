# SCP-Interpreter
Interpreter for the Anomaly ARG by and for Peanut's Laboratory
 
## About
SCP-Interpreter is the interpreter for SCP-2521 which does not understand symbols

This program allows you to translate English into Symbols

You **cannot** translate Symbols back into English, you must do this by hand

There will be a reference for the Symbols in this README

## Custom Scripting
SCP-Interpreter uses its own custom File Type for scripting. Known as TFTO. This is bare bones scripting and very easy to use

### TFTO Examples
**Storing Variables** - For whatever reason, you need to store a variable, this is avaliable to you. This may become helpful in the future
```
var a Hello
var b World
var c 50
var d 10
var e "You can even do whole strings"

print a
print b
print e
```

**Input** - If for whatever reason, you want to input your own variables, this is possible
```
input a "Please enter your name"
print a
```

**Translation** - Most likely the only reason you are going to use this program, is for the translations
```
translate scpString "Hello what is your name?"
print scpString
```
