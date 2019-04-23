FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["AuthenTest/AuthenTest.csproj", "AuthenTest/"]
RUN dotnet restore "AuthenTest/AuthenTest.csproj"
COPY . .
WORKDIR "/src/AuthenTest"
RUN dotnet build "AuthenTest.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AuthenTest.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AuthenTest.dll"]