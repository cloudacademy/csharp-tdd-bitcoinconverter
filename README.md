# C# TDD Bitcoin Converter

[![Build Status](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/workflows/bitcoinconverter.build/badge.svg)](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/actions) [![Coverage Status](https://coveralls.io/repos/github/cloudacademy/csharp-tdd-bitcoinconverter/badge.svg?branch=master)](https://coveralls.io/github/cloudacademy/csharp-tdd-bitcoinconverter?branch=master)

## Background
The following repo contains .Net Core 3.1 C# source code developed using TDD (Test Driven Development) practices. The example codebase demonstrates the use of the following tools related to performing TDD:

* xUnit - a unit testing framework, used to implement unit tests
* Moq - a mocking library, used to create mocks for external dependencies
* GitHub Actions - used to provide CICD features for automated building and testing
* https://coveralls.io/ - used to provide unit test code coverage reports

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

* [step8](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step7) - creates a client console project to test the GitHub Action built DLL artifact - additonally adds badges to the README.md to render the current build status

* [step9](https://github.com/cloudacademy/csharp-tdd-bitcoinconverter/tree/step9) - updates the existing GitHub Action to generate a unit test code coverage report and have it automatically uploaded into https://coveralls.io/ for viewing

## Vagrant
The following ```Vagrantfile``` can be used to spin up an Ubuntu 18.04 instance - which can then be used to install the .Net Core 3.1 SDK:

```
Vagrant.configure("2") do |config|
  config.vm.box = "ubuntu/bionic64"
  config.vm.provision "shell", inline: <<-SHELL
    apt-get update
  SHELL
end
```

With this ```Vagrantfile``` in place, run the following Vagrant command to launch the instance:

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