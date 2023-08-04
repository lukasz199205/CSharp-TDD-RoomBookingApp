FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["RoomBookingApp.Api/RoomBookingApp.Api.csproj", "RoomBookingApp.Api/"]
RUN dotnet restore "RoomBookingApp.Api/RoomBookingApp.Api.csproj"
COPY . .
WORKDIR "/src/RoomBookingApp.Api"
RUN dotnet build "RoomBookingApp.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RoomBookingApp.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoomBookingApp.Api.dll"]
