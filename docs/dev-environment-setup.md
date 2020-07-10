# Setup Your Environment (& Codespace)

When using [Visual Studio Codespaces](https://visualstudio.microsoft.com/services/visual-studio-codespaces/) (linux) there are a few things that need to get taken care of to get up and running.

## 1) Setup Up GitHub as a NuGet package source

GitHub Packages [documentation](https://docs.github.com/en/packages).

In order to build these services, you need to [install packages](https://docs.github.com/en/packages/using-github-packages-with-your-projects-ecosystem/configuring-dotnet-cli-for-use-with-github-packages) from this GitHub Repo. 

> See this GitHub documentation on [Creating a personal access token](https://docs.github.com/en/github/authenticating-to-github/creating-a-personal-access-token)

With your GitHub **personal access token**, you need to configure **NuGet.Config**:

``` xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
<packageSources>
    <add key="github" value="https://nuget.pkg.github.com/AlexandreBrisebois/index.json" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" protocolVersion="3" />
</packageSources>
<packageSourceCredentials>
    <github>
    <add key="Username" value="[YOUR USER NAME]" />
        <add key="ClearTextPassword" value="[YOUR PERSONAL TOKEN]" />
    </github>
    </packageSourceCredentials>
</configuration>
```

User-level file, **%appdata%\NuGet\NuGet.Config** on Windows, **~/.nuget/NuGet/NuGet.Config** on Mac/Linux

## 2) Setup Dapr

> See this documentation for details about [setting up your local environment](https://github.com/dapr/docs/blob/master/getting-started/environment-setup.md)

### Install Dapr CLI

Linux

```bash
wget -q https://raw.githubusercontent.com/dapr/cli/master/install/install.sh -O - | /bin/bash
```

Windows

```bash
powershell -Command "iwr -useb https://raw.githubusercontent.com/dapr/cli/master/install/install.ps1 | iex"
```

Install and Initialize Dapr

```bash
dapr init
```

## 3) Setup RabbitMQ

RabbitMQ is used as a Queue Binding between Megaphone.API and Feeds.API

I use the image with the management plugin installed and enabled by default, which is available on the standard management port of 15672, with the default username and password of guest / guest:

```bash
docker run -d --name rabbit-mq rabbitmq:3-management
```

## 4) Recommended Useful Visual Studio Code Extensions

- [Dapr Extension](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-dapr)
- [Yaml Extension](https://marketplace.visualstudio.com/items?itemName=redhat.vscode-yaml)
- [REST API Extension](https://marketplace.visualstudio.com/items?itemName=humao.rest-client)
- [markdownlint](https://marketplace.visualstudio.com/items?itemName=DavidAnson.vscode-markdownlint)

## **optional** 5) Setting up Azure Application Insights

### Deploy Local App Insights Agent

> See [Set up Application Insights for distributed tracing](https://github.com/dapr/docs/blob/master/howto/diagnose-with-tracing/azure-monitor.md)

### Setup Application Insights

1. First, you'll need an Azure account. Please see instructions [here](https://azure.microsoft.com/free/) to apply for a **free** Azure account.
2. Follow instructions [here](https://docs.microsoft.com/en-us/azure/azure-monitor/app/create-new-resource) to create a new Application Insights resource.
3. Get Application insights Intrumentation key from your application insights page
4. On the Application Insights side menu, go to `Configure -> API Access`
5. Click `Create API Key`
6. Select all checkboxes under `Choose what this API key will allow apps to do:`
   - Read telemetry
   - Write annotations
   - Authenticate SDK control channel
7. Generate Key and get API key

### Setup the Local Forwarder

#### Self hosted environment

This is for running the local forwarder on your machine.

1. Run the local fowarder

```bash
docker run -e APPINSIGHTS_INSTRUMENTATIONKEY=<Your Instrumentation Key> -e APPINSIGHTS_LIVEMETRICSSTREAMAUTHENTICATIONAPIKEY=<Your API Key> -d -p 55678:55678 daprio/dapr-localforwarder:latest
```

### Configure ASPNET CORE user secrets for each project

#### Resources/Resource.Actor

```bash
dotnet user-secrets -p "src/Resources/Resource.Actor/Resource.Actor.csproj" init
dotnet user-secrets -p "src/Resources/Resource.Actor/Resource.Actor.csproj" set "APPINSIGHTS_INSTRUMENTATIONKEY" "<Your Instrumentation Key>"
```

#### Feeds/Feeds.API

```bash
dotnet user-secrets -p "src/Feeds/Feeds.API/Feeds.API.csproj" init
dotnet user-secrets -p "src/Feeds/Feeds.API/Feeds.API.csproj" set "APPINSIGHTS_INSTRUMENTATIONKEY" "<Your Instrumentation Key>"
```

#### Crawler/Crawler.API

```bash
dotnet user-secrets -p "src/Crawler/Crawler.API/Crawler.API.csproj" init
dotnet user-secrets -p "src/Crawler/Crawler.API/Crawler.API.csproj" set "APPINSIGHTS_INSTRUMENTATIONKEY" "<Your Instrumentation Key>"
```

#### API/Megaphone.API

```bash
dotnet user-secrets -p "src/API/Megaphone.API/Megaphone.API.csproj" init
dotnet user-secrets -p "src/API/Megaphone.API/Megaphone.API.csproj" set "APPINSIGHTS_INSTRUMENTATIONKEY" "<Your Instrumentation Key>"
```
