# C# TDD Bitcoin Converter

## Background
The following repo contains source code developed using TDD (Test Driven Development) practices. The sample project implements a .Net Core 3.1 C# library which interacts with the [Bitcoin Price Index](https://www.coindesk.com/coindesk-api) api.

## Notes

This branch (step9) updates the existing GitHub Action to generate a unit test code coverage report and have it automatically uploaded into https://coveralls.io/ for viewing

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

Signup for a Coveralls account and permit/link it to your GitHub account

To enable code coverage reports, the following snippet needs to be added into the `<ItemGroup>` within the [BitcoinConverter.Tests.csproj](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/blob/step9/BitcoinConverter.Tests/BitcoinConverter.Tests.csproj) project file

```
<PackageReference Include="coverlet.msbuild" Version="2.9.0">
  <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
  <PrivateAssets>all</PrivateAssets>
</PackageReference>
```
