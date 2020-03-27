$PSScriptRoot = Split-Path -Parent -Path $MyInvocation.MyCommand.Definition

$version = Read-Host "Enter a version number: "
Set-Location "$PSScriptRoot\TomLonghurst.Selenium.Extensions"
dotnet pack -p:PackageVersion=$version --configuration Release
Pause