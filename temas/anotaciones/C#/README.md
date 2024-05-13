# Ejemplos de Anotaciones en C#
En estos ejemplos se pretende mostrar la forma en la que C# permite el uso de aspectos en la programación orientada a objetos. 
Las anotaciones son una forma de añadir metadatos a nuestro código, concretamente a tipos, métodos u objetos. Estas anotaciones sirven para describir el comportamiento del elemento que las posea o incluso dotarles de algunos comportamientos extra en tiempo de ejecución. Existen algunas bibliotecas en los lenguajes que ofrecen anotaciones prediseñadas para su uso, aunque el programador puede crear sus anotaciones personalizadas si así lo desea. En el caso de C#, las anotaciones se conocen como atributos, y no se ofrecen demasiadas opciones a la hora de crear anotaciones personalizadas que otorguen nuevos comportamientos a las clases. Normalmente se utilizan las anotaciones personalizadas para la inyección de dependencias, pero en C# se utilizan más para la serialización, validación de campos o creación de aspectos, y para todos estas situaciones existen librerías que resultan de gran ayuda. Es por eso que se ha optado por mostrar dos pequeños ejemplos de algunas opciones que ofrecen las librerías de C# que contienen anotaciones.

## Contexto de los ejemplos
El ejemplo 1, en la carpeta CodeJSON, se pretende serializar y deserializar objetos de una clase persona. Esto puede ser muy útil para la creación de APIs rest y situaciones en las que se envíen objetos como parte de un mensaje entre dos máquinas diferentes.

El ejemplo 2, en la carpeta CodeValidacion, se pretende validar de forma rápida cada uno de los atributos de la clase Persona, cada uno de ellos según unas condiciones diferentes. Esto es muy útil para formularios web y cualquier situación en la que se necesite la validación de campos de esta forma.

## Problema
Serializar y deserializar objetos de clases con muchos atributos y de estructura compleja puede ser un proceso tedioso, siendo más susceptible a errores y haciendo un código más difícil de comprender y menos mantenible. Es un caso similar al de la validación de atributos, ya que tendríamos que programar sentencias condicionales para cada uno de los atributos y acabaríamos haciendo un código parecido al de pruebas unitarias.

## Solución
Para poder serializar y deserializar objetos con mayor facilidad, podemos hacer uso de la librería NewtonSoft.json, que usa las anotaciones para realizar este proceso de forma automática. Las anotaciones son sencillas y nos permiten especificar cuáles son los datos que queremos incluir. Como DateTime es un tipo de datos relativamente especial, necesitamos hacer uso de la clase JsonConverter para poder serializar y deserializarlo.

Para el problema de la validación, contamos con la librería DataAnnotations, que cuenta con una serie de anotaciones que podemos utilizar para detectar cuando los atributos de nuestra clase no cumplan con los requisitos deseados. Incluso podemos añadir mensajes en las anotaciones, para que se muestren en caso de detectarse un error. Además de las anotaciones utilizadas en el ejemplo, existen otras como Display o RegularExpresion, para proporcionar metadatos sobre cómo mostrar el atributo en una interfaz o comprobar que una cadena cumple con una expresión regular, respectivamente.