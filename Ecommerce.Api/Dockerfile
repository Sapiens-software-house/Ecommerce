#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Ecommerce.Api/Ecommerce.Api.csproj", "Ecommerce.Api/"]
COPY ["Ecommerce.Infrastructure/Ecommerce.Infrastructure.csproj", "Ecommerce.Infrastructure/"]
COPY ["Ecommerce.Interface/Ecommerce.Interface.csproj", "Ecommerce.Interface/"]
COPY ["Ecommerce.UI/Shared/Ecommerce.UI.Shared.csproj", "Ecommerce.UI/Shared/"]
COPY ["Ecommerce.Ioc/Ecommerce.Ioc.csproj", "Ecommerce.Ioc/"]
COPY ["Ecommerce.Service/Ecommerce.Service.csproj", "Ecommerce.Service/"]
COPY ["Ecommerce.UnitOfWork/Ecommerce.UnitOfWork.csproj", "Ecommerce.UnitOfWork/"]
RUN dotnet restore "Ecommerce.Api/Ecommerce.Api.csproj"
COPY . .
WORKDIR "/src/Ecommerce.Api"
RUN dotnet build "Ecommerce.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Ecommerce.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Ecommerce.Api.dll"]