# C# TDD Bitcoin Converter

## Background
The following repo contains source code developed using TDD (Test Driven Development) practices. The sample project implements a .Net Core 3.1 C# library which interacts with the [Bitcoin Price Index](https://www.coindesk.com/coindesk-api) api.

## Notes

This branch (step2) refactors current unit tests and codebase using the ```[Theory]``` attribute - also demonstrates the use of the ```dotnet watch``` command to automatically execute all unit tests whenever the source code is changed

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