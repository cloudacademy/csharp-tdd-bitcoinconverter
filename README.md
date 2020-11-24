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

Update the ```BitcoinConverter.Client.csproj``` project file to reference the ```BitcoinConverter.Code.dll``` library:

```
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>netcoreapp3.1</TargetFramework>
    <RuntimeIdentifiers>osx.10.14-x64;ubuntu.18.04-x64</RuntimeIdentifiers>
  </PropertyGroup>

  <ItemGroup>
    <PackageReference Include="NewtonSoft.Json" Version="12.0.3" />
    <PackageReference Include="System.Text.Json" Version="4.7.2" />
    <Reference Include="BitcoinConverter.Code.dll">
      <HintPath>libraries\BitcoinConverter.Code.dll</HintPath>
    </Reference>
  </ItemGroup>

</Project>
```

Commands to compile and test the Dotnet Solution

```
dotnet build
```

```
DOTNET_USE_POLLING_FILE_WATCHER=1 dotnet watch -p BitcoinConverter.sln test
```