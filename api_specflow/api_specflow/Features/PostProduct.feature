@smoke
Feature: PostProduct
	Test POST operation using Restsharp.net library

Scenario: Verify Post operation for Product location 1
	Given I Perform POST operation for 'products/{productid}/locations' with body
	| name		| subproduct |
	| Cleveland |	1		 |
	Then I should see the 'name' as 'Cleveland'

Scenario: Verify Post operation for Product location 2
	Given I Perform POST operation for 'products/{productid}/locations' with body
	| name		| subproduct |
	| Sam       |	2		 |
	Then I should see the 'name' as 'Sam'

Scenario: Verify Post operation for Product location 3
	Given I Perform POST operation for 'products/{productid}/locations' with body
	| name		| subproduct |
	| Billy     |	3		 |
	Then I should see the 'name' as 'Billy'

