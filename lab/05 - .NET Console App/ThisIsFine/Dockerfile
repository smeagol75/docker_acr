FROM mcr.microsoft.com/dotnet/sdk:9.0

WORKDIR /application

COPY . .

RUN dotnet restore

RUN dotnet publish -c Release -o output

WORKDIR /application/output

ENTRYPOINT ["dotnet", "ThisIsFine.dll"]