# C# TDD Bitcoin Converter

## Background
The following repo contains source code developed using TDD (Test Driven Development) practices. The sample project implements a .Net Core 3.1 C# library which interacts with the [Bitcoin Price Index](https://www.coindesk.com/coindesk-api) api.

## Notes

This branch (step6) adds in a GitHub Action workflow to perform automatic build and tests on push events - produces a DLL artifact:

```
name: bitcoinconverter.build

on: push

jobs:
  build:

    runs-on: ubuntu-latest

    steps:
    - uses: actions/checkout@v2

    - name: Setup .NET Core
      uses: actions/setup-dotnet@v1
      with:
        dotnet-version: 3.1.402

    - name: Install Dependencies
      run: dotnet restore

    - name: Build
      run: dotnet build --configuration Release --no-restore

    - name: Test
      run: dotnet test --no-restore --verbosity normal

    - name: Upload Artifact
      uses: actions/upload-artifact@v1.0.0
      with:
        name: BitcoinConverter.Code.dll
        path: BitcoinConverter.Code/bin/Release/netcoreapp3.1/BitcoinConverter.Code.dll
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