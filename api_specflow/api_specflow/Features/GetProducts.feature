Feature: GetProducts
	Test GET product operation with Restsharp.net

Background: 
	Given I get JWT authentication of User with following details
	| Email              | Password |
	| naylorkx@gmail.com | kxn      |

Scenario: Verify author of the product 1
	Given I perform GET operation for 'products/{productid}'
	And I perform operation for product 1
	Then I should see the 'name' as 'Dyson Ball Animal Upright Vacuum'

Scenario: Verify author of the product 2
	Given I perform GET operation for 'products/{productid}'
	And I perform operation for product 2
	Then I should see the 'name' as 'Moto Z3 Play with Alexa Hands-Free'

Scenario: Verify author of the product 3
	Given I perform GET operation for 'products/{productid}'
	And I perform operation for product 3
	Then I should see the 'name' as 'Thin Air Book'

Scenario: Verify author of the product 4
	Given I perform GET operation for 'products/{productid}'
	And I perform operation for product 4
	Then I should see the 'name' as 'Starbucks Doubleshot'

Scenario: Verify author of the product 5
	Given I perform GET operation for 'products/{productid}'
	And I perform operation for product 5
	Then I should see the 'name' as 'Echo Wall Clock'


