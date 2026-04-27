# Backend - Task Manager API

## 📌 Descripción

API REST desarrollada con ASP.NET Core para la gestión de proyectos y tareas.
Permite crear, consultar, actualizar y eliminar proyectos y tareas, así como filtrar tareas por proyecto y estado.

---

## 🛠 Tecnologías utilizadas

* .NET 7 / .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* SQL Server
* Docker

---

## ⚙️ Requisitos

* .NET SDK (v7 o superior)
* Docker
* SQL Server (se levanta con Docker)

---

## 🚀 Cómo ejecutar el backend

### 1. Levantar SQL Server con Docker

```bash
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=Artemisa2025*" -p 1433:1433 --name sqlserver2022 -d mcr.microsoft.com/mssql/server:2022-latest
```

---

### 2. Ejecutar el backend

```bash
cd TaskAdminApi
dotnet restore
dotnet ef database update
dotnet run
```

---

## 🌐 Endpoints

Base URL:
http://localhost:5147/api

### 🔹 Proyectos

* GET /Projects → Obtener todos los proyectos
* POST /Projects → Crear proyecto
* PUT /Projects/{id} → Actualizar proyecto
* DELETE /Projects/{id} → Eliminar proyecto

### 🔹 Tareas

* GET /Tasks → Obtener tareas (con filtros opcionales)
* POST /Tasks → Crear tarea
* PUT /Tasks/{id} → Actualizar tarea
* DELETE /Tasks/{id} → Eliminar tarea

---

## 🔍 Filtros disponibles

Ejemplo:

```http
GET /Tasks?projectId=1&status=Pendiente
```

Permite:

* Filtrar por proyecto
* Filtrar por estado

---

## 🧠 Decisiones técnicas

* Uso de Entity Framework Core para manejo de base de datos y relaciones
* Uso de migraciones para versionar el esquema
* Arquitectura basada en controladores REST
* Uso de query parameters para filtros dinámicos
* Validaciones básicas en endpoints (HTTP 400, 404, etc.)

---

## 🗄 Base de datos

Ejemplo de tabla de tareas:

```sql
CREATE TABLE Tasks (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Title NVARCHAR(450) NOT NULL,
    Description NVARCHAR(500),
    Status NVARCHAR(35) NOT NULL,
    DueDate DATETIME2 NOT NULL,
    fk_project INT NOT NULL
);
```

Relación:

* Una tarea pertenece a un proyecto (FK)

---

## 📦 Notas

* Se utiliza Docker para facilitar la configuración de SQL Server
* Swagger está habilitado para probar los endpoints

📍 Swagger:
http://localhost:5147/swagger

---
