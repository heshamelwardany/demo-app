FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Demo.Identity.Api/Demo.Identity.Api.csproj", "Demo.Identity.Api/"]
RUN dotnet restore "Demo.Identity.Api/Demo.Identity.Api.csproj"
COPY . .
WORKDIR "/src/Demo.Identity.Api"
RUN dotnet build "Demo.Identity.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.Identity.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.Identity.Api.dll"]