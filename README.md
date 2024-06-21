# DogApi.Backend
 Consumo de API REST DogApi
Tecnologias usadas
- CQRS (Command Query Responsibility Segregation)
- MediatR (mediación de solicitudes)
- JWT (JSON Web Tokens) para autenticación
- AutoMapper para mapeo de objetos
- Swagger/OpenAPI para documentación de API
- Newtonsoft.Json para serialización JSON
- .Net core 8.

Configuración de proyecto
- Clona este repositorio.
- Asegúrate de tener instalado .NET Core SDK.
- Configura las variables de entorno necesarias en tu entorno de desarrollo.

Estructura del proyecto
- `/Controllers`: Controladores de la API.
- `/Handlers`: Manipuladores de consultas y comandos (CQRS).
- `/Services`: Servicios adicionales (autenticación, servicio dogs).
- `/Models`: Modelos de datos.
- `/Queries`: Consultas CQRS.
- `/Commands`: Comandos CQRS.
- `/Middleware`: Middleware personalizado para el manejo de errores.

Como ejecutar
1. Abre el proyecto en Visual Studio o VS Code.
2. Restaura los paquetes NuGet y compila el proyecto.
3. Configura las variables de entorno en `appsettings.json` o usando variables de entorno.
4. Ejecuta la aplicación.
5. Accede a `https://localhost:{puerto}` para probar la API localmente.

Endpoints y uso
POST
- `/api/auth/token`: Obtiene un token JWT para autenticación.
Json de envío:
{
  "username": "admin",
  "password": "123"
}
Respuesta de ejemplo:
{
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiJhZG1pbiIsImp0aSI6ImQxZmVmN2Q5LWI3OWItNGQyYi05NGY2LTcwZWEwMTY5ODE5OCIsImV4cCI6MTcxODk1MTA3OSwiaXNzIjoieW91cmlzc3VlciIsImF1ZCI6InlvdXJpc3N1ZXIifQ.GNPDkDHUVLGalEODeQE7rfNpIGq5NZUv87NopX252KA"
}
	

GET
- `/api/breeds`: Obtiene la lista de razas de perros.
- `/api/breeds/{breed}/images/random`: Obtiene una imagen aleatoria de una raza específica.
- `/api/list`: Obtiene lista de raza de perros
- `/api/Dogs/breed/{breed}/images/random`: Aunque se genero, no cuenta con funcionamiento. Error 401.
Respuesta desde postman:
{
    "status": "error",
    "message": "No route found for \"GET http://dog.ceo/api/breeds/Affenpinscher/image/random\" with code: 0",
    "code": 404
}

- `/swagger`: Documentación interactiva de la API.



 Autenticación y Autorización
 La API utiliza JWT para autenticación. Asegúrate de proporcionar un token válido en el encabezado `Authorization` para acceder a recursos protegidos.
 
 
 
  Notas Adicionales
  -Para el consumo de los servicios desde postman el `Auth Type` corresponde a Bearer Token 
  -Solo esta habilitado el usario admin para la generación del TOKEN