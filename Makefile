VERSION ?= 0.0.0-dev
PROJECT=OpenIDClient
.PHONY: test build

build:
	dotnet build -c Release $(PROJECT).sln

test:
	dotnet test -c Release $(PROJECT).UnitTests/$(PROJECT).UnitTests.csproj

pack:
	cd build; chmod +x pack.sh; ./pack.sh $(VERSION)

