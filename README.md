# C# TDD Bitcoin Converter

## Background
The following repo contains source code developed using TDD (Test Driven Development) practices. The sample project implements a .Net Core 3.1 C# library which interacts with the [Bitcoin Price Index](https://www.coindesk.com/coindesk-api) api.

## Notes

This branch (step8) introduces a new client console project ([BitcoinConverter.Client](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step8/BitcoinConverter.Client)) to test the GitHub Action built DLL artifact - and additonally demonstrates how to add badges to the README.md to render the current build status:

The following command can be used to **manually** create a release version of the ```BitcoinConverter.Code``` Class Library - which is used by the ```BitcoinConverter.Client``` console project:

```
dotnet build --configuration Release
```

Create a new Dotnet Console client project:

```
dotnet new console -o BitcoinConverter.Client --framework netcoreapp3.1
```

Commands to compile and test the Dotnet Solution

```
dotnet build
```

```
DOTNET_USE_POLLING_FILE_WATCHER=1 dotnet watch -p BitcoinConverter.sln test
```