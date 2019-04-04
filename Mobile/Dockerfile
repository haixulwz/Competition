FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Mobile/Mobile.csproj", "Mobile/"]
RUN dotnet restore "Mobile/Mobile.csproj"
COPY . .
WORKDIR "/src/Mobile"
RUN dotnet build "Mobile.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Mobile.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Mobile.dll"]