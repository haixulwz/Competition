FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["WebApplication9/WebApplication9.csproj", "WebApplication9/"]
RUN dotnet restore "WebApplication9/WebApplication9.csproj"
COPY . .
WORKDIR "/src/WebApplication9"
RUN dotnet build "WebApplication9.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApplication9.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApplication9.dll"]