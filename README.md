# LaLigaScrapper

LaLigaScrapper es una API RESTful dise�ada para proporcionar la clasificaci�n de equipos de La Liga. Esta API sigue una arquitectura basada en Domain-Driven Design (DDD) con capas de API, Aplicaci�n, Dominio e Infraestructura.

## Capa de API

La capa de API proporciona los puntos de entrada para interactuar con la aplicaci�n. Incluye controladores que manejan las solicitudes HTTP y devuelven las respuestas correspondientes.

### ClasificacionController

El `ClasificacionController` es el controlador encargado de manejar las solicitudes relacionadas con la clasificaci�n de equipos.

- **M�todos:**
  - `GetClasificacion()`: M�todo GET que devuelve la clasificaci�n de equipos.

## Capa de Aplicaci�n

La capa de aplicaci�n contiene la l�gica de aplicaci�n espec�fica, como servicios y DTOs (Data Transfer Objects), que son utilizados por la API para procesar las solicitudes y generar respuestas.

### ClasificacionService

El `ClasificacionService` es un servicio que se encarga de obtener la clasificaci�n de equipos.

- **M�todos:**
  - `GetClasificacion()`: M�todo que obtiene la clasificaci�n de equipos.

### ClasificacionServiceException

La `ClasificacionServiceException` es una excepci�n personalizada utilizada para manejar errores espec�ficos relacionados con el servicio de clasificaci�n.

### IClasificacionService

La `IClasificacionService` es una interfaz que define el contrato para el servicio de clasificaci�n de equipos.

## Capa de Dominio

La capa de dominio contiene las entidades y l�gica de negocio que representan el n�cleo de la aplicaci�n.

### ClasificacionDeLiga

La `ClasificacionDeLiga` es una entidad que representa la clasificaci�n de equipos en La Liga.

### Equipo

El `Equipo` es una entidad que representa un equipo en la clasificaci�n de La Liga.

## Capa de Infraestructura

La capa de infraestructura proporciona implementaciones concretas de servicios externos y componentes de bajo nivel utilizados por la aplicaci�n.

### IRedisService

La `IRedisService` es una interfaz que define el contrato para interactuar con Redis.

### RedisService

El `RedisService` es una implementaci�n concreta de `IRedisService` que utiliza la biblioteca StackExchange.Redis para interactuar con un servidor de Redis.

## Ejecuci�n con Docker Compose

LaLigaAPI se puede ejecutar f�cilmente utilizando Docker Compose, que orquesta la ejecuci�n de contenedores Docker para la API y sus servicios relacionados, como Redis.

### Requisitos Previos

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)

#### Recomendado
- [Visual Studio 2022](https://visualstudio.microsoft.com/es/)

### Instrucciones de Ejecuci�n con Visual Studio
1. Clona este repositorio en tu m�quina local.

    ```bash
    git clone https://github.com/tu_usuario/LaLigaAPI.git
    ```

2. Ejecuta el proyecto docker-compose teniendo docker/docker-desktop en funcionamiento

### Instrucciones de Ejecuci�n sin Visual Studio

1. Clona este repositorio en tu m�quina local.

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

    Esto iniciar� tres contenedores:
    - `laligaapi`: Contenedor para la API LaLigaAPI.
    - `redis`: Contenedor para el servidor Redis utilizado para la cach� de datos.
    - `redis-insight`: Contenedor para la interfaz web de Redis Insight para monitorear y administrar Redis.

4. Una vez que todos los contenedores est�n en ejecuci�n, puedes acceder a la API en [http://localhost:8080](http://localhost:8080) y a Redis Insight en [http://localhost:5540](http://localhost:5540) para monitorear Redis.

### Detener y Limpiar

Para detener los contenedores y limpiar los recursos utilizados:

    ```bash
    docker-compose down
    ```
