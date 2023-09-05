FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/Application/MagniFinance.Api/MagniFinance.Api.csproj", "src/Application/MagniFinance.Api/"]
COPY ["src/Domain/MagniFinance.Domain.Core/MagniFinance.Domain.Core.csproj", "src/Domain/MagniFinance.Domain.Core/"]
COPY ["src/Data/MagniFinance.Data/MagniFinance.Data.csproj", "src/Data/MagniFinance.Data/"]
COPY ["src/Domain/MagniFinance.Domain.Course/MagniFinance.Domain.Course.csproj", "src/Domain/MagniFinance.Domain.Course/"]
COPY ["src/Infrastructure/MagniFinance.Infrastructure/MagniFinance.Infrastructure.csproj", "src/Infrastructure/MagniFinance.Infrastructure/"]
COPY ["src/Domain/MagniFinance.Domain.Grade/MagniFinance.Domain.Grade.csproj", "src/Domain/MagniFinance.Domain.Grade/"]
COPY ["src/Domain/MagniFinance.Domain.Shared/MagniFinance.Domain.Shared.csproj", "src/Domain/MagniFinance.Domain.Shared/"]
COPY ["src/Domain/MagniFinance.Domain.Student/MagniFinance.Domain.Student.csproj", "src/Domain/MagniFinance.Domain.Student/"]
COPY ["src/Domain/MagniFinance.Domain.Teacher/MagniFinance.Domain.Teacher.csproj", "src/Domain/MagniFinance.Domain.Teacher/"]
COPY ["src/Domain/MagniFinance.Domain.Subject/MagniFinance.Domain.Subject.csproj", "src/Domain/MagniFinance.Domain.Subject/"]
RUN dotnet restore "src/Application/MagniFinance.Api/MagniFinance.Api.csproj"
COPY . .
WORKDIR "/src/src/Application/MagniFinance.Api"
RUN dotnet build "MagniFinance.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MagniFinance.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MagniFinance.Api.dll"]
