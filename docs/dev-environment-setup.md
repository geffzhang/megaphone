# Setting up your work environment in Visual Studio Codespaces

When using [Visual Studio Codespaces](https://visualstudio.microsoft.com/services/visual-studio-codespaces/) (linux) there are a few things that need to get taken care of to get up and running.

## 1) Setting up GitHub as a NuGet package source

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

User-level file, **%appdata%\NuGet\NuGet.Config** on Windows, **~/.config/NuGet/NuGet.Config** on Mac/Linux

## OPTIONAL 2) Setting up Azure Application Insights

