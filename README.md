# C# TDD Bitcoin Converter

## Background
The following repo contains source code developed using TDD (Test Driven Development) practices. The sample project implements a .Net Core 3.1 C# library which interacts with the [Bitcoin Price Index](https://www.coindesk.com/coindesk-api) api.

## Notes

Bitcoin Price Index API used within the code:

```
https://api.coindesk.com/v1/bpi/currentprice.json
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