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
  --data '{"url": "https://azure.github.io/AppService/feed"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure DevOps Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/devops/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "ASP.NET Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/aspnet/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo ".NET Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/dotnet/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Visual Studio Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/visualstudio/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds

echo "Xamarin Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/xamarin/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo ".NET Parallel Programming"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/pfxteam/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Cosmos DB Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/cosmosdb/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds

echo "Azure Depth Platform"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/azure-depth-platform/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Government"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/azuregov/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Notification Hubs Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/azure-notification-hubs/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure SDK Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/azure-sdk/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure SQL Devs’ Corner"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/azure-sdk/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds

echo "CSE Developer Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/azure-sdk/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Creating Startups"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/startups/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Developer Support"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/premier-developer/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds

echo "DirectX Developer Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/directx/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "IoT Developer"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/iotdev/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Java at Microsoft"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/java/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "OData"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/odata/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s 
echo "Performance and Diagnostics"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/performance-diagnostics/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "PowerShell Community"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/powershell-community/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "PowerShell Team"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/powershell/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "Python Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/python/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s 
echo "Q# Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/qsharp/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "Nuget Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/nuget/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "TypeScript Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/typescript/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "VisualStudio Code Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://code.visualstudio.com/feed.xml"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "Dapr Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://blog.dapr.io/posts/index.xml"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "Azure Developer Community Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureDevCommunityBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s  
echo "Apps on Azure"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AppsonAzureBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure AI"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureAIBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Compute"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureCompute&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Architecture Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureArchitectureBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Arc"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureArcBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Data Explorer"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureDataExplorer&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Data Factory"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-852554264193760653&board=AzureDataFactoryBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Data Share"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-659002378713078946&board=AzureDataShareBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Governance and Management"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=4157988311045063925&board=AzureGovernanceandManagementBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Marketplace"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=&board=AzureMarketplaceBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Media Services"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=4861946474885115078&board=AzureMediaServices&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Migration"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=8865915069847348681&board=AzureMigrationBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Monitor"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=5399069573497033421&board=AzureMonitorBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Monitor Status"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=8184494518967089178&board=AzureMonitorStatusBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure portal"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=7991816878640763757&board=AzureportalBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Stack Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=&board=AzureStackBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Storage"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-8704946699801150280&board=AzureStorageBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Synapse Analytics"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-3388905850971134053&board=AzureSynapseAnalyticsBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Tools"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=&board=AzureToolsBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Integrations on Azure"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-8440483452201197351&board=IntegrationsonAzureBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Messaging on Azure"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-4562103637541532328&board=MessagingonAzureBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Networking"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-6032814344635500684&board=AzureNetworkingBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure PaaS blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-2256888536654891855&board=AzurePaaSBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Purview"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-3917634899566880856&board=AzurePurviewBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure DevOps"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-683723822881867304&board=AzureDevOps&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Infrastructure"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://techcommunity.microsoft.com/plugins/custom/microsoft/o365/custom-blog-rss?tid=-3259880474597413614&board=AzureInfrastructureBlog&label=&messages=&size=10"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure updates"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://azure.microsoft.com/en-us/updates/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "OpenShift blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://www.openshift.com/blog/rss.xml"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Spring Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://spring.io/blog.atom"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Microsoft Power Platform Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://cloudblogs.microsoft.com/powerplatform/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Microsoft Quantum"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://cloudblogs.microsoft.com/quantum/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "SQL Server Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://cloudblogs.microsoft.com/sqlserver/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Azure Friday"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://s.ch9.ms/Shows/Azure-Friday/feed"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "DevOps Lab"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://s.ch9.ms/Shows/DevOps-Lab/feed"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "On .NET"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://s.ch9.ms/Shows/On-NET/feed"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "AI Show"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://s.ch9.ms/Shows/AI-Show/feed"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Microsoft Research"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://www.microsoft.com/en-us/research/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Microsoft on Issues"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://blogs.microsoft.com/on-the-issues/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Microsoft 365"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://www.microsoft.com/en-us/microsoft-365/blog/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Linkedin Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://blog.linkedin.com/topics.rss.html"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "Developer Support"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://devblogs.microsoft.com/premier-developer/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds
sleep 0.2s
echo "The GitHub Blog"
curl --header "Content-Type: application/json" \
  --request POST \
  --data '{"url": "https://github.blog/feed/"}' \
  http://HD:40002/v1.0/invoke/api/method/api/feeds