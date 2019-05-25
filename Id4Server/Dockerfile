FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Id4Server/Id4Server.csproj", "Id4Server/"]
RUN dotnet restore "Id4Server/Id4Server.csproj"
COPY . .
WORKDIR "/src/Id4Server"
RUN dotnet build "Id4Server.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Id4Server.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Id4Server.dll"]