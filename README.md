
# improving-jaya-test

This app was created as a test to listen to Github events via webhooks.

Stored events will eventually be consumed via an API.

## Requirements

	.NetCore 3.1.426
	Access to the internet

## Installation
	Download the Repo
	For the Database, I used PostgreSQL as a Service.
		
## Running the app
	Go the Repo Folder: improving-jaya-test
	Execute:
	
		*dotnet build
		dotnet run --project ./src/Jaya.API*

## Browse de application
	I used Swagger to simplify the execution and visualization of endpoint results
	To Open, access the URL below:
	
	*[http://localhost:5000/swagger/index.html](http://localhost:5000/swagger/index.html)*

## Running the Tests
	Go the Repo Folder: improving-jaya-test
	Execute:
	
	*dotnet test ./JayaTest/.*

## Expose the webhook

	I used ngrok with the port 5000.
	The command line to run ngrok:
	
	*ngrok http 5000*
	
	After running, remember to update the webhook so that github 	can send the information to your computer
