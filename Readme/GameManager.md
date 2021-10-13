# [UI] Implementar Nuevo Temporizador y usarlo en UI

La implementación del Timer (temporizador) se hizo en la clase `GameManager`

## Timer
La clase Timer posee 4 propiedades

Propiedades:

* *private* static **bool** _tick
* *private* static **float** _gameTimer
* *private* static **string** _timerString
* *private* static **float** _lastLap

Los metodos que implementa (a excepcion del Update() que se hereda de MonoBehaviour) son estaticos.

> `Timer#Update`

Se ejecuta en cada frame o cuadro. En caso que el juego transcurriese a 30 cuadros por segundo (30 FPS), este metodo se ejecutaria 30 veces por segundo.
Se implementa la logica para obtener el tiempo real transcurrido en el juego y atribuirselo a  `_gameTimer`
y a `timerString`.
En caso que el juego no haya sido iniciado, se ejecuta el metodo `ResetTimer()` para mantener el timer en 0.


> `Timer#TimeToString`

Recibe un parametro de tipo `float` que representa tiempo, y lo transforma a `string`, dandole formato de hh:mm:ss

> `Timer#StartTimer`

Inicia el timer, estableciendo `_tick = true`

> `Timer#StopTimer`

Detiene el timer, estableciendo `_tick = false`

> `Timer#ResetTimer`

Reinicia el timer, estableciendo `_gameTimer = 0f`

> `Timer#GetCurrentTime`

Retorna el timer en el estado actual

---

## EntityWithTime

Es una clase utilizada para asociar una entidad con un tiempo. Es necesaria para facilitar la implementacion del Diccionario dentro de la clase `GameManager`

Propiedades:

* *public* **string** elaspedTime
* *public* **Entity** entity

Los `getters` son publicos mientras que los `setters` son privados.

**Posee un constructor**

---
## GameManager

Propiedades: 

* *public* static **event Action<Entity>** OnNewElementAddedToDictionary
* *public* static **Dictionary <string, EntityWithTime>** TimeRecordsDictionary OnNewElementAddedToDictionary
* *private* static **bool** gameStarted
* *public* static **event Action** OnGameStarted
* *public* static **event Action** OnGameEnded

> **Caso: Implementar Nuevo Temporizador**

Se utiliza un diccionario `TimeRecordsDictionary` para poder registrar el tiempo que se tarda en tomar una Entidad.

GameManager se suscribe a `SelectController#OnSelectedEntityChanged` y ejecuta el metodo `HandleEntitiesFetched`.

> `GameManager#HandleEntitiesFetched`

Metodo que recibe como parametro una Entidad y que se encarga de crear un nuevo registro en el diccionario (Se devuelve una excepcion en caso que el registro ya exista)
Se dispara el Action `OnNewElementAddedToDictionary` y se le pasa la Entidad recibida como parametro en caso que la creacion del registro en el diccionario haya sido exitosa.
Caso contrario, se le pasa `null`.

---

## ListPanel

##### Clase encargada de vincular una Entidad que fue seleccionada (de forma momentanea) con un Canvas.

Propiedades

* *private* **Entity** _boundEntity
* *private* **List**<CheckListItem> _checkListObjects

Al comienzo, la clase se suscribe a `GameManager#OnNewElementAddedToDictionary` con el metodo `AddTimeToListItem`.
También obtiene los items de Checklist que están asociados al Canvas donde esta clase es utilizada y los guarda en `_checkListObjects`.


> `ListPanel#Bind`

Recibe una entidad `Entity` como parametro. 
Esta funcion asigna la Entidad que está siendo seleccionada en el juego a la variable `_boundEntity` y se suscribe al metodo `Entity#OnStatusChanged`, asignando una funcion `HandleStatusChanged`.


> `ListPanel#HandleStatusChaned`

Recibe una entidad `Entity` como parametro.
Trata de encontrar la entidad dentro del listado de `_checkListObjects` y si la encuentra, activa el `Toggle` que la entidad trae consigo por ser un item de Checklist.

> `ListPanel#AddTimeToListItem`

Recibe una entidad `Entity` como parametro.

Crea una variable de tipo `EntityWithTime` que va a obtener del GameManager usando `GameManager#GetEntityWithTime` y pasandole como parametro la Entidad.

Luego, intentará buscar esa entidad de tipo `EntityWithTime` dentro del listado de `_checkListObjects`. En caso de hallarla, se obtendrá un **listItem** al cual se le modificará la propiedad de `text` con el tiempo correspondiente.   



