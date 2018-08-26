# Football test API

## Overview
This is a .NET Core project which host both an API and a service (Task runner) to manage a Football database with fake data.
Its used as a sandbox to try out some features of .NET Core.

The structure of the API implementation follows a classic 3-layer architecture (Presentation->Service->Data), while the service runs
on a separate thread in parallel with it.

## API Specification
https://footballpitiapi.azurewebsites.net/swagger/index.html

## Main features

* Developed on C# under ASP.NET Core 2
* API authentication via tokens using Facebook and Google APIs
* File storage management via Azure Blob Storage API
* Entity Framework Core to access an SQL Server database
* Access to a MongoDB NoSQL database for user data and logs
* Real-time web functionality via sockets using SignalR
* Nuget package distribution for crosscutting projects
* Ongoing service running on a parallel thread to perform custom tasks, which can be set via config files
  * Simulation of a set of games running in parallel and sending events from a Hub to connected clients
  * Cleanup of non-referenced files in the database from an Azure Blob Storage container
