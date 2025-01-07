Feature: Sqrt
	As Alice (the customer)
	I want to know the square root of a number

Scenario Outline: Getting the square root of a number
	Given a number <number>
	When I calculate the square root
	Then the result should be <result>
	Examples: 
	| number | result |
	| 4      | 2      |
	| 9      | 3      |
	| 5      | 2.24   |
	| -4     | NaN    |
	| 16     | 4      |
