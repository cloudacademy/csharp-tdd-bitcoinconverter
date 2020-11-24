# C# TDD Bitcoin Converter

## Background
The following repo contains source code developed using TDD (Test Driven Development) practices. The sample project implements a .Net Core 3.1 C# library which interacts with the [Bitcoin Price Index](https://www.coindesk.com/coindesk-api) api.

## Notes

This branch (step5) refactors the unit tests and codebase to add addtional unit tests to test error conditions

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