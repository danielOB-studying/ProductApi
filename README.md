# ProductApi

API web ASP.NET Core (.NET 9) que implementa CRUD completo para la entidad Product usando
EF Core + Npgsql (PostgreSQL).

## 1. Recrear el proyecto desde cero (opcional)

Si quieres regenerar este proyecto tú mismo en lugar de usar los archivos proporcionados:

```bash
dotnet new webapi -n ProductApi --use-controllers -o ProductApi
cd ProductApi
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Swashbuckle.AspNetCore
```

## 2. Configurar la conexión a la base de datos

Edita `appsettings.json` y configura tus credenciales reales de PostgreSQL:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=productdb;Username=postgres;Password=your_password"
}
```

Asegúrate de que la base de datos `productdb` exista (o deja que EF Core la cree mediante las migraciones de abajo).

## 3. Instalar la herramienta de la CLI de EF Core (una vez, si aún no está instalada)

```bash
dotnet tool install --global dotnet-ef
```

## 4. Crear y aplicar la migración

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Esto crea la tabla `Products` en PostgreSQL que coincide con el modelo `Product`.

## 5. Ejecutar la API

```bash
dotnet run
```

Luego abre la interfaz de Swagger en `http://localhost:5080/swagger` (o el puerto HTTPS mostrado en la consola) para probar los endpoints de forma interactiva.

## Endpoints

| Verbo  | Ruta                 | Descripción               | Éxito | Error |
|--------|----------------------|---------------------------|-------|-------|
| POST   | /api/products        | Crear un producto         | 201   | 400   |
| GET    | /api/products        | Obtener todos los productos | 200 | -     |
| GET    | /api/products/{id}   | Obtener un producto       | 200   | 404   |
| PUT    | /api/products/{id}   | Actualizar un producto    | 204   | 404/400 |
| DELETE | /api/products/{id}   | Eliminar un producto      | 204   | 404   |

### Ejemplo: crear un producto

```bash
curl -X POST http://localhost:5080/api/products \
  -H "Content-Type: application/json" \
  -d '{"name": "Mouse inalámbrico", "price": 29.99}'
```
