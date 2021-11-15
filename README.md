## Programación de aplicaciones visuales 1 - Curso 3K5 - UTN-FRC - 2021

### Trabajo Practico Integrador:

Grupo N° 4 - Integrantes:

* 54910 Gómez Iván

* 80122 Ricse Javier

* 79811 Vargas Bruno

### Modulo N°4 - Facturación de Proyectos y Productos

------

La empresa BugTracker S.R.L solicita el desarrollo de un sistema de software de escritorio, que brinde soporte a su proceso de Facturación de Productos y Proyectos de software desarrollados. Para lo cual,  se decide implementar un motor de base de datos relacional SQLExpress 2019 y como leguaje de programación, C#, utilizando WinForms bajo el Framework NET CORE 5.



### Modelo de Datos Normalizado

![image-20211114231136420](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211114231136420.png)

------



### Descripción del Sistema

Login: Al ejecutar el sistema, lo primero que nos aparece es una ventana de Login, en donde nos requerirá un nombre de usuario y una contraseña para el acceso autorizado al sistema.

![image-20211114232011953](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211114232011953.png)

El sistema validará que luego de presionar el botón Ingresar, los datos ingresados se correspondan con los de alguno del los usuarios almacenados en la base de datos. Si la validación resulta exitosa, nos permitirá el acceso al sistema y tendremos disponible el menú de opciones de la aplicación.

![image-20211114232500322](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211114232500322.png)

Como se puede observar, en la parte inferior, muestra el nombre de usuario logueado, el cual, mas adelante, también quedara registrado automáticamente como el vendedor o responsable de haber efectuado un proceso de facturación.

------



### Descripción del menú de opciones

* Archivo -> Salir: Esta opción permite cerrar el sistema. Al presionarla, el sistema solicita confirmación para salir.

![image-20211114234612477](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211114234612477.png)

* Facturación:

![image-20211115005241614](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115005241614.png)

* Facturación - Registrar Factura: Abre la ventana encargada de gestionar el proceso de facturación. Permite registrar el cliente, el producto y/o proyecto mas los costos asociados. El sistema toma otros datos de forma automática tales como el usuario que efectuó la operación y la fecha y hora al momento de la misma.

  ![image-20211115010302449](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115010302449.png)

  

  Al presionar el botón 'Nueva Factura' se habilita el formulario para rellenar los datos correspondientes. Todos los campos son obligatorios y el sistema implementa mecanismos que se aseguran de validar el ingreso correcto de los mismos. A continuación se enumera la secuencia de pasos para registrar una nueva Factura:

  1- Registrar los datos del cliente a quien facturar. 

  Para ello, completar los 11 dígitos del numero de CUIT y presionar el botón de búsqueda. Si el cliente se encuentra cargado en el sistema se autocompletaran todos los campos con la información del cliente.

  ![image-20211115010855558](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115010855558.png)

  En caso de no encontrarse el cliente con el numero de CUIT ingresado, el sistema informara la situación y el operador deberá cancelar la operación y gestionar el alta del Cliente en el menú Soporte -> Clientes.

  2- Agregar ítems al detalle de factura.

  Es necesario ingresar al menos un ítem al detalle ya que el sistema lo validara al momento de intentar confirmar el registro. Para ello en el apartado Ítems debemos seleccionar un Producto de la lista desplegable. Si este Producto seleccionado posee Proyectos asociados a el, entonces se habilitara la posibilidad de marcar la opción 'Proyectos'.

  ![image-20211115012000483](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115012000483.png)

  Como vemos en la imagen, este producto posee Proyectos asociados, con lo cual, nos permite seleccionar 'Producto Final' o 'Proyecto'. Si cambiamos a Proyecto, se cargaran sobre la grilla todos los Proyectos asociados al Producto. En ese caso deberíamos hacer click sobre el proyecto, colocarle un Precio y finalmente presionar el botón Agregar.

  ![image-20211115012554204](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115012554204.png)

  Disponemos de un botón 'Limpiar' en caso que quisiéramos deshacer la búsqueda y efectuar una nueva.

  Al momento de tocar el botón Agregar, el ítem se agrega al detalle de factura con su Precio y se limpia la sección Ítem automáticamente. Con esto, podemos agregar de la misma forma tantos ítem como necesitemos, siempre y cuando, no se repita el proyecto o producto final, el sistema lo validará.

  ![image-20211115013446309](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115013446309.png)

  Dentro del Detalle de Factura, el sistema nos permite seleccionar un item y eliminarlo de la lista en caso de ser necesario.

  El campo Total, nos muestra el total acumulado de los ítems que formen parte del Detalle de Factura.

  3- Confirmar operación y grabar Factura.

  Este botón, solicitara confirmación y en caso de ser aprobada por el operador, registrara la transacción. 

  ![image-20211115014835154](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115014835154.png)

  El sistema informara 'Transacción exitosa!!!', aparecerá bajo la fecha el numero de Factura asociado a la transacción y se habilitara el botón 'Imprimir' en caso que se desee imprimir la Factura.

  ![image-20211115014909333](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115014909333.png)

  

  4- Salida de Información - Factura

  ![image-20211115015046836](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115015046836.png)

  

  Facturación -> Consultar Histórico

  Esta opcion abre un formulario de consulta de Facturas.
  
  ![image-20211115162201564](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115162201564.png)
  
  Al igual que otras ventanas de consulta, cuenta con una sección de Filtros, donde permite parametrizar la búsqueda y de esta forma agilizar la búsqueda de la factura requerida. O bien, podemos marcar la opción 'Todos' y el sistema traerá todas las facturas existentes. En cualquiera de los casos, las facturas se mostrarán en la grilla, ordenadas desde la mas nueva a la mas antigua.
  
  ![image-20211115162838071](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115162838071.png)
  
  Como podemos observar, en la grilla cada fila se corresponde con una factura, de la cual obtenemos datos generales.
  
  Si requerimos información detallada o imprimir la factura, podemos seleccionarla en la grilla y seguidamente se habilitará el botón 'Ver Detalles'. Este botón abrirá un formulario de Facturación con datos de la factura registrada en modo de Solo Lectura.
  
  ![image-20211115163558445](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115163558445.png)

Este formulario nos permite ver el detalle de lo facturado y se solo se encuentra habilitado el botón de Imprimir y el de Salir.

En caso de seleccionar imprimir se obtendrá la salida de información correspondiente a la factura, de igual manera que al momento de efectuar el proceso de facturación.

------

Soporte

 Este menú contiene el acceso a cada ABM de las entidades de soporte.

![image-20211114234802239](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211114234802239.png)

Soporte -> Clientes: Esta opción despliega un formulario de gestión de Clientes. Permite la búsqueda por filtros o marcando la casilla 'Todos', muestra todos los clientes. La visualización de los Clientes a través de una grilla.

![image-20211114235347945](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211114235347945.png)

Como podemos ver, el campo 'Razón Social' y 'CUIT' son los dos parámetros de búsqueda disponible en esta ventana. Vemos además, que los botones inferiores de 'Editar' y 'Quitar' se encuentran deshabilitados por defecto, esto es debido a que operan sobre el Cliente seleccionado en la grilla como veremos a continuación.

![image-20211115000447654](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115000447654.png)

Botón Editar: Al presionar este botón, el sistema abre una ventana que contiene los datos del cliente seleccionado en modo de edición. En la parte inferior, el botón verde permite confirmar al operación de edición, mientras que el botón rojo permite cancelar la operación y volver a la ventana de Clientes. 

![image-20211115001030122](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115001030122.png)

Los botones verdes adyacentes a los Combos de Barrio y Contacto permiten que en caso de no encontrarse el valor buscado en alguno de los combos, directamente abrir la ventana de Alta de la entidad correspondiente.

Botón Quitar: Esta opción permite eliminar un cliente. Si bien el borrado es lógico, el usuario no volverá a ver este cliente en la ventana de Clientes y tampoco seleccionarlo en el proceso de facturación. Al presionar este botón se abre una ventana en modo de solo lectura con los datos del cliente a eliminar. El botón verde acepta la eliminación y pide confirmación; mientras que el botón rojo cancela la operación y retorna a la ventana de Clientes.

![image-20211115002226212](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115002226212.png)

![image-20211115002358168](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115002358168.png)

Botón Agregar: Esta opción abre una ventana con todos los campos en blanco para el nuevo Cliente excepto la fecha de alta, que por defecto es la actual, pudiendo ser modificada. Todos los campos son requeridos y se implementan mecanismos de validación para los mismos. Al presionar el botón verde (Confirmar), se agrega un nuevo registro a la base de datos, con lo cual, el nuevo cliente.

![image-20211115002834265](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115002834265.png)

------

A continuación se muestran las opciones de Contactos y Proyectos pero no entraremos en detalles debido a que la presentación y la lógica de funcionamiento es exactamente la misma que para el caso de Clientes.

* Contactos

![image-20211115004252228](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115004252228.png)

* Contactos - Editar

  ![image-20211115004443288](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115004443288.png)

* Contactos - Quitar

  ![image-20211115004541223](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115004541223.png)

  * Contactos - Nuevo

    ![image-20211115004627271](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115004627271.png)

    * Proyectos

      ![image-20211115004746205](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115004746205.png)

      * Proyectos - Editar

        ![image-20211115004834317](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115004834317.png)

        * Proyectos - Quitar

          ![image-20211115004913179](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115004913179.png)

          * Proyectos - Nuevo

            ![image-20211115004951523](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115004951523.png)

    
    
    
    * Soporte - Barrios
    
      Esta ventana permite la gestión de los Barrios. Debido a la sencillez de la entidad en este dominio, barrios cuenta con un solo campo de información, el cual es su Nombre. Por tal motivo el diseño se minimiza pero la lógica de la interfaz se sigue respetando.
    
    ![image-20211115164235401](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115164235401.png)
    
    En este caso, todos los barrios cargados se encuentran en la lista desplegable. Si deseamos Editar o Quitar uno, basta con seleccionarlo en la lista para que se habiliten los botones de 'Editar' y 'Quitar'.
    
    ![image-20211115164726075](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115164726075.png)
    
    * Barrios - Editar
    
       el sistema abrirá una nueva ventana en la cual podremos editar el nombre del Barrio. Tanto para el Alta como para la modificación, el sistema no permitirá el ingreso de nombres duplicados.
    
    ![image-20211115165322942](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115165322942.png)
    
    * Barrios - Quitar
    
       el sistema solicitara la confirmación del operador.
    
    ![image-20211115165501817](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115165501817.png)
    
    * Barrios - Nuevo
    
    Al hacer Click sobre el campo de texto en la sección 'Registrar Nuevo', se habilitara el botón Agregar. El sistema requerirá que este campo contenga algún valor. Un vez agregado, se actualizará la lista desplegable con el nuevo Barrio.
    
    ![image-20211115172526807](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115172526807.png)
    
    
    
    ------
    
    ### Reportes
    
    Todas las salidas de información se encuentran en formato de Hoja A4, con un encabezado, fecha de creación y un pie de pagina donde figura el numero de pagina respecto del total de las mismas.
    
    El sistema cuenta con dos reportes:
    
    * Listado de Proyectos: Listado detallado de todos los proyectos vigentes ordenados por Producto al que pertenecen y versión.
    
    ![image-20211115172247966](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115172247966.png)



![image-20211115173216452](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115173216452.png)



* Top 10 distribución de Proyectos: Este reporte muestra los diez productos con mayor cantidad de proyectos. Muestra una tabla organizada por puesto, donde el puesto numero 1 corresponde al Producto con mas Proyectos, decendiendo hasta el puesto 10.

  A su vez muestra un grafico porcentual de la cantidad de Proyectos que tenga cada Producto sobre el total de proyectos aportados por los diez Productos del top.

![image-20211115173316698](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115173316698.png)



![image-20211115173406052](https://raw.githubusercontent.com/ivangomez854/cloudimg/master/img/image-20211115173406052.png)



