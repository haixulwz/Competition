FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["MongoDb/MongoDb.csproj", "MongoDb/"]
RUN dotnet restore "MongoDb/MongoDb.csproj"
COPY . .
WORKDIR "/src/MongoDb"
RUN dotnet build "MongoDb.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "MongoDb.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "MongoDb.dll"]