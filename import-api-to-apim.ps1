# Variables
Set-Variable -Name ResourceGroupName "COVIDScreeningAPI"
Set-Variable -Name ApimInstance "screening-app-apis"
Set-Variable -Name SwaggerFilePath "./src/COVIDScreeningApi/bin/Debug/netcoreapp3.1/swagger.json"
Set-Variable -Name ServiceUrl "https://covid-screening-api.azurewebsites.net"
Set-Variable -Name ApiId "COVIDScreeningApi"
Set-Variable -Name ApiVersion "v1"
Set-Variable -Name AzureSubscriptionId ""

# select the subscription
Set-AzContext -SubscriptionId $AzureSubscriptionId

# import the api
Write-Output "Setting API Management Context"
$ApiMgmtContext = New-AzApiManagementContext -ResourceGroupName $ResourceGroupName -ServiceName $ApimInstance

# remove the old api
Write-Output "Removing the old API"
Remove-AzApiManagementApi -Context $ApiMgmtContext -ApiId $ApiId

# import the new api
Write-Output "Importing Swagger into a new API"
Import-AzApiManagementApi -Context $ApiMgmtContext -ApiId $ApiId -ServiceUrl $ServiceUrl -SpecificationFormat "Swagger" -SpecificationPath $SwaggerFilePath -Path $ApiVersion

# get the api
$api = Get-AzApiManagementApi -Context $ApiMgmtContext -ApiId $ApiId

# disable the subscription requirement
Write-Output "Disabling the subscription header requirement" 
$api.SubscriptionRequired = $false
Set-AzApiManagementApi -InputObject $api