FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY Product/EshpProductAPI/EshpProductAPI.csproj EshpProductAPI/
COPY Product/EshpProductCommon/EshpProductCommon.csproj EshpProductCommon/
COPY Product/EshpProductService/EshpProductService.csproj EshpProductService/
COPY Product/EshpProductProvider/EshpProductProvider.csproj EshpProductProvider/
COPY Common/EshpCommon/EshpCommon.csproj EshpCommon/
RUN dotnet restore EshpProductAPI/EshpProductAPI.csproj
COPY . .
WORKDIR /src/EshpProductAPI
RUN dotnet build EshpProductAPI.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EshpProductAPI.csproj -c Release -o /app

FROM base AS product
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EshpProductAPI.dll"]

WORKDIR /src
COPY UserCompany/EshpUserManager/EshpUserManager.csproj EshpUserManager/
COPY UserCompany/EshpUserCompanyCommon/EshpUserCompanyCommon.csproj EshpUserCompanyCommon/
COPY UserCompany/UserService/UserService.csproj UserService/
COPY Product/EshpProductService/EshpProductService.csproj EshpProductService/
COPY Product/EshpProductCommon/EshpProductCommon.csproj EshpProductCommon/
COPY Product/EshpProductProvider/EshpProductProvider.csproj EshpProductProvider/
COPY Common/EshpCommon/EshpCommon.csproj EshpCommon/
RUN dotnet restore EshpUserManager/EshpUserManager.csproj
COPY . .
WORKDIR /src/EshpUserManager
RUN dotnet build EshpUserManager.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EshpUserManager.csproj -c Release -o /app

FROM base AS usercompany
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EshpUserManager.dll"]