# URL Shortener

## Description
Used to create short URLs.

## Dependencies
[.NET](https://dotnet.microsoft.com/en-us/download)

## Running the Project
```console
dotnet run --project URLShortener
```
from the root directory.
Open a browser to the URL `http://localhost:5126/swagger`.

## Running the Tests
```console
dotnet test
```
from the root directory.

## Considerations
### Database
A database could be implemented with either a relational or document database.
In order to prevent duplicate keys, and/or errors, the database implementation will need to keep concurrency in mind.

### Scalability
This implementation should scale easily by either scaling the application or database up or out.
However, caching might be considered as a first step.  A cache could help prevent a lot of read calls to the database.

### Url Collision
There is potential for collision of URL hashes.  This can be mitigated by increasing the hash length.
