#All Identified Microsoft Blogs & some extras

#echo ""
#curl --header "Content-Type: application/json" \
#  --request POST \
#  --data '{"url": ""}' \
#  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "App Service Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://azure.github.io/AppService/feed", "display":"App Service Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Microsoft Azure Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://azure.microsoft.com/en-us/blog/feed", "display":"Microsoft Azure Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure DevOps Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/devops/feed", "display":"Azure DevOps Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "ASP.NET Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/aspnet/feed", "display":"ASP.NET Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo ".NET Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/dotnet/feed", "display":".NET Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Visual Studio Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/visualstudio/feed", "display":"Visual Studio Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds

echo "Xamarin Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/xamarin/feed", "display":"Xamarin Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo ".NET Parallel Programming"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/pfxteam/feed", "display":".NET Parallel Programming"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Cosmos DB Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/cosmosdb/feed", "display":"Azure Cosmos DB Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds

echo "Azure Depth Platform"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/azure-depth-platform/feed", "display":"Azure Depth Platform"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Government"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/azuregov/feed", "display":"Azure Government"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Notification Hubs Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/azure-notification-hubs/feed", "display":"Azure Notification Hubs Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure SDK Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/azure-sdk/feed", "display":"Azure SDK Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure SQL Devs’ Corner"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/azure-sdk/feed", "display":"Azure SQL Devs’ Corner"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds

echo "CSE Developer Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/azure-sdk/feed", "display":"CSE Developer Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Creating Startups"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/startups/feed", "display":"Creating Startups"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Developer Support"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/premier-developer/feed", "display":"Developer Support"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds

echo "DirectX Developer Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/directx/feed", "display":"DirectX Developer Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "IoT Developer"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/iotdev/feed", "display":"IoT Developer"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Java at Microsoft"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/java/feed", "display":"Java at Microsoft"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "OData"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/odata/feed", "display":"OData"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s 
echo "Performance and Diagnostics"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/performance-diagnostics/feed", "display":"Performance and Diagnostics"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "PowerShell Community"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/powershell-community/feed", "display":"PowerShell Community"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "PowerShell Team"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/powershell/feed", "display":"PowerShell Team"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "Python Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/python/feed", "display":"Python Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s 
echo "Q# Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/qsharp/feed", "display":"Q# Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "Nuget Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/nuget/feed", "display":"Nuget Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "TypeScript Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/typescript/feed", "display":"TypeScript Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "VisualStudio Code Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://code.visualstudio.com/feed.xml", "display":"VisualStudio Code Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "Dapr Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://blog.dapr.io/posts/index.xml", "display":"Dapr Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "Azure Developer Community Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureDevCommunityBlog&label=&messages=&size=10", "display":"Azure Developer Community Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "Apps on Azure"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AppsonAzureBlog&label=&messages=&size=10", "display":"Apps on Azure"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure AI"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureAIBlog&label=&messages=&size=10", "display":"Azure AI"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Compute"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureCompute&label=&messages=&size=10", "display": "Azure Compute"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Architecture Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureArchitectureBlog&label=&messages=&size=10", "display":"Azure Architecture Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Arc"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureArcBlog&label=&messages=&size=10", "display":"Azure Arc"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Data Explorer"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureDataExplorer&label=&messages=&size=10", "display":"Azure Data Explorer"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Data Factory"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureDataFactoryBlog&label=&messages=&size=10", "display":"Azure Data Factory"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Data Share"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-659002378713078946&board=AzureDataShareBlog&label=&messages=&size=10", "display":"Azure Data Share"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Governance and Management"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=4157988311045063925&board=AzureGovernanceandManagementBlog&label=&messages=&size=10", "display":"Azure Governance and Management"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Marketplace"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=&board=AzureMarketplaceBlog&label=&messages=&size=10", "display":"Azure Marketplace"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Media Services"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=4861946474885115078&board=AzureMediaServices&label=&messages=&size=10", "display":"Azure Media Services"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Migration"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=8865915069847348681&board=AzureMigrationBlog&label=&messages=&size=10", "display":"Azure Migration"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Monitor"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=5399069573497033421&board=AzureMonitorBlog&label=&messages=&size=10", "display":"Azure Monitor"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Monitor Status"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=8184494518967089178&board=AzureMonitorStatusBlog&label=&messages=&size=10", "display":"Azure Monitor Status"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure portal"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=7991816878640763757&board=AzureportalBlog&label=&messages=&size=10", "display":"Azure portal"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Stack Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=&board=AzureStackBlog&label=&messages=&size=10", "display":"Azure Stack Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Storage"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-8704946699801150280&board=AzureStorageBlog&label=&messages=&size=10", "display": "Azure Storage"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Synapse Analytics"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-3388905850971134053&board=AzureSynapseAnalyticsBlog&label=&messages=&size=10", "display":"Azure Synapse Analytics"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Tools"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=&board=AzureToolsBlog&label=&messages=&size=10", "display":"Azure Tools"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Integrations on Azure"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-8440483452201197351&board=IntegrationsonAzureBlog&label=&messages=&size=10", "display":"Integrations on Azure"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Messaging on Azure"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-4562103637541532328&board=MessagingonAzureBlog&label=&messages=&size=10", "display":"Messaging on Azure"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Networking"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-6032814344635500684&board=AzureNetworkingBlog&label=&messages=&size=10", "display":"Azure Networking"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure PaaS blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-2256888536654891855&board=AzurePaaSBlog&label=&messages=&size=10", "display":"Azure PaaS blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Purview"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-3917634899566880856&board=AzurePurviewBlog&label=&messages=&size=10", "display":"Azure Purview"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure DevOps"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-683723822881867304&board=AzureDevOps&label=&messages=&size=10", "display":"Azure DevOps"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Infrastructure"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-3259880474597413614&board=AzureInfrastructureBlog&label=&messages=&size=10", "display":"Azure Infrastructure"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure updates"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://azure.microsoft.com/en-us/updates/feed", "display":"Azure updates"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "OpenShift blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://www.openshift.com/blog/rss.xml", "display":"OpenShift blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Spring Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://spring.io/blog.atom", "display":"Spring Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Microsoft Power Platform Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://cloudblogs.microsoft.com/powerplatform/feed", "display":"Microsoft Power Platform Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Microsoft Quantum"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://cloudblogs.microsoft.com/quantum/feed", "display":"Microsoft Quantum"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "SQL Server Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://cloudblogs.microsoft.com/sqlserver/feed", "display":"SQL Server Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Friday"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://s.ch9.ms/Shows/Azure-Friday/feed", "display":"Azure Friday"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "DevOps Lab"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://s.ch9.ms/Shows/DevOps-Lab/feed", "display":"DevOps Lab"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "On .NET"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://s.ch9.ms/Shows/On-NET/feed", "display":"On .NET"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "AI Show"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://s.ch9.ms/Shows/AI-Show/feed", "display":"AI Show"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Microsoft Research"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://www.microsoft.com/en-us/research/feed", "display":"Microsoft Research"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Microsoft on Issues"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://blogs.microsoft.com/on-the-issues/feed", "display":"Microsoft on Issues"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Microsoft 365"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://www.microsoft.com/en-us/microsoft-365/blog/feed", "display":"Microsoft 365"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Linkedin Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://blog.linkedin.com/topics.rss.html", "display":"Linkedin Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Developer Support"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/premier-developer/feed", "display":"Developer Support"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "The GitHub Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://github.blog/feed", "display":"The GitHub Blog"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds