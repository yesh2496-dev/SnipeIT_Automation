Snipe-IT Playwright (.NET) – E2E Assignment

This repository contains a minimal Playwright automation project (C# + xUnit) for the Snipe-IT Demo
.
The workflow it covers:

Login to the demo environment

Create a MacBook Pro 13 asset (via generic Select2 dropdown helpers)

Confirm that the asset appears in the asset list

Open the asset details page and validate both status and history

Prerequisites

Make sure you have the following before running the tests:

.NET 8 SDK
 (check with dotnet --info)

Playwright CLI for .NET

dotnet tool install --global Microsoft.Playwright.CLI

How to run

# 1. install browsers (only needed once)
playwright install

# 2. execute tests
dotnet test -v n


Update appsettings.json to change login credentials or toggle headless mode.

Logs are written to the console (you can extend to file logging if needed).

Project Structure

SnipeIT.Playwright/
└─ SnipeIT.Playwright.Tests/
   ├─ Pages/               # Page Objects (POM)
   ├─ Tests/               # xUnit tests
   ├─ Utils/               # Config, Playwright fixture, Selectors.cs
   ├─ appsettings.json     # creds + test settings
   ├─ GlobalUsings.cs
   └─ SnipeIT.Playwright.Tests.csproj


