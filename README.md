# MentalCrash
### (Last Updated; 5 July 2023)
## Changelog:

### V-0.3.1

- Added ErrorHandler.cs to make it eaiser to report errors in MentalCrash
- Fixed Updating variables (a bug with finding the variable in the list)
- Added Error Handling for print statements (there was never one initially for print statements)
- Added variable support Strings, Int, (bools?), and variables
- Fixed If statement with True and False Condition Code
- Updated Functions to accept multiple parameters and updated so everything can be in one argument
	```mc
	! Old code format; f <functionName> [<param1>]|<command> <arguments>
	
	F <functionName> [<param1>, <param2>, ...] (<command> <arg1>,<arg2>)
	```
	\* Note That instead of '|' (ex; "pp "Hello World"|"Bye World"") we need to use ',' due to how arguments get split so :/
	<br><br>
- Added cool ways to edit how the 'i' (input command) with '[]' brackets
	```mc
		i Input command has got some style :D [1] (1)
		!You can change the values above with the table given below this code
	```
	| Type | Result | Style | Result |
	| ---- | ------ | ----- | ------ |
	| 1    |   message    | 1     |   >    |
	| 2    |   message\n  | 2     |   >>>  |
	| x    |   x   | 3     |   :    |
	| x    |   x   | 4     |   :>   |
	| x    |   x   | 5     |  :>>>  |
	| x    |   x   | 6     |   $    |
	| x    |   x   | 7     |   $:   |
	| x    |   x   | 8     |   -    |

	```mc
		i Input command has got some style :D [1] (1)
		!Output:
		Input command has got some style :D>
	```

\* Ints and Strings are not fully implemented around the language, and the generic type still exists, but has been updated in the main parts only

## Found Issues

- If statements dont support multiple arguments and strings with spaces get split into 2

## What is MentalCrash?
MentalCrash is an (Esoteric) Programming language created by me, Mervin14. I made this as a challenge to create a programming language that is intentionally confusing for myself.

## Why "MentalCrash"?

Well, before i even started on the project, i was thinking of different name to give my project, but then i thought of a user who is getting mentally mad while they debug something, and then imagining them getting mad to the point of going insane and needing to crash off (aka, chill), so yeah, "MentalCrash" :)

## Update Timeperiod?

probably 1 once a month, then also may just be a patch or minor version, major versions will take 3-4 months (my guess)

# Other FAQ

## Could you make a program completely in one line?

here is the link for the python random code generator for mental crash, the thing is, this generates code that runs on one line ONLY :O :skull:

[Replit - MentalCrash Random Code Tester - Mervinpais](https://replit.com/@Mervinpais/MentalCrash-Random-Code-Tester?v=1)
