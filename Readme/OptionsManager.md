# [UI] Al seleccionar una gondola, deberian mostrarse las opciones en un cuadro de Dialogo Flotante

### OptionsManager

Propiedades: 
* *public* **Transform** content 
  * donde se renderizará el cuadro de opciones
* *public* **TMP_Text** titleText
  * el titulo del cuadro de opciones
* *public* **GameObject** selectableOptionPrefab
  * el prefab de las opciones seleccionables
* *public* **List<SelectableOptionItem>** selectableOptionsList
  * el listado de opciones seleccionables
* *public* **bool** isLoading
  * Indicador para saber si el canvas esta en proceso de desactivación
* *private* **Canvas** canvas
  * Referencia al canvas de donde se encuentra el OptionsManager

#### Propósito: Gestionar el objeto de Canvas donde se renderizan las opciones

OptionsManager se suscribe al evento de `SelectController::OnSelectingEntity` donde ejecutará el metodo `DisplayPickingOptions`


> `OptionsManager#DisplayPickingOptions`

Recibe un listado de entidades (Entity) como parametro.
Va a mostrar las opciones disponibles para seleccionar.

Se van a instanciar los prefabs de opciones seleccionables segun la cantidad de entidades que vengan en la lista mediante el metodo `CreateOptionObject`.
Finalmente, se termina instanciando un elemento extra, que representa la opcion negativa o de cancelacion. En lugar de pasar una entidad al metodo de `CreateOptionObject` se le pasa **`null`**

> `OptionsManager#CreateOptionObject`

Recibe un titulo, un subtitulo y una Entidad.

Crea una instancia de un GameObject con base en el prefab de opciones seleccionables.
A esa instancia se la hace hija del cuadro de opciones.

De la instacia, se obtiene el objeto de tipo `SelectableOptionItem` y se invoca el metodo `SetObjectInfo`, al cual se le pasan como parametros el titulo, el subtitulo, la entidad y un delegate **TriggerEntitySelection**

Finalmente, se termina agregando esta instancia al listado de opciones seleccionables del `OptionManager`

> `OptionsManager#TriggerEntitySelection`

Recibe una Entidad y lo que hace es
* Desactivar el Canvas (ocultarlo)
* Invocar el metodo estatico `SelectController#GetEntity` y pasarle como parametro la entidad
  * Este metodo estatico se encarga de disparar el evento `OnSelectedEntityChanged` y provocar el cambio de estado de la entidad, de `picked: false` ==> `picked: true`

---
### SelectableOptionItem

Propiedades: 
* *private* **TMP_Text** title
* *private* **TMP_Text** subtitle
* *private* **Entity** associatedEntity
* *private* **Button** button

#### Propósito:  Encargada de crear un objeto interactivo en pantalla.


> `SelectableOptionItem#SetObjectInfo`


Funcion que cumple el rol de Constructor.
Recibe como parametros: titulo (string), subtitulo (string), Entidad (Entity) y un Delegate o Action y se los asigna a las propiedades de la clase.

Para pasarle el Delegate al **button** y que pueda utilizarse, se debe hacer una pequeña modificación a la clase conocida como "Metodo de Extensión". Esto permite "agregar" un metodo a los tipos existentes sin necesidad de crear un nueva clase derivada, recompilar o modificar de otra manera la clase original.
El metodo de extension y la clase que lo implementa deben ser estaticas (**static**)

```
public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> onClick)
    {
        button.onClick.AddListener(delegate()
        {
            onClick(param);
        });
    }
}
```


---
### UIManager

Propiedades: 
* *private* **ListPanel** listPanel
* *private* **ListPanel** wrongItemsListPanel
* *private* **OptionsManager** optionsCanvas
* *private* **StatsPanel** statsPanel
* *private* **GameObject** InformationPanel
* *public* **float** spawnDistance

#### Proposito: Gestionar la UI y los objetos relacionados a ella

