# ИС аптеки (`PharmacyApp`) - З.З. Идрисов КИ24-21Б

Информационная система для дистанционной торговли лекарственными средствами и управления работой аптеки.

## Стек технологий
- **Язык и платформа:** C#, .NET 8.0 (`net8.0-windows`), Windows Forms
- **Доступ к данным:** Entity Framework Core, `Npgsql.EntityFrameworkCore.PostgreSQL`
- **СУБД:** PostgreSQL
- **Модульное тестирование:** xUnit, Moq

## Предварительные требования
Для сборки и запуска проекта на локальной машине необходимо установить:
1. **.NET 8.0 SDK**
2. **PostgreSQL Server** и **pgAdmin 4**
3. **Visual Studio 2022** или **Visual Studio Code**
4. **Git**

---

## Сборка и развертывание

### 1. Клонирование репозитория
```bash
git clone https://github.com/ZIdrisov/PharmacyApp.git
cd PharmacyApp
```

### 2. Настройка и подготовка базы данных PostgreSQL
1. Откройте **pgAdmin 4** и создайте новую базу данных с именем `PharmacyDB`.
2. Откройте файл `appsettings.json` в папке проекта и укажите параметры подключения к серверу PostgreSQL: хост, порт, имя базы данных (`PharmacyDB`), имя пользователя (по умолчанию `postgres`) и пароль.
3. Создайте таблицы и заполните начальные данные одним из способов:
   - **Через миграции Entity Framework Core** (после установки `dotnet-ef` на следующем шаге):
     ```bash
     dotnet ef database update
     ```

   - **Вручную через SQL-скрипт** в pgAdmin 4 (создает таблицы `employees`, `products`, `orders`, `orderitems` и заполняет стартовые записи):

```sql
-- 1. Таблица сотрудников (employees)
CREATE TABLE employees (
    id SERIAL PRIMARY KEY,
    login VARCHAR(50) UNIQUE NOT NULL,
    password VARCHAR(255) NOT NULL,
    role INTEGER NOT NULL DEFAULT 1
);

-- 2. Таблица товаров (products)
CREATE TABLE products (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    price NUMERIC(10,2) NOT NULL CHECK (price > 0)
);

-- 3. Таблица заказов (orders)
CREATE TABLE orders (
    id SERIAL PRIMARY KEY,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    status INTEGER DEFAULT 0
);

-- 4. Таблица позиций заказа (orderitems)
CREATE TABLE orderitems (
    id SERIAL PRIMARY KEY,
    order_id INTEGER NOT NULL REFERENCES orders(id) ON DELETE CASCADE,
    product_id INTEGER NOT NULL REFERENCES products(id) ON DELETE RESTRICT,
    product_name VARCHAR(255) NOT NULL,
    price NUMERIC(10,2) NOT NULL,
    quantity INTEGER NOT NULL CHECK (quantity > 0)
);

-- 5. Начальное заполнение таблиц
INSERT INTO employees (login, password, role) VALUES
    ('admin', 'admin123', 0), -- Администратор
    ('pharm1', 'pharm123', 1); -- Фармацевт

INSERT INTO products (name, price) VALUES
    ('Аспирин 500мг №20', 150.00),
    ('Парацетамол таб. 500мг №10', 85.50),
    ('Но-шпа 40мг №24', 220.00),
    ('Лоперамид капс. 2мг №10', 45.00);
```
### 3. Восстановление зависимостей и установка инструментов

Перейдите в папку проекта PharmacyWinForms, восстановите NuGet-пакеты и установите глобальные инструменты EF Core:
``` bash
cd PharmacyWinForms
dotnet restore
dotnet tool install --global dotnet-ef
```
### 4. Применение миграций и запуск приложения

Примените миграции (если таблицы еще не созданы вручную) и запустите Windows Forms-приложение:
```bash
dotnet ef database update
dotnet run
```
