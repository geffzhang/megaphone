az login

# Verify selected subscription
az account show -o table

# Set correct subscription (if needed)
az account set --subscription <SUBSCRIPTION_ID>

# test deploy Applicaiton Insights
az deployment group create --resource-group 'megaphone2-rg' --template-file "./deploy/arm/templates/application-insights.json" --parameters "./deploy/arm/templates/application-insights.parameters.json" --verbose

# test deplou Azure KeyVault
az deployment group create --resource-group 'megaphone2-rg' --template-file "./deploy/arm/templates/azure-keyvault.json" --parameters "./deploy/arm/templates/azure-keyvault.parameters.json" --verbose

# test deploy Azure Storage
az deployment group create --resource-group 'megaphone2-rg' --template-file "./deploy/arm/templates/azure-storage.json" --parameters "./deploy/arm/templates/azure-storage.parameters.json" --verbose

# test deploy Azure Service Bus Namespace
az deployment group create --resource-group 'megaphone2-rg' --template-file "./deploy/arm/templates/azure-servicebus.json" --parameters "./deploy/arm/templates/azure-servicebus.parameters.json" --verbose

# test deploy Azure API Management
az deployment group create --resource-group 'megaphone2-rg' --template-file "./deploy/arm/templates/api-management.json" --parameters "./deploy/arm/templates/api-management.parameters.json" --verbose

# test deploy Azure API Management API
az deployment group create --resource-group 'megaphone2-rg' --template-file "./deploy/arm/templates/api-management/megaphone-apis/v1/api.json" --parameters "./deploy/arm/templates/api-management/megaphone-apis/v1/api.parameters.json" --verbose

# test deploy Azure API Management API
az deployment group create --resource-group 'megaphone2-rg' --template-file "./deploy/arm/templates/api-management/megaphone-apis/v1-mock/api.json" --parameters "./deploy/arm/templates/api-management/megaphone-apis/v1-mock/api.parameters.json" --verbose

# test deploy Azure API Management Product
az deployment group create --resource-group 'megaphone2-rg' --template-file "./deploy/arm/templates/api-management/megaphone-products/megaphone-api/product.json" --parameters "./deploy/arm/templates/api-management/megaphone-products/megaphone-api/product.parameters.json" --verbose

# test deploy Azure API Management Dev Product
az deployment group create --resource-group 'megaphone2-rg' --template-file "./deploy/arm/templates/api-management/megaphone-products/megaphone-dev-api/product.json" --parameters "./deploy/arm/templates/api-management/megaphone-products/megaphone-dev-api/product.parameters.json" --verbose

# deploy full solution
az deployment sub create --location eastus --template-file "./arm/deploy/azdeploy.json" --parameters "./deploy/arm/azdeploy.parameters.json" --verbose