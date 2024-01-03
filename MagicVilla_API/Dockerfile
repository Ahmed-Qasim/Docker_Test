#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
RUN apt-get update && apt-get install -y openssl
RUN openssl req -x509 -newkey rsa:4096 -keyout /app/certs/key.pem -out /app/certs/cert.pem -days 365 -nodes
# Configure Kestrel to use the certificates
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/app/certs
ENV ASPNETCORE_Kestrel__Certificates__Default__KeyPath=/app/certs/key.pem
ENV ASPNETCORE_Kestrel__Certificates__Default__CertificatePath=/app/certs/cert.pem
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MagicVilla_API/MagicVilla_API.csproj", "MagicVilla_API/"]
RUN dotnet restore "./MagicVilla_API/./MagicVilla_API.csproj"
COPY . .
WORKDIR "/src/MagicVilla_API"
RUN dotnet build "./MagicVilla_API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./MagicVilla_API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagicVilla_API.dll"]