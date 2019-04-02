FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["WebApplication6/WebApplication6.csproj", "WebApplication6/"]
RUN dotnet restore "WebApplication6/WebApplication6.csproj"
COPY . .
WORKDIR "/src/WebApplication6"
RUN dotnet build "WebApplication6.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApplication6.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApplication6.dll"]