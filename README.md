
## Proyectos dentro de la solucion

## DevelopmentChallenge.Data
Tiene las clases correspondientes a cada forma geométrica, capa de Servicios donde se encuentra el metodo Imprimir y los archivos de recursos necesarios para implementar los distintos idiomas.

## DevelopmentChallenge.Data.Tests
Proyecto de pruebas unitarias

## KlimberChallenge
Aplicación de consola para realizar pruebas rápidas

## Agregar nuevo idioma
En caso de querer agregar un nuevo idioma, se debe agregar un nuevo archivo de recursos respetando el nombre del archivo base, en este caso Textos + Código Cultural de Lenguaje. Los códigos se pueden consultar en https://learn.microsoft.com/en-us/previous-versions/commerce-server/ee825488(v=cs.20)?redirectedfrom=MSDN
Una vez hecho esto, se deben cargar todas las traducciones en el archivo de recursos.
Por ultimo, en el código, se debe agregar el nuevo lenguaje en la clase Idioma.cs que contiene un enumerado con los lenguajes disponibles y en el constructor de la clase Imprimir incorporar el caso del nuevo lenguaje.

## Agregar una nueva forma geométrica
Cada forma geométrica se agregar creando una clase que implemente la interfaz IFormaGeometrica. Luego se agrega la nueva forma geométrica a la clase FormasGeometricas.cs que tiene un enumerado con las formas disponibles, y por ultimo en el método imprimir se agrega el caso de la nueva forma geométrica

 
 
