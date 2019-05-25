FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["ContosoUniversity/ContosoUniversity.csproj", "ContosoUniversity/"]
RUN dotnet restore "ContosoUniversity/ContosoUniversity.csproj"
COPY . .
WORKDIR "/src/ContosoUniversity"
RUN dotnet build "ContosoUniversity.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ContosoUniversity.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ContosoUniversity.dll"]