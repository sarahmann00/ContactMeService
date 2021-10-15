#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ContactMeService/ContactMeService.csproj", "ContactMeService/"]
RUN dotnet restore "ContactMeService/ContactMeService.csproj"
COPY . .
WORKDIR "/src/ContactMeService"
RUN dotnet build "ContactMeService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ContactMeService.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ContactMeService.dll"]