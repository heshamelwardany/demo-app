FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Demo.ApiGateWay/Demo.ApiGateWay.csproj", "Demo.ApiGateWay/"]
RUN dotnet restore "Demo.ApiGateWay/Demo.ApiGateWay.csproj"
COPY . .
WORKDIR "/src/Demo.ApiGateWay"
RUN dotnet build "Demo.ApiGateWay.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.ApiGateWay.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.ApiGateWay.dll"]