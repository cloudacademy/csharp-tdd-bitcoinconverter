# C# TDD Bitcoin Converter

## Background
The following repo contains source code developed using TDD (Test Driven Development) practices. The sample project implements a .Net Core 3.1 C# library which interacts with the [Bitcoin Price Index](https://www.coindesk.com/coindesk-api) api.

## Notes

This branch (step3) refactors the unit tests and codebase to use the async/await keywords to manage asynchronous HTTP comms with the Bitcoin API online service

Bitcoin Price Index API used within the ```BitcoinConverter.Code``` Class Library project:

```
https://api.coindesk.com/v1/bpi/currentprice.json
```

Bitcoin Price Index API returns the following response:

```
curl -s https://api.coindesk.com/v1/bpi/currentprice.json | jq .
```

```
{
    "time": {
        "updated": "Oct 15, 2020 22:55:00 UTC",
        "updatedISO": "2020-10-15T22:55:00+00:00",
        "updateduk": "Oct 15, 2020 at 23:55 BST"
    },
    "disclaimer": "This data was produced from the CoinDesk Bitcoin Price Index (USD)",
    "chartName": "Bitcoin",
    "bpi": {
        "USD": {
        "code": "USD",
        "symbol": "&#36;",
        "rate": "11,486.5341",
        "description": "United States Dollar",
        "rate_float": 11486.5341
        },
        "GBP": {
        "code": "GBP",
        "symbol": "&pound;",
        "rate": "8,900.8693",
        "description": "British Pound Sterling",
        "rate_float": 8900.8693
        },
        "EUR": {
        "code": "EUR",
        "symbol": "&euro;",
        "rate": "9,809.3278",
        "description": "Euro",
        "rate_float": 9809.3278
        }
    }
}
```

Create new Dotnet solution:

```
dotnet new sln -o BitcoinConverter && cd ./BitcoinConverter/
```

Create new xUnit Dotnet Project for unit tests and add it to solution:

```
dotnet new xunit -o BitcoinConverter.Tests --framework netcoreapp3.1
dotnet sln add ./BitcoinConverter.Tests/BitcoinConverter.Tests.csproj
```

Create new Dotnet Class Library which will contain the TDD implementation:

```
dotnet new classlib -o BitcoinConverter.Code --framework netcoreapp3.1
dotnet sln add ./BitcoinConverter.Code/BitcoinConverter.Code.csproj
```

Update the xUnit Dotnet Project - add reference to the `BitcoinConverter.Code` Class Library for unit testing purposes

```
dotnet add BitcoinConverter.Tests/BitcoinConverter.Tests.csproj reference BitcoinConverter.Code/BitcoinConverter.Code.csproj
```

Commands to compile and test the Dotnet Solution

```
dotnet build
```

```
dotnet test
```

```
DOTNET_USE_POLLING_FILE_WATCHER=1 dotnet watch -p BitcoinConverter.sln test
```