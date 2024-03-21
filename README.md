# Installation

1. Install new NUnit project: `dotnet new nunit -n PlaywrightTestsWithDotNet`
2. Navigate to project folder: `cd PlaywrightTestsWithDotNet`
3. Install Microsoft.Playwright.NUnit: `dotnet add package Microsoft.Playwright.NUnit`
4. Build project to assure every thing is OK: `dotnet build`
5. Install PowerShell
6. Install Playwright browsers (verify which .net version is installed, ex: net8.0): `pwsh bin/Debug/net8.0/playwright.ps1 install`
7. Create a `project.runSettings` file on the root folder
8. In order to execute tests using the RunSettings: `dotnet test --settings:project.runsettings`
