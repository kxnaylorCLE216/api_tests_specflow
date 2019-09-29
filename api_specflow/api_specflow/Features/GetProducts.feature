Feature: GetProducts
	Test GET product operation with Restsharp.net

Scenario: Verify author of the product 1
	Given I perform GET operation for 'products/{productid}'
	And I perform operation for product 1
	Then I should see the 'name' as 'Dyson Ball Animal Upright Vacuum'