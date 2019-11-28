FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["Demo.Applicants.Api/Demo.Applicants.Api.csproj", "Demo.Applicants.Api/"]
RUN dotnet restore "Demo.Applicants.Api/Demo.Applicants.Api.csproj"
COPY . .
WORKDIR "/src/Demo.Applicants.Api"
RUN dotnet build "Demo.Applicants.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo.Applicants.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo.Applicants.Api.dll"]