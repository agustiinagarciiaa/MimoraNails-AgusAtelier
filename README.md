# MimoraNails-AgusAtelier
Sistema web para gestión de turnos, clientes, servicios, pagos y stock | Desarrollado con C#, .NET, SQL, HTML, CSS y JS.

---

## 👥 Actores del Sistema
* **Administrador / Dueña:** Control total sobre clientes, agenda, catálogo de servicios, registro de pagos, inventario de productos y reportes de ingresos.
* **Manicurista:** Consulta de clientes, gestión de turnos asignados y registro de servicios realizados.
* **Clienta:** Consulta de catálogo de servicios, reserva y cancelación de turnos, y seguimiento de sus citas.

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

## 📊 Diagrama de Casos de Uso

![Diagrama de Casos de Uso](<img width="1408" height="768" alt="diagramaDeCU" src="https://github.com/user-attachments/assets/410506c9-9e01-4b48-85e4-d6a5b5c86868" />
)

---

---

## 🛠️ Tecnologías Utilizadas
* **Frontend:** HTML5, CSS3, JavaScript
* **Backend:** C#, .NET
* **Base de Datos:** SQL
* **Control de Versiones:** Git / GitHub
