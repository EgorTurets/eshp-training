FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY EshpUserManager/EshpUserManager.csproj EshpUserManager/
COPY EshpUserCompanyCommon/EshpUserCompanyCommon.csproj EshpUserCompanyCommon/
COPY EshpProductService/EshpProductService.csproj EshpProductService/
COPY EshpProductCommon/EshpProductCommon.csproj EshpProductCommon/
COPY EshpCommon/EshpCommon.csproj EshpCommon/
COPY EshpProductProvider/EshpProductProvider.csproj EshpProductProvider/
COPY UserService/UserService.csproj UserService/
RUN dotnet restore EshpUserManager/EshpUserManager.csproj
COPY . .
WORKDIR /src/EshpUserManager
RUN dotnet build EshpUserManager.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish EshpUserManager.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EshpUserManager.dll"]
