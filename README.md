# 💅 MimoraNails - Agus Atelier

> Sistema web para la gestión integral de turnos, clientes, servicios, pagos, stock y reportes.

---

## 👥 Actores del Sistema
* **Administrador / Dueña:** Control total sobre clientes, agenda, catálogo de servicios, registro de pagos, inventario de productos y reportes de ingresos.
* **Manicurista:** Consulta de clientes, gestión de turnos asignados y registro de servicios realizados.
* **Clienta:** Consulta del catálogo de servicios, reserva y cancelación de turnos, y seguimiento de sus citas.

---

## 📌 Requerimientos del Sistema

### Requerimientos Funcionales (RF)
* **Gestión de Clientes:**
  * **RF01:** Registrar clientes.
  * **RF02:** Modificar datos de clientes.
  * **RF03:** Eliminar clientes.
  * **RF04:** Buscar clientes.
* **Gestión de Turnos:**
  * **RF05:** Crear turno.
  * **RF06:** Modificar turno.
  * **RF07:** Cancelar turno.
  * **RF08:** Impedir la asignación de un turno en un horario ocupado (validación de solapamiento).
* **Gestión de Servicios:**
  * **RF09:** Registrar servicios.
  * **RF10:** Modificar precios.
* **Gestión de Pagos:**
  * **RF11:** Registrar pagos.
  * **RF12:** Registrar métodos de pago (Efectivo, Transferencia, Tarjeta).
  * **RF13:** Registrar saldo pendiente.
* **Gestión de Productos y Stock:**
  * **RF14:** Registrar producto.
  * **RF15:** Modificar producto.
  * **RF16:** Registrar entrada/salida de insumos.
  * **RF17:** Consultar stock disponible.
* **Reportes y Estadísticas:**
  * **RF18:** Consultar ingresos.
  * **RF19:** Consultar cantidad de turnos.
  * **RF20:** Consultar servicios más solicitados.
* **Usuarios y Acceso:**
  * **RF21:** Iniciar sesión mediante usuario y contraseña.
  * **RF22:** Gestionar permisos según el tipo de usuario.
* **Historial:**
  * **RF23:** Consultar el historial de turnos por cliente.

### Requerimientos No Funcionales (RNF)
* **Seguridad:** Autenticación requerida (RNF01), restricción de acceso por rol (RNF02) y protección de datos (RNF03).
* **Usabilidad:** Interfaz intuitiva (RNF04), mensajes de retroalimentación claros (RNF05) y menú de navegación accesible (RNF06).
* **Rendimiento:** Tiempos de respuesta adecuados (RNF07).
* **Integridad:** Consistencia en la base de datos (RNF08) y prevención de duplicidad (RNF09).

---

## 📊 Diagrama y Casos de Uso

<img width="1408" alt="Diagrama de Casos de Uso" src="https://github.com/user-attachments/assets/25f35817-d4b7-4b37-a198-37a971b323d9" />

### Detalle de Casos de Uso (CU)

* **👤 Acceso:**
  * **CU01:** Iniciar sesión

* **👩 Clientes:**
  * **CU02:** Registrar cliente
  * **CU03:** Modificar cliente
  * **CU04:** Eliminar cliente
  * **CU05:** Buscar cliente
  * **CU06:** Consultar historial del cliente

* **📅 Turnos:**
  * **CU07:** Crear turno
  * **CU08:** Modificar turno
  * **CU09:** Cancelar turno
  * **CU10:** Consultar disponibilidad de horarios
  * **CU11:** Consultar turnos

* **💅 Servicios:**
  * **CU12:** Registrar servicio
  * **CU13:** Modificar precio del servicio
  * **CU14:** Consultar servicios

* **💰 Pagos:**
  * **CU15:** Registrar pago
  * **CU16:** Registrar método de pago
  * **CU17:** Consultar saldo pendiente

* **📦 Productos y Stock:**
  * **CU18:** Registrar producto
  * **CU19:** Modificar producto
  * **CU20:** Registrar entrada de stock
  * **CU21:** Registrar salida de stock
  * **CU22:** Consultar stock

* **📊 Reportes:**
  * **CU23:** Consultar ingresos
  * **CU24:** Consultar cantidad de turnos
  * **CU25:** Consultar servicios más solicitados

---

## **DIAGRAMA DE CLASE** 

<img width="1408" height="768" alt="diagramadeclase" src="https://github.com/user-attachments/assets/ef95cda8-5381-4935-8c11-21b32444a09e" />

---

### 🗄️ Base de Datos — Tablas del Sistema

El modelo de datos de Mimora Nails - Agus Atelier representa la estructura de la base de datos del sistema y permite la información relacionada con clientes, turnos, servicios, pagos, productos, stock y usuarios.

| Tabla | Descripción |
| :--- | :--- |
| **Usuario** | Almacena los usuarios que pueden acceder al sistema y sus roles. |
| **Cliente** | Almacena los datos personales y de contacto de las clientas. |
| **Servicio** | Almacena los servicios ofrecidos, sus precios y duración. |
| **Turno** | Almacena las reservas realizadas por las clientas. |
| **Pago** | Registra los pagos realizados y los saldos pendientes. |
| **Producto** | Almacena los productos e insumos utilizados. |
| **MovimientoStock** | Registra las entradas y salidas de productos. |

### 🗄️ **ENTIDADES Y ATRIBUTOS PRINCIPALES

#### 👤 Usuario
* **PK:** `idUsuario`
* `nombreUsuario`
* `contraseña`
* `rol`

#### 👩 Cliente
* **PK:** `idCliente`
* `nombre`
* `apellido`
* `telefono`
* `email`

#### 💅 Servicio
* **PK:** `idServicio`
* `nombre`
* `descripcion`
* `precio`
* `duracion`

#### 📅 Turno
* **PK:** `idTurno`
* `fecha`
* `hora`
* `estado`
* **FK:** `idCliente`
* **FK:** `idServicio`

#### 💰 Pago
* **PK:** `idPago`
* `monto`
* `fecha`
* `metodoPago`
* `saldoPendiente`
* **FK:** `idTurno`

#### 📦 Producto
* **PK:** `idProducto`
* `nombre`
* `descripcion`
* `precio`
* `stockActual`

#### 🔄 MovimientoStock
* **PK:** `idMovimiento`
* `tipoMovimiento`
* `cantidad`
* `fecha`
* **FK:** `idProducto`

## ** RELACIONES PRINCIPALES **

* Un **cliente** puede tener uno o varios **turnos**
* Un **turno** pertenece a un solo **cliente**
* Un Servicio puede estar asociado a varios Turnos.
* Un Turno puede tener uno o varios Pagos, según la forma en que se gestione la seña y el saldo.
* Un Producto puede tener varios MovimientosStock.
* Un MovimientoStock pertenece a un único Producto.

----
## 🛠️ Tecnologías Utilizadas
* **Frontend:** HTML5, CSS3, JavaScript
* **Backend:** C#, .NET
* **Base de Datos:** SQL
* **Control de Versiones:** Git / GitHub
