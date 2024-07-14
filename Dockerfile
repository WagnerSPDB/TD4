# Estágio 1
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:8000;http://+:80
ENV ASPNETCORE_ENVIRONMENT=Development

# Estágio 2
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia o arquivo .csproj e restaura as dependências
COPY td4/td4.csproj td4/
RUN dotnet restore "td4/td4.csproj"

# Copia o restante do código e constrói a aplicação
COPY . .
WORKDIR /src/td4
RUN dotnet build "td4.csproj" -c Release -o /app/build

# Estágio 3 
FROM build as publish
RUN dotnet publish "td4.csproj" -c Release -o /app/publish

# Estágio 4
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Comando de entrada da aplicação
ENTRYPOINT ["dotnet", "td4.dll"]
