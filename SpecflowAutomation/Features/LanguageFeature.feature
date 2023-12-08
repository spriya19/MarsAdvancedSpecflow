Feature: LanguageFeature

User add,Update and Delete Language details.

LanguageDetails
Scenario:01 - Successfully Enter their Language Details. 
 Given     User should be logged in with valid credentials.
	When   Enter user Language using Json File with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\LanguageAddData.json"
	Then   User Should be successfully added the language.

Scenario Outline: 02 - Successfully Enter their Language Details. 
 Given     User should be logged in with valid credentials.
	When   User Updated Language using Json File with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\LanguageUpdateData.json"
	Then   User Should be successfully Updated the language.

Scenario Outline: 03 - Successfully Enter their Language Details. 
 Given     User should be logged in with valid credentials.
	When   User Delete Language using Json File with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\LanguageDeleteData.json"
	Then   User Should be successfully deleted the language.

Scenario Outline: 04 - Successfully Enter their Language Details. 
 Given     User should be logged in with valid credentials.
	When   User add Negative Language using Json File with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\LanguageAddNegativeData.json"
	Then   User Should be successfully got the Error message added negative language.

Scenario Outline: 05 - Successfully Enter their Language Details. 
 Given     User should be logged in with valid credentials.
	When   User update Negative Language using Json File with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\LanguageUpdateNegativeData.json"
	Then   User Should be successfully got the Error message update negative language.


