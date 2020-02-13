Feature: UBS Interview Task
	Task previous to the technical interview with ubs

Scenario: Open UBS Webpage in the preferred language
	Given the user opens the main UBS webpage
	When the user selects his preferred language
	Then the main UBS webpage is opened in the preferred language

Scenario: Mortgage calculation positive
	Given the user opens the main UBS webpage
	When the user navigates to the mortgage calculator screen
	And enters following values
	|Field|Value|
	|Purchase|700000|
	|Income|120000|
	|Equity|170000|
	Then the user can get the credit

Scenario: Mortgage calculation negative because income
	Given the user opens the main UBS webpage
	When the user navigates to the mortgage calculator screen
	And enters following values
	|Field|Value|
	|Purchase|2000000|
	|Income|120000|
	|Equity|600000|
	Then the user cannot get the credit

Scenario: Mortgage calculation negative because equity
	Given the user opens the main UBS webpage
	When the user navigates to the mortgage calculator screen
	And enters following values
	|Field|Value|
	|Purchase|3000000|
	|Income|500000|
	|Equity|400000|
	Then the user cannot get the credit