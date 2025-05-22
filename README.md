# API-JWT-USERS-PRODUCTS

API RESTful para gestión de usuarios (con autenticación JWT) y productos, desarrollada con .NET 8 y Entity Framework Core.

## 📌 Características Principales
- ✅ Autenticación JWT segura
- ✅ CRUD completo para productos
- ✅ Registro y login de usuarios
- ✅ Autorización basada en roles
- ✅ Validación de datos
- ✅ Configuración CORS
- ✅ Documentación Swagger/OpenAPI

## 🚀 Requisitos Previos
- .NET 8 SDK
- SQL Server o Docker para SQL Server
- Git
## 🛠️ Configuración Inicial
Clonar el repositorio:

```bash
git clone https://github.com/JeanDev-10/API-JWT-Users-Products-NET.git
cd API-JWT-Users-Products-NET
```
Configurar la base de datos:

Ejecutar el script SQL query.sql ubicado en la raíz del proyecto para crear la estructura inicial

O usar migraciones de EF Core:

```bash
dotnet ef database update 
```
Configurar conexión a BD:
Editar appsettings.json:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=JwtProductsDB;User Id=sa;Password=TuContraseña;TrustServerCertificate=True;"
}
```
## 🔥 Ejecutar la Aplicación
Instalar dependencias:

```bash
dotnet restore 
```
Ejecutar:

```bash
dotnet run
```
Acceder a la documentación:
Abrir en navegador: http://localhost:5081/swagger


## 🔐 Endpoints Principales
![Endpoints](/images/api-endpoints.jpeg)
### Autenticación
- `POST /api/auth/register` - Registro de usuario
- `POST /api/auth/login` - Login (obtener JWT)
### Productos (requiere autenticación)
- `GET /api/products` - Listar todos
- `GET /api/products/{id}` - Obtener por ID
- `POST /api/products` - Crear nuevo
- `PUT /api/products/{id}` - Actualizar
- `DELETE /api/products/{id}` - Eliminar

## Autor
- [Jean Pierre Rodríguez Zambrano](https://github.com/JeanDev-10)
---

## Licencia

[MIT](https://choosealicense.com/licenses/mit/)
