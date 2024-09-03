# KlimberChallenge

/******************************************************************************************************************/
/******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
/******************************************************************************************************************/

/*
 * TODO: 
 * Refactorizar la clase para respetar principios de la programación orientada a objetos.
 * Implementar la forma Trapecio/Rectangulo. 
 * Agregar el idioma Italiano (o el deseado) al reporte.
 * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
 * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).

 */

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

 
 
