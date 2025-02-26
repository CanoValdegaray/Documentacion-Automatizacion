**Documentación Técnica y Funcional de la Prueba con Selenium**
===============================================================

**1. Introducción**
-------------------

Este documento describe la prueba automatizada realizada con Selenium para el sitio web [SauceDemo](https://www.saucedemo.com/). Se detalla la configuración, los pasos ejecutados y los resultados esperados, además de incluir un diagrama C4 representando la arquitectura de la prueba.

* * *

**2. Objetivo**
---------------

Automatizar el proceso de inicio de sesión, compra de un producto y finalización de compra en la plataforma SauceDemo utilizando Selenium WebDriver con el navegador Microsoft Edge en modo headless.

* * *

**3. Tecnologías Utilizadas**
-----------------------------

*   **Lenguaje**: C#
*   **Framework de Pruebas**: xUnit
*   **WebDriver**: Selenium WebDriver para Microsoft Edge
*   **Pipeline de Integración Continua**: Azure DevOps
*   **Sistema Operativo**: Windows (entorno de ejecución en CI/CD)

* * *

**4. Configuración del Entorno**
--------------------------------

1.  Instalar .NET SDK.
    
2.  Agregar las dependencias de Selenium en el archivo `.csproj`:
    
        <ItemGroup>
            <PackageReference Include="Selenium.WebDriver" Version="4.1.0" />
            <PackageReference Include="Selenium.WebDriver.ChromeDriver" Version="114.0.5735.90" />
            <PackageReference Include="xunit" Version="2.4.1" />
            <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.5.0" />
        </ItemGroup>
        
    
3.  Configurar Selenium para utilizar Microsoft Edge en modo headless.
    

* * *

**5. Configuración del azure-pipelines.yml**
--------------------------------------------

    - task: UseDotNet@2
      displayName: 'Instalar .NET $(DOTNET_VERSION)'
      inputs:
        packageType: 'sdk'
        version: $(DOTNET_VERSION)
    
    - script: |
        echo "Restaurando paquetes..."
        dotnet restore
      displayName: 'Restaurar dependencias'
    
    - script: |
        echo "Compilando proyecto..."
        dotnet build --configuration Release --no-restore
      displayName: 'Compilar aplicación'
    
    - script: |
        echo "Ejecutando pruebas..."
        dotnet test --configuration Release --no-build --logger trx
      displayName: 'Ejecutar pruebas Selenium'
    
    - task: PublishTestResults@2
      displayName: 'Publicar resultados de pruebas'
      inputs:
        testResultsFormat: 'VSTest'
        testResultsFiles: '**/*.trx'
        mergeTestResults: true
        failTaskOnFailedTests: true
    

* * *

**6. Flujo de la Prueba**
-------------------------

1.  **Abrir el navegador y maximizar la ventana.**
2.  **Navegar a la URL de SauceDemo.**
3.  **Ingresar credenciales de usuario** (`standard_user`, `secret_sauce`).
4.  **Hacer clic en el botón de inicio de sesión.**
5.  **Navegar a diferentes secciones:**
    *   Carrito de compras
    *   Menú lateral
    *   Inventario
6.  **Agregar un producto al carrito.**
7.  **Proceder al checkout e ingresar datos del comprador.**
8.  **Finalizar la compra y volver al inicio.**
9.  **Cerrar el navegador.**

* * *

**7. Resultados Esperados**
---------------------------

*   La prueba debe completar exitosamente el flujo de compra sin errores.
*   Se debe verificar que el producto se agregó correctamente al carrito.
*   La finalización de la compra debe mostrar el mensaje de confirmación.

* * *

**8. Integración Continua en Azure DevOps**
-------------------------------------------

Se utiliza un pipeline en Azure DevOps con los siguientes pasos:
1.  **Instalación de .NET SDK** (versión 9.0.100).
2.  **Restauración de dependencias** (`dotnet restore`).
3.  **Compilación del proyecto** (`dotnet build`).
4.  **Ejecución de pruebas** (`dotnet test`).
5.  **Publicación de resultados de pruebas** (`PublishTestResults`).

**9. Diagrama C4**
------------------

El siguiente diagrama muestra la estructura de la prueba automatizada en el contexto del sistema.

[![Diagrama C4](C4%20Automatizacion.png)](C4%20Automatizacion.png)

* * *


**10. Conclusiones**
--------------------

Este documento describe la configuración y ejecución de una prueba automatizada con Selenium en Azure DevOps para validar el flujo de compra en SauceDemo. Se detallan los pasos de la prueba, los resultados esperados y la infraestructura utilizada.