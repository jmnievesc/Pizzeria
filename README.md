# Pizzeria
<p align="center">
    <h1 align="center">Prueba técnica de desarrollo para EOR - SIIM</h1>
    <br>
</p>

El siguiente proyecto esta desarrollado para ser presentado como prueba técnica para EOR y ha sido desarrollado con Visual Studio 2019 con .Net Framework 4.7.2 en Asp.Net con MVC 5 y como lenguaje de programación base Visual Basic.
Además se ha utilizado Entity Framework 6 para el manejo de la base de datos. La base de datos ha sido desarrollada en SQL Server.

La estructura del proyecto es la siguiente:


ESTRUCTURA DE DIRECTORIOS
-------------------------

      Content/            contiene librerias de estilos en cascada
      Controllers/        contiene las clases de los controladores
      Helpers/            Contiene clases personalizadas que son de ayuda en diferentes partes del proyecto
      Models/             Contiene el mapeo de los modelos, además de clases parciales para la asignación de etiquetas de los atributos.
      Views/              contiene las vistas de los controladores
      
      
CONFIGURACION DE BASE DE DATOS
-------------------------------
Para configurar la base de datos es necesario abrir el archivo ```Web.Config``` y cambiar la llave 'PizzeriaEntities' que se encuentra en ```connectionStrings```

PERMISOS
---------
Para asignar permisos en la aplicación se debe contar con un usuario que tenga un rol con accesos a la opcion de dar permisos.
Para ello se debe entrar al grid de Roles y luego en el botón de acciones dar clic en "Permisos", esto hara que se muestren u oculten las diferentes acciones.
Cabe recalcar que aunque se cuente con la URL para una acción si no se posee permisos, la aplicación mostrará un error de acceso.
El manejo de la seguridad de esta manera, permite dar accesos granulares y especificos por accion/controlador. La entidad responsable de evaluar los permisos
es la clase ```Helpers/PermisosActionFilter.vb``` que es llamada como filtro de acción en cada acción considerar a manejar con seguridad.

OTROS
--------
Para efectos de prueba, no se ha incluido el uso de password, por lo que se usaran los usuarios, ```administrador``` y ```encargado``` y se pondrá como
contraseña cualquier secuencia de letras y numeros. 
