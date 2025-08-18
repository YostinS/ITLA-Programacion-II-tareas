# Frontend Centro de Capacitación en Oficios

Este es el frontend desarrollado en HTML, CSS y JavaScript puro que consume los APIs del backend .NET.

## Estructura del Proyecto

```
CentroCapacitacionOficios.Client/
├── Html/
│   ├── Css/
│   │   └── estilos.css          # Estilos básicos del login original
│   ├── index.html               # Página de login simple
│   ├── centro_capacitacion.html # Página completa original (con datos simulados)
│   └── admin-dashboard.html     # Página principal integrada con APIs
├── Java/
│   ├── config.js               # Configuración y constantes
│   ├── api-service.js          # Servicio para llamadas a la API
│   ├── forms.js                # Formularios dinámicos
│   └── app.js                  # Lógica principal de la aplicación
└── README.md
```

## Archivos Principales

### admin-dashboard.html
**Este es el archivo principal que debes usar**. Contiene:
- Panel de administración completo
- Integración con todos los APIs del backend
- Gestión de usuarios, cursos, instructores, videos y certificados
- Estadísticas en tiempo real

### API Service (api-service.js)
Contiene todas las funciones para interactuar con el backend:
- CRUD completo para todas las entidades
- Manejo de errores
- Configuración de headers y autenticación

### Formularios (forms.js)
Sistema de formularios dinámicos para:
- Crear y editar registros
- Validación de campos
- Interfaz modal moderna

## Endpoints del Backend Disponibles

### Usuarios (/api/users)
- GET `/api/users` - Obtener todos los usuarios
- GET `/api/users/{id}` - Obtener usuario por ID
- POST `/api/users` - Crear nuevo usuario
- PUT `/api/users` - Actualizar usuario
- DELETE `/api/users/{id}` - Eliminar usuario

### Cursos (/api/courses)
- GET `/api/courses` - Obtener todos los cursos
- GET `/api/courses/{id}` - Obtener curso por ID
- POST `/api/courses` - Crear nuevo curso
- PUT `/api/courses` - Actualizar curso
- DELETE `/api/courses/{id}` - Eliminar curso

### Instructores (/api/instructors)
- GET `/api/instructors` - Obtener todos los instructores
- GET `/api/instructors/{id}` - Obtener instructor por ID
- POST `/api/instructors` - Crear nuevo instructor
- PUT `/api/instructors` - Actualizar instructor
- DELETE `/api/instructors/{id}` - Eliminar instructor

### Videos (/api/videos)
- GET `/api/videos` - Obtener todos los videos
- GET `/api/videos/{id}` - Obtener video por ID
- POST `/api/videos` - Crear nuevo video
- PUT `/api/videos` - Actualizar video
- DELETE `/api/videos/{id}` - Eliminar video

### Certificados (/api/certificates)
- GET `/api/certificates` - Obtener todos los certificados
- GET `/api/certificates/{id}` - Obtener certificado por ID
- POST `/api/certificates` - Crear nuevo certificado
- PUT `/api/certificates` - Actualizar certificado
- DELETE `/api/certificates/{id}` - Eliminar certificado

## Cómo Usar

1. **Iniciar el Backend**:
   ```bash
   cd CentroCapacitacionOficios
   dotnet run
   ```

2. **Abrir el Frontend**:
   - Abrir `admin-dashboard.html` en un navegador web
   - O configurar un servidor web local

3. **Credenciales de Administrador**:
   - Email: admin@centro.com
   - Contraseña: admin123

## Funcionalidades Implementadas

### Para Usuarios Normales
- Visualización de cursos disponibles
- Información de instructores
- Registro de nuevos usuarios
- Estadísticas del centro

### Para Administradores
- Panel de administración completo
- CRUD de todas las entidades
- Formularios dinámicos y modernos
- Notificaciones en tiempo real
- Estadísticas actualizadas automáticamente

## Mejoras Realizadas en los Controladores

1. **Agregados endpoints GET ALL** para obtener listas completas
2. **Corregidos endpoints DELETE** para usar parámetros de ruta
3. **Configuración CORS** corregida para permitir conexiones del frontend

## Configuración

Edita `config.js` para cambiar:
- URL base de la API
- Credenciales de administrador por defecto
- Mensajes y validaciones
- Configuración de almacenamiento local

## Tecnologías Utilizadas

- **HTML5**: Estructura semántica
- **CSS3**: Estilos modernos con gradientes y animaciones
- **JavaScript ES6+**: Funcionalidades asíncronas y modulares
- **Fetch API**: Para comunicación con el backend
- **Local Storage**: Para persistencia básica de datos de sesión