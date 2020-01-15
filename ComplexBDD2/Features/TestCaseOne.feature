Feature: TestCaseOne

Background: Steps to be ran before each scenario in 'TestCaseOneFeature'
Description: All these step run BEFORE every scenario in this feature file
	Given I perform this condition
	And I perform this other condition

@test1
Scenario Outline: Scenario One
Description: User Information
	When I add user information to database <Name>, <DateOfBirth>, <Email>, <Department>
	And I retrieve user information
	But I update user information
	Then I validate user information
Examples:
| Name   | DateOfBirth | Email                          | Deparment |
| Tom    | 02/17/1981  | tom@cambridgeassociates.com    | IT        |
| Lauren | 07/21/1973  | lauren@cambridgeassocates.com  | Payroll   |
| Rick   | 12/01/1960  | rick@cambridgeassocates.com    | Finance   |
| Megan  | 10/30/1990  | megan@cambridgeassociates.com  | HR        |
| Monoco | 01/11/1975  | monoco@cambridgeassociates.com | Ethics    |

@test2
Scenario Outline: Scenario Two
Description: User payroll
	Given I add user information to database <Yearly>, <Monthly>, <Bonuses>
	When I retrieve user information
	But I update user information
	Then I validate user information
Examples:
| Yearly | Monthly | Bonuses |
| 50000  | 4000    | 1500    |
| 40000  | 3000    | 1250    |
| 30000  | 2000    | 1000    |
| 20000  | 1000    | 750     |
| 10000  | 500     | 500     |
