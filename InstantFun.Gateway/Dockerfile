FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["InstantFun.Gateway/InstantFun.Gateway.csproj", "InstantFun.Gateway/"]
RUN dotnet restore "InstantFun.Gateway/InstantFun.Gateway.csproj"
COPY . .
WORKDIR "/src/InstantFun.Gateway"
RUN dotnet build "InstantFun.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "InstantFun.Gateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "InstantFun.Gateway.dll"]