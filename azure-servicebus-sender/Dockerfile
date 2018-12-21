FROM microsoft/dotnet:2.2-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY azure-servicebus-sender/azure-servicebus-sender.csproj azure-servicebus-sender/
RUN dotnet restore azure-servicebus-sender/azure-servicebus-sender.csproj
COPY . .
WORKDIR /src/azure-servicebus-sender
RUN dotnet build azure-servicebus-sender.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish azure-servicebus-sender.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "azure-servicebus-sender.dll"]
