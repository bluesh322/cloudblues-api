# [Home](..\README.md)

# Compiled C#

* Generates files in /bin/Debug/net{version#}
* ProjectName.exe executes the code
* ProjectName.dll is a dynamic link library, which is used by the .exe file to run the compiled code.
   * We already knew this but maybe look up what exactly the Dynamic Link Library is.

# Variables

int and string as variables. Mainly learning some syntax stuff.

`int a = 6, b = 4, c;`

## Reserved keywords

Can't declare variables of keywords

```
// Bad
int class = 2
```

Can use keywords as variables if you use '@' symbol before keyword but don't. God forbid I ever see this.

```
// Can do but also terrible.
int @class = 2
```

To rename a variable throughout a file use 'ctrl+R'

## Starting nested or different projects within a single Solution.

* To add a new project go to file->Add->New Project...


## Basic Operators

+, -, /, *, 

% modulo, get the remainder of a division.

## Var - implicit type variables

```
var variableName = 10;
// Would be an integer to the compiler. Should use sparingly.
```

## Console Input

```
string input = Console.ReadLine();
```

## Breakpoints - [F9]

Use breakpoints to pause a program in order to "just in time" debug a program by looking at 
values in variables and the current state of the application of a particular runtime.

# [TodoList(Next)](..\TodoList\TodoList.md)
