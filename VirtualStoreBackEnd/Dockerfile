#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VirtualStoreBackEnd/VirtualStoreBackEnd.csproj", "VirtualStoreBackEnd/"]
RUN dotnet restore "VirtualStoreBackEnd/VirtualStoreBackEnd.csproj"
COPY . .
WORKDIR "/src/VirtualStoreBackEnd"
RUN dotnet build "VirtualStoreBackEnd.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VirtualStoreBackEnd.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VirtualStoreBackEnd.dll"]