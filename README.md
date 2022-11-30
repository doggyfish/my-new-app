# my-new-app
## How much time I spent on this exercise
3hours

## What I have added and reasoning
added new react starter project
dotnet new react -o my-new-app

Added react-query and axios to handle the data fetching, might be an over kill for this, 
an simple useEffect hook with empty dependency array should be suffient. 
I didn't add await key word to the api end point, there will be warning message to indicate that.
The react-query and axios libraries will become handy when adding more UI interaction later on, 
and also the async fetch works better with long running processes. 

Added some structures in API with attemps to structure the backend, but after reading through the test requirements,
I felt on the API side it's more about processing rather than setup the backend structure, simply due to time constraint.
I have taken some tests yerterday, which required me to refactor API, structure it properly, feel free to look into it if you wish.
The test: https://github.com/doggyfish/RefactorThisOriginal.git
What I produced: https://github.com/doggyfish/RefactorThis.git

## Further Improvements I Would Make If I Had More Time
1.
fix for 2nd output requirement
removed unused lines in profile.js to tidy it up a little bit, 
import { useNavigate } from "react-router-dom";
import { useState } from "react";
const nav = useNavigate();

I might have over complicated the 2nd output, so I removed the whole section
![image](https://user-images.githubusercontent.com/3989272/204757625-56c3ec3a-39ac-41fc-95e1-8f96616f6eee.png)

and added following two lines to the first table

\<th\>Total Sum of Rend for Tiers 1 2 & 3\</th\>

\<td\>{currencyFormatter.format(h.tierOne.teirPercentageRent + h.tierTwo.teirPercentageRent + h.tierThree.teirPercentageRent)}\</td\>

2. 
adding more controls to the UI, Year One Sales, Base Rent (years 1 to 5), Base Rent (years 6 to 10), Percentage Rent Tier 1,
Percentage Rent Tier 2, Percentage Rent Tier 3 and Compounding annual sales growth rate can all be passed down from UI control,
then mapped to Dtos. 
The calculation code can easily take thoses inputs and calculate the profile.

3.
Tidy up the RentCalculator calss, move things to where they belong, keep them pure.
Tidy up the helper class, some functions can be performed by the classes. that should reduce the code size and improve readability.

## Here's What I Would Like to Talk About At The Interview

