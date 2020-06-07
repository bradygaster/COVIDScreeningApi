FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/COVIDScreeningApi/COVIDScreeningApi.csproj", "src/COVIDScreeningApi/"]
RUN dotnet restore "src/COVIDScreeningApi/COVIDScreeningApi.csproj"
COPY . .
WORKDIR "/src/src/COVIDScreeningApi"
RUN dotnet build "COVIDScreeningApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "COVIDScreeningApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "COVIDScreeningApi.dll"]
