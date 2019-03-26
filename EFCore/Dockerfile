FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["EFCore/EFCore.csproj", "EFCore/"]
RUN dotnet restore "EFCore/EFCore.csproj"
COPY . .
WORKDIR "/src/EFCore"
RUN dotnet build "EFCore.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EFCore.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EFCore.dll"]