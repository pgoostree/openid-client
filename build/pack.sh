#!/bin/bash

set -e

pkg_version=${1:-"0.0.1-local"}

echo
echo "> Packing..."
echo
if [ -d nupkgs/ ]; then
    rm -rf nupkgs/
fi
mkdir nupkgs
echo

for proj in ../OpenIDClient/*.csproj; do
	echo $proj
	dotnet pack --output "$(pwd)/nupkgs" -c Release $proj /property:PackageVersion=$pkg_version
done


echo