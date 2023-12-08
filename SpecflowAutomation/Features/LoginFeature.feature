Feature: LoginFeature

As I login my Mars-QA application

LoginDetails
Scenario:01 - Successfully Logged in
	Given User is on the login page
	When Enter valid email and valid Password credentials from the Json file located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\LoginData.json"
	Then User should be logged in successfully.

Scenario Outline: 02 - Successfully Logged in
	Given User is on the login page
	When Enter valid email and Invalid Password credentials from the Json file located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\LoginInvalidPassData.json"
	Then User should be successfully got the error message.

Scenario Outline: 03 - Successfully Logged in
	Given User is on the login page
	When Enter Invalid email and valid Password credentials from the Json file located at "C:\ICProject\AdvancedSpecFlow\MarsAdvancedSpecflow\SpecflowAutomation\JsonData\LoginInvalidUserData.json"
	Then User should be successfully saw the error message.


