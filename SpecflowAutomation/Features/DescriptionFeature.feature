Feature: DescriptionFeature

User Add and Updated description details.

Description Details
Scenario:01 - Successfully Enter their Description Details.
   Given   User should be successfully logged with valid credential.
	When   Enter user Description using Json File with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\DescriptionData.json"
	Then   User Should be successfully Enter the Description.

Scenario Outline:02 -Successfully Enter their Description Details.
   Given   User should be successfully logged with valid credential.
	When   User Updated Description using Json File with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\DescriptionUpdateData.json"
	Then   User Should be successfully Updated the Description.

Scenario Outline: 03 - Successfully Enter their Description Details.
   Given   User should be successfully logged with valid credential.
	When   User delete Description using Json File with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\DescriptionDeleteData.json"
	Then   User Should be successfully Deleted the Description.

Scenario Outline: 04 -Successfully Enter their Description Details.
   Given   User should be successfully logged with valid credential.
	When   User Enter Negative Description using Json File with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\DescriptionNegativeData.json"
	Then   User Should be successfully Enter the Negative Description.
 

 
