FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Competition.Host/Competition.Host.csproj", "Competition.Host/"]
RUN dotnet restore "Competition.Host/Competition.Host.csproj"
COPY . .
WORKDIR "/src/Competition.Host"
RUN dotnet build "Competition.Host.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Competition.Host.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Competition.Host.dll"]