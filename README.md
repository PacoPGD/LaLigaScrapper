# LaLigaScrapper

LaLigaScrapper es una API RESTful diseñada para proporcionar la clasificación de equipos de La Liga. Esta API sigue una arquitectura basada en Domain-Driven Design (DDD) con capas de API, Aplicación, Dominio e Infraestructura.

## Capa de API

La capa de API proporciona los puntos de entrada para interactuar con la aplicación. Incluye controladores que manejan las solicitudes HTTP y devuelven las respuestas correspondientes.

### ClasificacionController

El `ClasificacionController` es el controlador encargado de manejar las solicitudes relacionadas con la clasificación de equipos.

- **Métodos:**
  - `GetClasificacion()`: Método GET que devuelve la clasificación de equipos.

## Capa de Aplicación

La capa de aplicación contiene la lógica de aplicación específica, como servicios y DTOs (Data Transfer Objects), que son utilizados por la API para procesar las solicitudes y generar respuestas.

### ClasificacionService

El `ClasificacionService` es un servicio que se encarga de obtener la clasificación de equipos.

- **Métodos:**
  - `GetClasificacion()`: Método que obtiene la clasificación de equipos.

### ClasificacionServiceException

La `ClasificacionServiceException` es una excepción personalizada utilizada para manejar errores específicos relacionados con el servicio de clasificación.

### IClasificacionService

La `IClasificacionService` es una interfaz que define el contrato para el servicio de clasificación de equipos.

## Capa de Dominio

La capa de dominio contiene las entidades y lógica de negocio que representan el núcleo de la aplicación.

### ClasificacionDeLiga

La `ClasificacionDeLiga` es una entidad que representa la clasificación de equipos en La Liga.

### Equipo

El `Equipo` es una entidad que representa un equipo en la clasificación de La Liga.

## Capa de Infraestructura

La capa de infraestructura proporciona implementaciones concretas de servicios externos y componentes de bajo nivel utilizados por la aplicación.

### IRedisService

La `IRedisService` es una interfaz que define el contrato para interactuar con Redis.

### RedisService

El `RedisService` es una implementación concreta de `IRedisService` que utiliza la biblioteca StackExchange.Redis para interactuar con un servidor de Redis.

## Ejecución con Docker Compose

LaLigaAPI se puede ejecutar fácilmente utilizando Docker Compose, que orquesta la ejecución de contenedores Docker para la API y sus servicios relacionados, como Redis.

### Requisitos Previos

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

#### Recomendado
- [Visual Studio 2022](https://visualstudio.microsoft.com/es/)

### Instrucciones de Ejecución con Visual Studio
1. Clona este repositorio en tu máquina local.

    ```bash
    git clone https://github.com/tu_usuario/LaLigaAPI.git
    ```

2. Ejecuta el proyecto docker-compose teniendo docker/docker-desktop en funcionamiento

### Instrucciones de Ejecución sin Visual Studio

1. Clona este repositorio en tu máquina local.

    ```bash
    git clone https://github.com/tu_usuario/LaLigaAPI.git
    ```

2. Navega al directorio del proyecto.

    ```bash
    cd LaLigaAPI
    ```

3. Ejecuta Docker Compose para construir y ejecutar los contenedores.

    ```bash
    docker-compose up
    ```

    Esto iniciará tres contenedores:
    - `laligaapi`: Contenedor para la API LaLigaAPI.
    - `redis`: Contenedor para el servidor Redis utilizado para la caché de datos.
    - `redis-insight`: Contenedor para la interfaz web de Redis Insight para monitorear y administrar Redis.

4. Una vez que todos los contenedores estén en ejecución, puedes acceder a la API en [http://localhost:8080](http://localhost:8080) y a Redis Insight en [http://localhost:5540](http://localhost:5540) para monitorear Redis.

### Detener y Limpiar

Para detener los contenedores y limpiar los recursos utilizados:

    ```bash
    docker-compose down
    ```
