#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["../Edu2Gether.Presentation/Edu2Gether.Presentation.csproj", "../Edu2Gether.Presentation/"]
RUN dotnet restore "../Edu2Gether.Presentation/Edu2Gether.Presentation.csproj"
COPY . .
WORKDIR "/src/../Edu2Gether.Presentation"
RUN dotnet build "Edu2Gether.Presentation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Edu2Gether.Presentation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Edu2Gether.Presentation.dll"]