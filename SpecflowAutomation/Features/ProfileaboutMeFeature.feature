Feature: ProfileaboutMeFeature

As I Enter the User  details in the Profile about me.

User InformationDetails

Scenario:01 - successfully entered the profile page
   Given    User should be successfully logged with valid credentials.
	When    Enter user FirstName and Lastname using Json File with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\ProfileUserData.json"
	Then   User Should be successfully Enter the name.

Scenario Outline:02 - successfully entered the profile page
   Given    User should be successfully logged with valid credentials.
   When    Enter user availability using Json file with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\ProfileAvailabilityData.json"
   Then    User should be successfully Enter the Availability Type.

Scenario Outline: 03 - successfully entered the profile page
   Given    User should be successfully logged with valid credentials.
   When     Enter User Availability Hours using Json file with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\ProfileHoursData.json"
   Then      User should be successfully Enter the Availability Hours Type.

Scenario Outline: 04 - successfully entered the profile page
   Given    User should be successfully logged with valid credentials.
   When     Enter User Availability EarnTarget using Json file with located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\ProfileEarnData.json"
   Then     User should be successfully Enter the Availability Earn Target Type.



