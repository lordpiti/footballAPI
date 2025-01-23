# Football test API

## Overview
This is a .NET project which host both an API and a service (Task runner) to manage a Football database with fake data.
Its used as a sandbox to try out some features of .NET Core.

The structure of the API implementation follows a classic 3-layer architecture (Presentation->Service->Data), while the service runs
on a separate thread in parallel with it.

All class library projects have been migrated to .NET Standard 2.1. The API itself targets .NET 9

## API Specification
https://footballsandbox.azurewebsites.net/swagger/index.html

## GraphQL sandbox
https://footballsandbox.azurewebsites.net/graphiql

## Main features

* Developed on C# under ASP.NET 9
* API authentication via tokens using Facebook and Google APIs
* File storage management via Azure Blob Storage API
* Entity Framework Core 6 to access an SQL Server database
* Access to a MongoDB NoSQL database for user data and logs
* Real-time web functionality via sockets using SignalR
* GraphQL and OData querying support
* Nuget package distribution for crosscutting projects
* Ongoing service running on a parallel thread to perform custom tasks, which can be set via config files
  * Simulation of a set of games running in parallel and sending events from a Hub to connected clients
  * Cleanup of non-referenced files in the database from an Azure Blob Storage container
