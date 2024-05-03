# Project 1

## Overview (Due: 5/24/24 Friday)

For this individual project, you'll create a console application, where the application will be interacting with users via terminal. The project will conclude with a 5 minute presentation of working software to trainers and colleagues. Your code will be hosted on your personal repository on our class's Github Organization.

## Requirements

- The application should be a C# Console Application
- The application should build and run
- The application should interact with users, and provide some console UI (Print a menu, user selects options etc - Look at Methods Project.)
- The application should allow for multiple users to log in and persist their data (Think about this when planning application - cant do this yet. Include: Log out)
- The application should demonstrate good input validation (Incorrect PW, or incorrect UName/PW combos)
- The application should persist data to a SQL Server DB (This needs to be an app that manages data - bare minimum should include user credentials, but add others)
- The application should communicate to DB via ADO.NET or Entity Framework Core (How app will communicate to databases - Entity Framework is less work than ADO.NET)
- The application should have unit tests (Generic tests - string attempt at created different unit tests)

## Nice to Have

- n-tier architecture (Arch design of back end application - organizing an app/layers)
- dependency injection (how or where some neccesary components are utilized)
- The application should log errors and system events to a file or a DB table ()
- Basic user authentication and authorization (admins vs normal users with passwords)

## For Monday 5/6/24

- Push a folder to your personal GitHub repository on the organization with the console app created (dotnet new console)
- Upload a .txt or .md file to your personal github repo titled "Project1Proposal" or something like that. (You need to keep this project simple, think of types of apps that exist and model that app) (Banking app - login, do any operation(check balance, deposit, withdrawal, close out), as a customer at a bank I can open an account, I can deposit money into an account, etc.. Different users would have different accounts..)(Car Dealership - cars can be bought, users can see what cars exist, puirchase a car, view purchased cars, Admins: see care on lot, which ones have sold, which customer have bought what.)

Inventory management system = items that can be purchased (Car Dealership example above)

Workflow management system (Appt scheduler for a company)

Simple
Menu of things customer can do
they make a selection
they complete that objective
Would you like to do anything else? Y/N
If Yes back to menu etc.

Proposal = Include what the intent of what the application will be, can include some more details like what interactions will be included - objectives.