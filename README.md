# Calculadora TDD con .NET

Proyecto de ejemplo para practicar Test-Driven Development (TDD) en C#, usando pruebas unitarias con xUnit, mocks con Moq y análisis estático con SonarQube Cloud en GitHub Actions.

## Objetivo

Implementar una calculadora simple orientada a buenas prácticas de pruebas:

- Separación entre lógica de negocio y pruebas.
- Uso de dependencias inyectadas (ILogger).
- Verificación de comportamiento con mocks.
- Integración continua con build, tests y análisis de calidad.

## Tecnologías

- .NET 10
- C#
- xUnit
- Moq
- Coverlet (OpenCover)
- GitHub Actions
- SonarQube Cloud

## Estructura del proyecto

- [Calculadora.Core](Calculadora.Core): Librería con la lógica principal.
- [Calculadora.Tests](Calculadora.Tests): Proyecto de pruebas unitarias.
- [CalculadoraTDD.slnx](CalculadoraTDD.slnx): Solución.
- [.github/workflows/dotnet.yml](.github/workflows/dotnet.yml): Pipeline CI + SonarQube Cloud.

## Funcionalidad actual

La clase CalculadoraService implementa el método Sumar(a, b), y además registra el evento en un logger.

En la app de consola, el logger está organizado así:

- ConsoleLogger con método estático Log(string mensaje).
- ConsoleLoggerAdapter que implementa ILogger y delega en ConsoleLogger.
- Namespace con nombre: Calculadora.App.Logging.

Comportamiento validado por pruebas:

- Retorna la suma correcta.
- Invoca ILogger.Log exactamente una vez con el mensaje esperado.

## Requisitos

- SDK de .NET 10 instalado.
- (Opcional para análisis remoto) Repositorio en GitHub con secret SONAR_TOKEN configurado.

## Cómo ejecutar localmente

### 1. Restaurar dependencias

```powershell
dotnet restore
```

### 2. Compilar

```powershell
dotnet build --configuration Release
```

### 3. Ejecutar pruebas

```powershell
dotnet test --configuration Release
```

### 4. Generar cobertura (OpenCover)

```powershell
dotnet test --no-build --configuration Release --collect:"XPlat Code Coverage;Format=opencover" --results-directory .\TestResults
```

El archivo de cobertura coverage.opencover.xml se usa en el análisis de SonarQube Cloud.

## Integración continua (CI)

El workflow en [ .github/workflows/dotnet.yml ](.github/workflows/dotnet.yml) hace lo siguiente en cada push a main y eventos de pull request:

1. Configura .NET 10.
2. Instala dotnet-sonarscanner (solo cuando SONAR_TOKEN está disponible y el PR no es de fork externo).
3. Inicia análisis de SonarCloud (begin) con ruta de cobertura OpenCover.
4. Restaura dependencias.
5. Compila en configuración Release.
6. Ejecuta pruebas en Release con cobertura OpenCover.
7. Copia coverage.opencover.xml al workspace.
8. Finaliza análisis de SonarCloud (end) cuando aplica.

## Configuración de SonarQube Cloud

Para que el análisis funcione en GitHub Actions:

1. Ir al repositorio en GitHub.
2. Abrir Settings > Secrets and variables > Actions.
3. Crear el secret SONAR_TOKEN.

Nota:

- En pull requests desde forks externos, los secretos no se exponen por seguridad. En ese caso, el pipeline sigue ejecutando build y tests, pero omite SonarCloud.

El workflow ya incluye:

- organization: edelapaz
- project key: edelapaz_CalculadoraEPN

## Desarrollador

- Eliazar de la paz
- Website: (https://delapazweb.com)
- Email: (edelapaz@gmail.com)

[![Vulnerabilities](https://sonarcloud.io/api/project_badges/measure?project=edelapaz_CalculadoraEPN&metric=vulnerabilities)](https://sonarcloud.io/summary/new_code?id=edelapaz_CalculadoraEPN)
