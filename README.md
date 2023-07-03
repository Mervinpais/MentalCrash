# MentalCrash
### (Last Updated; 3 July 2023)
## Changelog:

### V-0.3

- Comments are added using '!'
	```mc
	! This is a comment
	! There are no multiline comments sadly :(
	```
- Strings now need* '"' (Double Quotes) on both sides
- Ints now need* to be only numbers to work
- If statement syntax update, Before;
	```mc
	I (condition)|(true condition)|(false condition)
	```
	Now;
	```mc
	I [(condition), (true condition), (false condition)]
	```
- Functions have been updated with params too!
	```mc
	f myFunction [<type> <variableName>]|<command to run>
	```
  Only one param can be used in a function but, you can reference the param variable;
	```mc 
	f textFunction [str e]|p e
	```
  You can reference functions both (i) without params and (ii) with params like the following;
- (i)
	```mc
	f myFunc1|p "This was easy to program"
	f myFunc1
    ! Output: This was easy to program
	```
- (ii)
	```mc
	f myFunc2 [str e]|p e
	f myFunc2 [str e]|"This took time to program in properly"
	! Output: This took time to program in properly
	```


\* It is not fully implemented around the language, but in the main parts only

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
