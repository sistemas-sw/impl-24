# Herencia en Ruby
Como ya sabemos, la herencia es una manera de reutilizar código ya que, a través de ella, una clase puede recibir los métodos de otra clase. En ruby, se usa  el operador `<` para definir una herencia de una clase a su subclase de la siguiente forma:

```ruby

class BaseClass
end

class SubClass < BaseClass
end
```

En importante añadir que el método `Override` en ruby no existe ya que simplemente se indica sobreescribiendo el método con el mismo nombre sin ningún comentario.

```ruby
class BaseClass
  def inicio
    puts "Hola"
  end
end

class SubClass < BaseClass
  def inicio
    puts "Hello"
  end
end
```

En el ejemplo proporcionado, se ha creado una adaptación de la clase "Aventura" en Ruby. Los mecanismos utilizados en Ruby difieren de los empleados en la implementación en Java.

El enlace a todas las clases y módulos se proporciona [aqui](Adventure.rb)

## Ejemplo

### Módulos

En este ejemplo, se utilizan módulos en Ruby para definir comportamientos específicos que pueden ser compartidos entre diferentes clases.

En el código proporcionado, se definen tres módulos: `SabeLuchar`, `SabeNadar` y `SabeVolar`. Cada uno de estos módulos contiene un método que simula la acción correspondiente a la habilidad que representa.

```ruby
module SabeLuchar
  def luchar
    puts "Luchando amateur"
  end
end

module SabeNadar
  def nadar
    puts "Nadando amateur"
  end
end

module SabeVolar
  def volar
    puts "Volando amateur"
  end
end
```

### Clases

#### Personaje de Acción

La clase `PersonajeAccion` define un personaje genérico que puede realizar acciones de lucha. Contiene un método `luchar` que imprime un mensaje indicando que está luchando como un personaje de acción.

```ruby
class PersonajeAccion
  def luchar
    puts "Luchando como un personaje de acción"
  end
end
```

#### Héroe

La clase `Heroe` hereda de `PersonajeAccion` e incluye los módulos `SabeLuchar`, `SabeVolar` y `SabeNadar`. Además, sobrescribe los métodos `volar` y `nadar`. Esto significa que el héroe puede realizar las acciones de luchar, volar y nadar, pero cada una con su propia implementación específica.

```ruby
class Heroe < PersonajeAccion
  include SabeLuchar
  include SabeVolar
  include SabeNadar
  def volar
    puts "Volando como un héroe"
  end
  def nadar
    puts "Nadando como un héroe"
  end
end
```

#### Explorador

La clase `Explorador` también hereda de `PersonajeAccion` e incluye los módulos `SabeNadar` y `SabeVolar`, con métodos sobrescritos para `volar` y `nadar`.
```ruby
class Explorador < PersonajeAccion
  include SabeNadar
  include SabeVolar
  def volar
    puts "Volando como un explorador"
  end
  def nadar
    puts "Nadando como un explorador"
  end
end
```

#### Mago

La clase `Mago` hereda de `PersonajeAccion` e incluye el módulo `SabeVolar`, con un método sobrescrito para `volar`.
```ruby
class Mago < PersonajeAccion
  include SabeVolar
  def volar
    puts "Volando como un mago"
  end
end
```

#### Guerrero

La clase `Guerrero` hereda de `PersonajeAccion` e incluye el módulo `SabeLuchar`, con un método sobrescrito para `luchar`.
```ruby
class Guerrero < PersonajeAccion
  include SabeLuchar
  def luchar
    puts "Luchando como un guerrero"
  end
end
```

### Aventura

La clase `Aventura` tiene un método `realizar_acciones` que toma un protagonista como argumento. Dentro de este método, se realizan diversas acciones dependiendo de las habilidades del protagonista, utilizando el método `respond_to?` para verificar si el protagonista tiene la habilidad requerida.
```ruby
class Aventura
  def realizar_acciones(protagonista)
    puts "¡La aventura ha comenzado!"
    protagonista.luchar if protagonista.respond_to?(:luchar)
    protagonista.nadar if protagonista.respond_to?(:nadar)
    protagonista.volar if protagonista.respond_to?(:volar)
    puts "¡La aventura ha terminado!"
  end
end
```
# Construir programa y pruebas
Para verificar la corrección del ejemplo se han desarrollado unas pruebas, en ruby usamos para ello la gema `minitest` que permite, entre otras cosas, comparar flujos de salida. 
La prueba la puede ver desde auí directamente con este enlace: [Tests](testAdventure.rb)

Para construir el programa y las pruebas se ha desarrollado un github Action, puede runnearlo manualmente desde
el siguiente enlace : [Action](../../../.github/workflows/herencia.ruby.yml)

# Desplegar web 
Para desplegar la web necesitamos ejecutar el terraform (que usa un Dockerfile) con estos comandos:

```terraform
terraform init
terraform apply
```
Una vez que Terraform haya completado el despliegue, la web estará disponible en la siguiente dirección:
`https:localhost/4567`

![image](https://github.com/martaajonees/impl-24/assets/100365874/693b005e-88a2-4232-81a3-82d536ea8c84)

Una vez se quiera dejar libre el puerto del local host se debe parar y eliminar el contenedor que lo ejecuta desde docker usando

`docker stop <nombre-contenedor>`
`docker rm <nombre-contenedor>`

