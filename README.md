[![Board Status](https://dev.azure.com/albriseb/d7923d92-187f-4389-bb56-de565b94591e/d3784736-da67-4e25-857c-ee31713c0e48/_apis/work/boardbadge/10514869-bce1-4d7e-abe9-9b5d44ff0af0)](https://dev.azure.com/albriseb/d7923d92-187f-4389-bb56-de565b94591e/_boards/board/t/d3784736-da67-4e25-857c-ee31713c0e48/Microsoft.RequirementCategory)
![CodeQL](https://github.com/AlexandreBrisebois/megaphone/workflows/CodeQL/badge.svg)

# Megaphone

> Deployment is being built and is partial at this time.

## Why Megaphone

This is a tool I use to help me keep track of all the updates and announcements.

Azure and the Dev world evolves at a terrying pace! Keeping up with it all takes time and generates unnunnecessary cognitive load... Megaphone is all about streamlining my workflow and drastically reducing the cognitive load required to stay current on this ever chaning world.

## Approach

Megaphone is built as an exploration, to learn various technologies and act as a demoable solution.

- [dapr implementation](https://github.com/AlexandreBrisebois/megaphone/tree/trunk/dapr)
- [serverless implementation](https://github.com/AlexandreBrisebois/megaphone/tree/trunk/serverless)


### ASP .NET Core

- [ASP.NET Web APIs](https://dotnet.microsoft.com/apps/aspnet/apis)
- [Background tasks with hosted services in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services?view=aspnetcore-3.1&tabs=visual-studio)

### Development Environment

- [GitHub Codespaces](https://github.com/features/codespaces)
  - Via Browser
  - Via Visual Studio Code

- Visual Studio Enterprise (local dev)

- Visual Studio code (local dev)
  - [Dapr for Visual Studio Code (Preview)](https://github.com/microsoft/vscode-dapr) ([marketplace](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-dapr))
    - Local configurations [tasks.json](./.vscode/tasks.json), [launch.json](./.vscode/launch.json)
    - Useful Blog: [Debugging Dapr applications with Visual Studio Code](https://blog.ehn.nu/2020/03/debugging-dapr-applications-with-visual-studio-code/)
  - [REST Client for Visual Studio Code](https://github.com/Huachao/vscode-restclient) to make REST calls against Service APIs and Dapr APIs

### GitHub

- Using GitHub Actions to build and publish packages
- Using GitHub Packages
