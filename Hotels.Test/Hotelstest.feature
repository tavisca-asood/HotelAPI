Feature: AddHotel
	In order to simulate hotel management system
	As an api consumer
	I want to be able to add hotel, get hotel details and book hotel

@AddHotel
Scenario Outline: User adds hotel in database by providing a valid input
	Given User provided valid Name '<name>' and City '<city>' for hotel
	And User has added required details for the hotel
	When User calls AddHotel api
	Then Hotel with '<name>' should be present in the response
Examples: 
| name   | city   |
| hotel1 | Delhi  |
| hotel2 | Pune   |
| hotel3 | Mumbai |

@GetHotels
Scenario: User is able to see the list of available hotels
	When User calls GetHotels api
	Then User should see a list of all the hotels available

@GetHotelById
Scenario: User is able to get the hotel by HotelId if the Id is valid
	Given User has provided a valid Id '<id>'
	And User wants to get the details of the hotel with the particular Id
	Then User gets the hotel with the particular Id
