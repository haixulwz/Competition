FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Webapi1/Webapi1.csproj", "Webapi1/"]
RUN dotnet restore "Webapi1/Webapi1.csproj"
COPY . .
WORKDIR "/src/Webapi1"
RUN dotnet build "Webapi1.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Webapi1.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Webapi1.dll"]