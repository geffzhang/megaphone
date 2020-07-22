az login

# Verify selected subscription
az account show -o table

# Set correct subscription (if needed)
az account set --subscription <SUBSCRIPTION_ID>

# test deploy Applicaiton Insights
az deployment group create --resource-group 'megaphone-rg' --template-file "./deploy/templates/application-insights.json" --parameters "./deploy/templates/application-insights.parameters.json" --verbose

# test deplou Azure KeyVault
az deployment group create --resource-group 'megaphone-rg' --template-file "./deploy/templates/azure-keyvault.json" --parameters "./deploy/templates/azure-keyvault.parameters.json" --verbose

# test deploy Azure Storage
az deployment group create --resource-group 'megaphone-rg' --template-file "./deploy/templates/azure-storage.json" --parameters "./deploy/templates/azure-storage.parameters.json" --verbose

# test deploy Azure Service Bus Namespace
az deployment group create --resource-group 'megaphone-rg' --template-file "./deploy/templates/azure-servicebus.json" --parameters "./deploy/templates/azure-servicebus.parameters.json" --verbose

# test deploy Azure API Management
az deployment group create --resource-group 'megaphone-rg' --template-file "./deploy/templates/api-management.json" --parameters "./deploy/templates/api-management.json" --verbose



# deploy full solution
az deployment sub create --location eastus --template-file "./deploy/azdeploy.json" --parameters "./deploy/azdeploy.parameters.json" --confirm-with-what-if --verbose