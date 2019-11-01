FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["WebAppIdentity.csproj", "./"]
RUN dotnet restore "./WebAppIdentity.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "WebAppIdentity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebAppIdentity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebAppIdentity.dll"]
