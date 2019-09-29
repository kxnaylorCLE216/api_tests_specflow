Feature: PostProduct
	Test POST operation using Restsharp.net library

@smoke
Scenario: Verify Post operation for Product 1
	Given I Perform POST operation for 'products/{productid}/locations' with body
	| name		| subproduct |
	| Cleveland |	1		 |
	Then I should see the 'name' as 'Cleveland'
