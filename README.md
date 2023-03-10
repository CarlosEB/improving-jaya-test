
# improving-jaya-test

This app was created as a test to listen to Github events via webhooks.

Stored events will eventually be consumed via an API.

## Requirements to run locally

	.NetCore 3.1.426
	Access to the internet

### Installation
	Download the Repo
	For the Database, I used PostgreSQL as a Service.
		
### Running the app
	Go to the Repo Folder: improving-jaya-test
	Execute:
		dotnet restore
		dotnet build
		dotnet run --project ./src/Jaya.API

### Browse the application
	I used Swagger to simplify the execution and visualization of the results
	To Open, access the URL below:
	
	http://localhost:5000/swagger/index.html

### Running the Tests
	Go the Repo Folder: improving-jaya-test
	Execute:
	
	dotnet test ./JayaTest/.

## Requirements to run using docker	
	Docker installed

### Running the app
	Go to the Repo Folder: improving-jaya-test
	Execute:
		docker build . -t improving_jaya
		Tests will be run during the image creation process to ensure the container works
	And then:
		docker run -d -p 5000:80 --name jaya improving_jaya
		
### Browse the application
	I used Swagger to simplify the execution and visualization of the results
	To Open, access the URL below:
	
	http://<docker-machine ip>:5000/swagger/index.html	
	Tip: You can run docker-machine ip to see your docker's IP 
	
## Expose the webhook

	I used ngrok with the port 5000.
	The command line to run ngrok:
	
	Running the app locally:
	ngrok http 5000
	
	Running the app using docker:
	ngrok http <docker-machine ip>:5000
	
## Final thoughts
	
	Before running the application, remember to update the webhook so that github can send the information to your computer.
	It's necessary to maintain the route /events in the end of the url.
	e.g.: https://0591-2804-14c-5f87-9d72-2052-13be-8f5c-39be.sa.ngrok.io/events

