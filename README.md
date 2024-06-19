# Car Parking Rate Calculator
The Carpark Rate Calculator is a C# console application that calculates the parking fee for users based on the entry and exit times provided.

There are 4 different rates including Early Bird, Night Rate, Weekend Rate, and Standard Rate. The program selects the applicable rate depending on the entry and exit times.

The program also includes unit tests to ensure all the functions of the app are running accurately

## Prerequisites
- Code editor (Preference: Visual Studio)
- .NET SDK
- NUnit (for running unit tests)

## Running the project

### Using Visual Studio
- Open .sln file in Visual Studio
- Run the project from top menu bar and interact via console
- To run tests, select "Test" menu item from top menu bar and select "Run all Tests"

### Using Console
- Run terminal in project directory /ParkingRateCalculator
- Run `dotnet run`
- Run terminal in project directory /ParkingRateCalculator.nUnitTests
- Run `dotnet test`



## Example Usage
- Input 1: `Enter entry date and time (yyyy-MM-dd HH:mm): 2024-06-14 06:30`
- Input 2: `Enter exit date and time (yyyy-MM-dd HH:mm): 2024-06-14 16:00`
- Response: `Rate Name: Early Bird, Total Price: $13`
