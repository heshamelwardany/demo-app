FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build

# Install Nodejs
RUN apt-get install --yes curl
RUN curl --silent --location https://deb.nodesource.com/setup_10.x | bash -
RUN apt-get install --yes nodejs

WORKDIR /src
COPY ["Demo.WebSpa/Demo.WebSpa.csproj", "Demo.WebSpa/"]
RUN dotnet restore "Demo.WebSpa/Demo.WebSpa.csproj"

# Restore NPM dependencies
COPY ["Demo.WebSpa/ClientApp/package.json", "src/ClientApp/"]
COPY ["Demo.WebSpa/ClientApp/package-lock.json", "src/ClientApp/"]
WORKDIR /src/src/ClientApp
RUN npm install

WORKDIR /src
COPY . .
WORKDIR "/src/Demo.WebSpa"
RUN dotnet build "Demo.WebSpa.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.WebSpa.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.WebSpa.dll"]