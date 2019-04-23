FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["WebApplication7/WebApplication7.csproj", "WebApplication7/"]
RUN dotnet restore "WebApplication7/WebApplication7.csproj"
COPY . .
WORKDIR "/src/WebApplication7"
RUN dotnet build "WebApplication7.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApplication7.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApplication7.dll"]