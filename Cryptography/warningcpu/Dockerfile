    FROM microsoft/dotnet:2.0-sdk AS build
    WORKDIR /app

    # copy csproj and restore as distinct layers

    COPY *.csproj ./warningcpu/
    # copy everything else and build app
    COPY . ./warningcpu/
    WORKDIR /app/warningcpu
    RUN dotnet restore
    RUN dotnet build

    FROM build AS publish
    WORKDIR /app/warningcpu
    RUN dotnet publish -c Release -o out

    FROM microsoft/dotnet:2.0-runtime AS runtime
    WORKDIR /app
    COPY --from=publish /app/warningcpu/out ./
    ENTRYPOINT ["dotnet", "warningcpu.dll"]
