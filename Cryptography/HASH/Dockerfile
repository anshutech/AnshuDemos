 FROM microsoft/dotnet:2.0-sdk AS build
    WORKDIR /app

    # copy csproj and restore as distinct layers

    COPY *.csproj ./HASH/
    # copy everything else and build app
    COPY . ./HASH/
    WORKDIR /app/HASH
    RUN dotnet restore
    RUN dotnet build

    FROM build AS publish
    WORKDIR /app/HASH
    RUN dotnet publish -c Release -o out

    FROM microsoft/dotnet:2.0-runtime AS runtime
    WORKDIR /app
    COPY --from=publish /app/HASH/out ./
    ENTRYPOINT ["dotnet", "HASH.dll"]
