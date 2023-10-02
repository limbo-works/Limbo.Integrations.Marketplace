@echo off
dotnet build src/Limbo.Integrations.Marketplace --configuration Release /t:rebuild /t:pack -p:PackageOutputPath=../../releases/nuget