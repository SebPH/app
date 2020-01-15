Feature: TestCaseTwo

Background: Steps to be ran before each scenario in 'TestCaseTwoFeature'
Description: All these step run BEFORE every scenario in this feature file
	Given I perform this condition
	And I perform this other condition

@test1
Scenario Outline: Scenario One
	When I add user information to database <Name>, <DateOfBirth>, <Email>, <Department>
	And I add an extra user
	| Key         | Value                           |
	| Name        | Charlie                         |
	| DateOfBirth | 09/03/1961                      |
	| Email       | charlie@cambridgeassociates.com |
	| Department  | Business                        |
	And I access database
	And I retrieve user information
	But I update user information
	Then I validate user information
Examples:
| Name     | DateOfBirth | Email                            | Deparment |
| Logan    | 02/17/1984  | Logan@cambridgeassociates.com    | Ethics    |
| Miguel   | 07/21/1977  | miguel@cambridgeassocates.com    | HR        |
| Sean     | 12/01/1965  | sean@cambridgeassocates.com      | Finance   |
| Savannah | 10/30/1993  | savannah@cambridgeassociates.com | Payroll   |
| Orgel    | 01/11/1979  | orgel@cambridgeassociates.com    | IT        |

@test2
Scenario Outline: Scenario Two
Description: User payroll
	Given I add user information to database
	And I add an extra payroll
	| Key     | Value  |
	| Yearly  | 120000 |
	| Monthly | 10000  |
	| Bonuses | 1750   |
	And I access database
	When I retrieve user information
	But I update user information
	Then I validate user information
Examples:
| Yearly | Monthly | Bonuses |
| 200000 | 18000   | 5000    |
| 190000 | 17000   | 4500    |
| 180000 | 16000   | 4000    |
| 170000 | 15000   | 3500    |
| 160000 | 14000   | 3000    |