FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["WebApi2/WebApi2.csproj", "WebApi2/"]
RUN dotnet restore "WebApi2/WebApi2.csproj"
COPY . .
WORKDIR "/src/WebApi2"
RUN dotnet build "WebApi2.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApi2.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApi2.dll"]