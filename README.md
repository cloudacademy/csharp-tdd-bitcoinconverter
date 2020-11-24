# C# TDD Bitcoin Converter

## Background
The following repo contains source code developed using TDD (Test Driven Development) practices. The sample project implements a .Net Core 3.1 C# library which interacts with the [Bitcoin Price Index](https://www.coindesk.com/coindesk-api) api.

## Notes

This branch (step1) demonstrates using the ```dotnet``` command to setup the project structure and create the first set of unit tests using xUnit and the ```[Fact]``` attribute

Install Dotnet Core 3.1 on Ubuntu Vagrant instance:

```
{
wget https://packages.microsoft.com/config/ubuntu/18.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo apt-get update
sudo apt-get install -y apt-transport-https
sudo apt-get update
sudo apt-get install -y dotnet-sdk-3.1
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