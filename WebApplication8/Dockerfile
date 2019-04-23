FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["WebApplication8/WebApplication8.csproj", "WebApplication8/"]
RUN dotnet restore "WebApplication8/WebApplication8.csproj"
COPY . .
WORKDIR "/src/WebApplication8"
RUN dotnet build "WebApplication8.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApplication8.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApplication8.dll"]