# Automation-Code-Challenge

Automation Code Challenge

Information
The website http://booking.com have extended their search filters with some new options.
The new options are:
•	Spa and wellness centre
•	Star rating

Challenge
Write a set of Selenium tests for these new filters options, including framework to support these tests.

Sample Data
Some test data that can be used for these tests include:

Location: Limerick
Dates: One night stay (3 months from today’s date)
Number of People: 2 adults
Room: 1 Room

Results expected:
Select Filter	Hotel Name	Is Listed
Sauna	Limerick Strand Hotel	True
Sauna	George Limerick Hotel	False
5 Star	The Savoy Hotel			True
5 Star	George Limerick Hotel	False

Assume that hotels would be expected in the top results (paging does not need to be considered)
Feel free to include extra test scenarios that you would think of for this type of feature.

Make sure Project contains this kind of Nugets:
-MSTest.TestAdapter,
-MSTest,TestFramework
-Nunit
-Nunit.Engine
-Nunit3TestAdapter
-NUnitTestAdapter
-Selenium.Support
-Selenium.Webdriver.ChromeDriver

Make sure, that Processor Architeure is set to x64.
Test->Test Settings->Processor Architecture->x64,
Right CLick on Project name -> Settings -> Compilation -> Target Platform -> x64

