# Ejercicios MVC en C#

Once ejercicios hechos como aplicaciones de consola en C# (.NET 8) usando la arquitectura MVC.

## Estructura de cada ejercicio

Cada ejercicio es una solución de Visual Studio independiente:

```
01-TaskList/
├── TaskList.sln
└── TaskList/
    ├── Models/        -> clases con los datos (campos privados, constructor y métodos)
    ├── Views/         -> todo lo que se muestra y se lee en consola
    ├── Controllers/   -> la lógica que conecta el modelo con la vista
    └── Program.cs     -> crea el controlador y lo ejecuta
```

- **Model:** guarda la información y sus reglas (por ejemplo `TaskItem`, `Expense`, `Recipe`).
- **View:** solo usa `Console.WriteLine` / `Console.ReadLine`; no toma decisiones.
- **Controller:** recibe lo que digita el usuario desde la vista, trabaja con los modelos y le dice a la vista qué mostrar.

Los datos se guardan en listas mientras el programa está abierto.

## Ejercicios

| # | Carpeta | Ejercicio | Qué hace |
|---|---------|-----------|----------|
| 1 | `01-TaskList` | Lista de tareas | Agregar, ver, marcar como completadas y eliminar tareas |
| 2 | `02-TipCalculator` | Calculadora de propinas | Calcula la propina y el total según el monto y el porcentaje (10%, 15%, 20% u otro) |
| 3 | `03-PasswordGenerator` | Generador de contraseñas seguras | Genera contraseñas aleatorias con la longitud y los tipos de caracteres elegidos |
| 4 | `04-ExpenseManager` | Gestor de gastos | Registra gastos diarios por categoría y muestra el resumen mensual |
| 5 | `05-ReservationSystem` | Sistema de reservas | Muestra horarios disponibles, crea reservas y permite confirmarlas |
| 6 | `06-NotesManager` | Gestor de notas | Escribe notas, las organiza por categoría, las busca y las elimina |
| 7 | `07-EventCalendar` | Calendario de eventos | Calendario del mes, agregar / editar / eliminar eventos y recordatorios |
| 8 | `08-RecipePlatform` | Plataforma de recetas | Buscar, filtrar por tipo de comida o ingrediente, guardar y compartir recetas |
| 9 | `09-MemoryGame` | Juego de memoria | Emparejar cartas con 3 niveles de dificultad y tabla de puntajes |
| 10 | `10-SurveyPlatform` | Plataforma de encuestas | Crear y responder encuestas, con informe de resultados en barras |
| 11 | `11-OnlineStopwatch` | Cronómetro | Iniciar, pausar, reiniciar y registrar vueltas en tiempo real |

## Cómo ejecutar

1. Abrir el archivo `.sln` del ejercicio en Visual Studio 2022.
2. Presionar **F5** (o el botón verde de ejecutar).

Requisito: .NET 8 SDK.
