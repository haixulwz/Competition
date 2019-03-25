FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Study1/Study1.csproj", "Study1/"]
RUN dotnet restore "Study1/Study1.csproj"
COPY . .
WORKDIR "/src/Study1"
RUN dotnet build "Study1.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Study1.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Study1.dll"]