# COVID Screening API Sample

During Microsoft Build 2020's session [Azure: Invent with Purpose](https://mybuild.microsoft.com/sessions/80ec2639-35c3-462b-8155-1ef52c29310c?source=sessions), [Jeff Hollan](https://twitter.com/jeffhollan) showed an application built using Microsoft's Cloud, Developer Tools, and Power Platform used by airport screeners in the fight against the COVID-19 pandemic. This repository contains the .NET API source code from that demo and scripts you can run to set it up in your own Azure environment.

## Getting Started

To start, you'll need a Microsoft Azure subscription. If you don't yet have an Azure subscription you can [sign up for free](https://azure.microsoft.com/en-us/free/) in minutes.

Once you're armed with an Azure subscription, you can click the button below to open the screening app's API in [Visual Studio Codespaces](https://visualstudio.microsoft.com/services/visual-studio-codespaces/), and your web-based development environment will be configured in seconds.

[![Open in Visual Studio Codespaces](https://img.shields.io/endpoint?style=social&url=https%3A%2F%2Faka.ms%2Fvso-badge)](https://online.visualstudio.com/environments/new?name=COVIDScreeningApi&repo=bradygaster/COVIDScreeningApi)

If you'd prefer to work locally on your development machine, clone this repository to your local machine and use [Visual Studio](https://.visualstudio.com) or [Visual Studio Code](https://code.visualstudio.com). If you choose to run the code locally, you'll need to install these fine products:

* [Azure Command CLI](https://docs.microsoft.com/en-us/cli/azure/install-azure-cli?view=azure-cli-latest)
* [Docker Desktop](https://www.docker.com/get-started)
* If you're on Windows you'll need to enable WSL or have a bash terminal available as there will be bash terminal commands to execute

## Environment Creation

The Azure CLI will be used to create the app's resources, so you will first need to log into your Azure environment using this Azure CLI command:

```bash
az login
```

Included in this repository is script named `create-resources.azcli` that you can use to create all the Azure resources the API will need to function. These resources are created when run the script:

* A single Azure resource group that contains all of the resources
* An [Azure Container Registry]() resource to house the app's Docker container
* An [Azure App Service](https://azure.microsoft.com/en-us/services/app-service/) [Plan](https://docs.microsoft.com/en-us/azure/app-service/overview-hosting-plans), in Linux mode
* An [Azure App Service](https://docs.microsoft.com/en-us/azure/app-service/containers/app-service-linux-intro) on Containers
* An [Azure API Management](https://docs.microsoft.com/en-us/azure/api-management/import-and-publish) instance in Consumption mode
* An [Azure Cosmos DB](https://docs.microsoft.com/en-us/azure/cosmos-db/introduction) database

The script will not only create all of the resources, but it will also build, package, and deploy the application code.

### Running the Setup Script

Before executing the script, note each of the variable values at the top of the `create-resources.azcli`:

```bash
# the name of the resource group
resourceGroup="covid-screening-app-resources"
# the name of the api management resource
apimName="screening-apis"
# the name of the cosmos db resource
cosmosDbName="screeningcosmosdb"
# the name of the app service plan for the app service
appServicePlanName="covidscreeningappapi-west-plan"
# the name of the app service that'll host the code
appServiceName="covidscreeningappapi-west"
# the acr resource name  
acrName="covidscreeningregistry"
# the region in which we want things to be created
region="westus"
# the owner name of the API management instance
publisherName="CovidApManagement"
# the owner email of the API management instance
publisherEmail="CovidApManagement@demo.com"
```

Edit the script to represent your own environment or naming preferences. Try to pick something you're sure is unique for each of the resource names. Sample values are shown below:

```bash
# the name of the resource group
resourceGroup="covid-screening-app-resources"
# the name of the api management resource
apimName="screening-apis-confdemo"
# the name of the cosmos db resource
cosmosDbName="screeningcosmosdbconfdemo"
# the name of the app service plan for the app service
appServicePlanName="covidscreeningappapi-west-plan"
# the name of the app service that'll host the code
appServiceName="confdemo-screeningapi-west"
# the acr resource name  
acrName="confdemoscreeningacr"
# the region in which we want things to be created
region="westus"
# the owner name of the API management instance
publisherName="DemoScreeningApp"
# the owner email of the API management instance
publisherEmail="my-real-email@outlook.com"
```

Once you've edited the variables and logged into your Azure CLI, run the script using the command `bash create-resources.azcli` or simply, `create-resources.azcli` if you're in a bash terminal. The script will take some time to run but will provide relatively verbose logging and details as it proceeds.

### Generating sample data

This repository also contains a unit test project that contains a single Xunit test that will generate sample data using [Bogus](https://github.com/bchavez/Bogus), the fantastic fake data generator useful for unit testing with .NET. By executing a single Xunit test using the `dotnet test` CLI command you will generate sample data in the Cosmos DB database used to store your entities.

When the `.azcli` setup script completes, you will see the connection string to the Cosmos DB in the terminal window (or in your log). If you don't see this you can either use the Azure portal to get the connection string to it, or the [Azure Databases](https://marketplace.visualstudio.com/items?itemName=ms-azuretools.vscode-cosmosdb) extension for Visual Studio Code.

Once you've copied the connection string, paste it into the `tests\COVIDScreeningApi.Tests\appsettings.json` file as indicated in the file:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "SwaggerBaseUrl": "https://localhost:5001",
  "ConnectionStrings": {
    "CosmosDbConnectionString" : "<ConnectionStringHere>"
  }
}
```

Then run the unit test using the command:

```bash
dotnet test
```

You will see the Xunit test execute and then see the sample data in your Cosmos DB database.

## Contributing

This project welcomes contributions and suggestions. Most contributions require you to agree to a Contributor License Agreement (CLA) declaring that you have the right to, and actually do, grant us the rights to use your contribution. For details, visit https://cla.microsoft.com.

When you submit a pull request, a CLA-bot will automatically determine whether you need to provide a CLA and decorate the PR appropriately (e.g., label, comment). Simply follow the instructions provided by the bot. You will only need to do this once across all repos using our CLA.

This project has adopted the Microsoft Open Source Code of Conduct. For more information see the Code of Conduct FAQ or contact opencode@microsoft.com with any additional questions or comments.
