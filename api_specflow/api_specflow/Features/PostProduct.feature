Feature: PostProduct
	Test POST operation using Restsharp.net library

@smoke
Scenario: Verify Post operation for Product
	Given I Perform POST operation for 'products' with body
	| name								    | cost		|
	| Kraft Easy Mac & Cheese Dinner Cups	|	5.98	|
	Then I should see the 'name' as 'Kraft Easy Mac & Cheese Dinner Cups'
