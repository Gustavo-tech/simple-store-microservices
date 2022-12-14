#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Services/Cart/Cart.API/Cart.API.csproj", "Services/Cart/Cart.API/"]
COPY ["Services/Cart/Cart.Application/Cart.Application.csproj", "Services/Cart/Cart.Application/"]
COPY ["Services/Cart/Cart.Domain/Cart.Domain.csproj", "Services/Cart/Cart.Domain/"]
COPY ["Services/Cart/Cart.Infrastructure/Cart.Infrastructure.csproj", "Services/Cart/Cart.Infrastructure/"]
RUN dotnet restore "Services/Cart/Cart.API/Cart.API.csproj"
COPY . .
WORKDIR "/src/Services/Cart/Cart.API"
RUN dotnet build "Cart.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Cart.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cart.API.dll"]