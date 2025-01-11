Feature: Sqrt
	As Alice (the customer)
	I want to know a number's square root


Scenario Outline: Checking the square root of several numbers
	When root of number <number> is calculated
	Then its square root is <result>
	Examples: 
	| number | result  |
	| 0      | 0       |
	| 2      | 1.41    |
	| 3      | 1.73    |
	| 5      | 2.24    |
	| 7      | 2.65    |
	| 9      | 3       |
	| 11     | 3.32    |
	| 997    | 31.58   |
	| 98689  | 314.15  |
	| 86743  | 294.52  |
