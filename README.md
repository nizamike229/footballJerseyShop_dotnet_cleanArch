# SneakerShop

SneakerShop — это учебный проект интернет-магазина кроссовок, реализованный на .NET 9 с использованием принципов Clean Architecture.

## Стек технологий

- .NET 9 (ASP.NET Core Web API)
- Entity Framework Core (SQLite)
- JWT-аутентификация
- Swagger (OpenAPI)
- Clean Architecture

## Архитектура

Проект разделён на слои:
- **Domain** — бизнес-логика и сущности (Entities, Enums, Repositories)
- **Application** — интерфейсы сервисов и бизнес-кейсы
- **Infrastructure** — реализация репозиториев, сервисов, работа с БД
- **Web** — API-контроллеры, мапперы, middleware

## Запуск проекта

1. Убедитесь, что установлен .NET 9 SDK.
2. Перейдите в папку проекта:
   ```sh
   cd TestCleanArch
   ```
3. Проверьте строку подключения к базе данных в `SneakerShop.Infrastructure/Persistance/SneakerDbContext.cs` (по умолчанию используется SQLite-файл `main.sqlite`).
4. Запустите проект:
   ```sh
   dotnet run --project SneakerShop.Web/SneakerShop.Web.csproj
   ```
5. Откройте Swagger UI по адресу: [https://localhost:7235/swagger](https://localhost:7235/swagger) (или порт из launchSettings.json).

## Основные возможности

- Регистрация и вход пользователей (JWT, хранение токена в cookie)
- CRUD для кроссовок (Sneaker) с разграничением ролей (Admin/User)
- Валидация данных через атрибуты
- Глобальная обработка ошибок через middleware

## Структура решения

- `SneakerShop.Domain` — сущности, интерфейсы репозиториев, перечисления ролей
- `SneakerShop.Application` — интерфейсы сервисов
- `SneakerShop.Infrastructure` — реализация репозиториев, сервисов, контекст EF Core
- `SneakerShop.Web` — контроллеры, мапперы, middleware, модели запросов/ответов

## Зависимости

- Microsoft.EntityFrameworkCore.Sqlite
- Microsoft.AspNetCore.Authentication.JwtBearer
- Swashbuckle.AspNetCore (Swagger)
- BCrypt.Net-Next

## Примечания

- Для разработки используется файл базы данных SQLite (`main.sqlite`).
- Для аутентификации используется JWT, токен хранится в cookie `access_token`.
- Для тестирования API используйте Swagger UI.

---

Если нужно добавить инструкции по миграциям или тестированию — дайте знать!
