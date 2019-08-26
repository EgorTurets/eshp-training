FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["EshpProductAPI.csproj", "EshpProductAPI/"]
COPY ["EshpProductCommon.csproj", "EshpProductCommon/"]
COPY ["EshpCommon.csproj", "EshpCommon/"]
COPY ["EshpProductService.csproj", "EshpProductService/"]
COPY ["EshpProductProvider.csproj", "EshpProductProvider/"]
RUN dotnet restore "EshpProductAPI/EshpProductAPI.csproj"
COPY . .
WORKDIR "/src/EshpProductAPI"
RUN dotnet build "EshpProductAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EshpProductAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EshpProductAPI.dll"]