# Etapa 1: Imagem de build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia e restaura dependências
COPY ["SmartCity.API/SmartCity.API.csproj", "SmartCity.API/"]
RUN dotnet restore "SmartCity.API/SmartCity.API.csproj"

# Copia o restante e compila
COPY . .
WORKDIR "/src/SmartCity.API"
RUN dotnet publish "SmartCity.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Etapa 2: Imagem de produção (mais leve)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

# Porta exposta (ajuste se necessário)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080
ENTRYPOINT ["dotnet", "SmartCity.API.dll"]
