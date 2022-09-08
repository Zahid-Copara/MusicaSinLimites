# MusicaSinLimites
Proyecto realizado para la materia de Aplicaciones Distribuidas de la Escuela Politécnica Nacional.

Realizado por: 
  - Ibeth Bastidas
  - Zahid Copara

# Descripción: 
Aplicación basada en el modelo cliente servidor y con conexiones TCP que simula un repositorio de música. 

# Resultados:

# BaseDeDatos
  * El código en ManejadorDB del proyecto BaseDeDatos realiza la conexiones a la base de datos y los métodos de búsquedas y validaciones
  necesarios para el desarrollo correcto del proyecto. Esta biblioteca se usa como referencia en el Servidor.

# Entidad
  * El código de Canción en el proyecto Entidad es una Clase con los atributos de la canción, los métodos Get y Set, y los constructores necesarios o los requeridos por ManejadorDB para realizar los distintos procesos. Esta biblioteca se usa como referencia en ManejadorDB y en el Servidor.

# Cliente
  * El cliente consta de las clases: PaqueteCliente, MapaCliente y ConexionTCPCliente. Consta de los formularios: Editar, Búsqueda, Menú_Principal e Ingresar_Canción
  * En PaqueteCliente se elabora un paquete que será el que se enviará, se definen los constructores con distintos parámetros de entrada y la serialización para separar el paquete en comando y contenido. El comando permitirá tanto a cliente y servidor interpretar el contenido del mensaje y realizar lo más adecuado.
  * En MapaCliente se serializa y deserializa el paquete, es decir, de un conjunto de strings separados por comas se lo hace una lista y viceversa. Mapa y Paquete funcionan de la misma forma tanto en Cliente como Servidor.
  * ConexionTCPCliente se definen los métodos que permiten que se realice la conexión TCP entre cliente y servidor.
  * Busqueda es el formulario para realizar búsquedas por parámetros, contiene los métodos para interpretar los comandos de LISTAR_POR y eliminar canciones.
  * Editar es el formulario que permite editar una canción a partir de seleccionarla desde Búsqueda, contiene los métodos para interpretar el comando Actualizar que NOOK y OK que recibe desde el servidor.
  * Ingresar_Canción es el formulario para el ingreso de canciones y contiene los métodos para interpretar los comandos CREAR, NOOK y OK del servidor
  * Menú_Principal es el formulario que contiene a todos los demás, contiene la conexión TCP 

# Servidor
  * El servidor consta de las clases: PaqueteServidor, MapaServidor y ConexionTCPServidor. Consta del formulario: ServidorForm
  * Mapa, Paquete y Conexión resultan en lo mismo que en lo explicado para el cliente.
  * SevidorForm es el formulario que contiene la conexión TCP, y los métodos para interpretar los comandos de los paquetes enviados por el Cliente
  * Envía respuestas al cliente de acuerdo a lo solicitado, envía OK y el detalle de lo sucedido cuando se ejecuta correctamente y NOOK cuando ha ocurrido algún error, envía los paquetes necesarios para listar los elementos solicitados por el cliente.Y procesa las solicitudes del cliente modificando la base datos

