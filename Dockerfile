﻿# 使用官方的 .NET ASP.NET Core 運行時映像作為基礎映像
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

# 複製已編譯的 .NET 程式到容器中
COPY ./bin/Release/net8.0/publish .

# 設置入口點
ENTRYPOINT ["dotnet", "CustomerApi.dll"]

