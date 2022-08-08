#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Projeto06.Api/Projeto06.Api.csproj", "Projeto06.Api/"]
COPY ["Projeto06.Domain/Projeto06.Domain.csproj", "Projeto06.Domain/"]
RUN dotnet restore "Projeto06.Api/Projeto06.Api.csproj"
COPY . .
WORKDIR "/src/Projeto06.Api"
RUN dotnet build "Projeto06.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Projeto06.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Projeto06.Api.dll"]