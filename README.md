# Fibonacci.Service
Rest api for returning nth number from Fibonacci sequence

## Running the service

To run the service you will need:

1. Some kind of IDE (Visual studio, Rider, VS code) 
2. .NET 8 SDK https://dotnet.microsoft.com/en-us/download/dotnet/8.0
3. Clone the repo and by opening the solution with ide just press debug/start


## Containerization 

To create a docker container you will need to:

1. Clone the app
2. Build the app's image 

for more detailed guide follow dockers guide on how to do the steps 
https://docs.docker.com/guides/workshop/02_our_app/

## CI/CD

### CI
For CI part I would recommend to use azure.devops, restrict pushes to main and develop branch, create a testing branch for example: develop.
Create policies for making a pull request, so the code added code would not be left unreviewed, 2 approval policy from your colleagues, build and tests should be passing for
for pull request to be completed

### CD
I would recommend having several environments for testing purposes. One for automated tests, the other preprod for manual testing and integration testing for other systems and ofcourse production environment, so the publishing part could go as fluent as possible,
this would reduce the chance of having a bug released to production. Using azure cloud would let us have a full Microsoft stack, so i would suggest having it hosted in it, with configuration files for different environments. Also consider having several machines running different intances of the service,
so that if one goes down the other could accept the requests.

## Monitoring and Logging

### Monitoring

For monitoring purposes i would suggest tracking the number of requests the service gets using somekind of solution like Kibana.
Also track the time that  the service completes the request in, error and warning counts.

### Logging

For logging i would use ElasticSearch just to simplify the searching of a specific log.
It should also reduce the bug fixing time. Use different columns like MachineName, RequestId, CorrelationId, Level, RequestBody to make it easier.

## Scaling

The service should have several instances(nodes) for reduced risk of possible complete down time. I would suggest using load balancer for managing the load and not having a down time just because
the service had too many requests. Improved caching mechanism could be a benefit aswell, using for example - Redis, would be a advantage vs in memory cache.
