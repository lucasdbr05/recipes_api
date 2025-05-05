FROM mcr.microsoft.com/dotnet/sdk:8.0 AS builder
WORKDIR /src
COPY . .
RUN dotnet restore RecipesAPI.csproj
RUN dotnet publish RecipesAPI.csproj -c Release -o app


FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runner
WORKDIR /app
COPY --from=builder /src/app .
EXPOSE 8080

ENTRYPOINT ["dotnet", "RecipesAPI.dll"] 