# C# TDD Bitcoin Converter

[![Build Status](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/workflows/bitcoinconverter.build/badge.svg)](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/actions) [![Coverage Status](https://coveralls.io/repos/github/cloudacademy/csharp-tdd-bitcoinconverter/badge.svg?branch=main)](https://coveralls.io/github/cloudacademy/csharp-tdd-bitcoinconverter?branch=main)

## Background
The following repo contains source code developed using TDD (Test Driven Development) practices. The sample project implements a .Net Core 3.1 C# library which interacts with the [Bitcoin Price Index](https://www.coindesk.com/coindesk-api) api.

:metal:

## Prerequisites
**.Net Core 3.1** is required for this project. 

The provided C# code and instructions have been tested with the following version:

```
dotnet --version
3.1.403
```

## Tools and Frameworks
The following tools and frameworks have been used to perform the TDD developement:
* [xUnit](https://xunit.net/) - a unit testing framework, used to implement unit tests
* [Moq](https://github.com/Moq/moq4/wiki/Quickstart) - a mocking library, used to create mocks for external dependencies
* [GitHub Actions](https://github.com/features/actions) - used to provide CICD features for automated building and testing
* [Coveralls](https://coveralls.io/) - used to provide unit test code coverage reports

## Repo Branches
Branches are used within this repo to demonstrate the TDD workflow (red, green, refactor), as well as highlighting other project management configuration areas. These branches allow you to quickly jump ahead to the area of interest:

### Branches
* [step1](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step1) - demonstrates using the ```dotnet``` command to setup the project structure and create the first set of unit tests using xUnit and the ```[Fact]``` attribute

* [step2](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step2) - refactors current unit tests and codebase using the ```[Theory]``` attribute - also demonstrates the use of the ```dotnet watch``` command to automatically execute all unit tests whenever the source code is changed

* [step3](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step3) - refactors the unit tests and codebase to use the async/await keywords to manage asynchronous HTTP comms with the Bitcoin API online service

* [step4](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step4) - introduces the Moq library to mock out the external Bitcoin API service dependency

* [step5](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step5) - refactors the unit tests and codebase to add addtional unit tests to test error conditions

* [step6](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step6) - adds in a GitHub Action workflow to perform automatic build and tests on push events - produces a DLL artifact

* [step7](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step7) - updates the GitHub Action workflow to automatically produce a release for the built DLL artifact on tag events only

* [step8](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step8) - creates a client console project to test the GitHub Action built DLL artifact - additonally adds badges to the README.md to render the current build status

* [step9](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step9) - updates the existing GitHub Action to generate a unit test code coverage report and have it automatically uploaded into https://coveralls.io/ for viewing

**Note**: The [main](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/main) branch (this branch) contains the same code and configuration as contained in the [step9](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step9) branch

## Bitcoin Converter Library
This project builds a .Net Core 3.1 library which contains the following 2 public methods:
```csharp
public async Task<double> GetExchangeRate(Currency currency)
```
returns in realtime the current Bitcoin exchange rate for the given currency (USD, GBP, or EUR)

```csharp
public async Task<double> ConvertBitcoins(Currency currency, double coins)
```
returns the dollar value for the given currency (USD, GBP, or EUR), and the number of Bitcoins

To build the Bitcoin Converter Library perform the following commands:

```
dotnet build
```

## Bitcoin Converter Client
This project also contains a sample [client](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/main/BitcoinConverter.Client) console based application - which imports the Bitcoin Converter library. To build and run the client for Linux x64 distros, perform the following commands:

```bash
#build/package executable file
cd BitcoinConverter.Client
dotnet publish --runtime linux-x64 --configuration Release /p:TargetFramework=netcoreapp3.1 /p:PublishSingleFile=true /p:PublishTrimmed=true

#run executable:
./BitcoinConverter.Client
```

## GitHub Action - CICD
This project demonstrates how to use [GitHub Actions](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/blob/main/.github/workflows/dotnet-core.yml) to perform automated builds, testing, packaging, and releases.

### dotnet-core.yml
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

    - name: Generate Test Coverage Report
      run: |
        ls -la
        mkdir -p BitcoinConverter.Tests/TestResults
        cd BitcoinConverter.Tests
        dotnet test /p:CollectCoverage=true /p:CoverletOutput=TestResults/ /p:CoverletOutputFormat=lcov
    - name: Publish Test Coverage Report
      uses: coverallsapp/github-action@v1.1.2
      with:
        github-token: ${{ secrets.GITHUB_TOKEN }}
        path-to-lcov: BitcoinConverter.Tests/TestResults/coverage.info

    - name: Upload Artifact
      uses: actions/upload-artifact@v1.0.0
      with:
        name: BitcoinConverter.Code.dll
        path: BitcoinConverter.Code/bin/Release/netcoreapp3.1/BitcoinConverter.Code.dll

    - name: Make Release
      uses: softprops/action-gh-release@v0.1.5
      if: startsWith(github.ref, 'refs/tags/')
      with:
        files:
          BitcoinConverter.Code/bin/Release/netcoreapp3.1/BitcoinConverter.Code.dll
      env:
        GITHUB_TOKEN: ${{ secrets.GITHUB_TOKEN }}
```

## Coveralls - Code Coverage Report
This project forwards its unit testing code coverage reports to [coveralls.io](https://coveralls.io/github/cloudacademy/csharp-tdd-bitcoinconverter) for report viewing and analysis

## Vagrant
The provided [Vagrantfile](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/blob/main/Vagrantfile) can be used to spin up an Ubuntu 18.04 instance - which can then be used to install the .Net Core 3.1 SDK, allowing you to easily follow along:

```
Vagrant.configure("2") do |config|
  config.vm.box = "ubuntu/bionic64"
  config.vm.provision "shell", inline: <<-SHELL
    apt-get update
  SHELL
end
```

Use the following Vagrant command to launch the instance:

```
vagrant up
```

Then SSH into the instance by running the following command:

```
vagrant ssh
```

The .Net Core 3.1 SDK can then be installed using the following instructions:

```
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y apt-transport-https
sudo apt-get update
sudo apt-get install -y dotnet-sdk-3.1
```

To confirm that the .Net Core 3.1 SDK has been successfully installed, run the following command:

```
dotnet --version
```

Back on your local workstation, you can use Visual Studio Code or any other editor to open and modify the contents of the current folder - with all changes being automatically synced back into the ```/vagrant``` directory within the Vagrant instance.

