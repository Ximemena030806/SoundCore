# 🎧 SoundCore Engine GUI

**DJ Set Controller** — aplicación de escritorio en C# / WinForms (.NET 8) que implementa una lista enlazada simple **desde cero**, y la compara en vivo contra `LinkedList<T>` y `List<T>` de .NET, tanto en comportamiento como en rendimiento.

Proyecto individual para la materia de **Estructura de Datos** — TecNM Campus Monclova, Ingeniería en Informática.

**Autora:** Ximena Sánchez Lugo — Matrícula I24050392

---

## ¿Qué hace?

SoundCore simula la cola de reproducción de un DJ. Permite capturar canciones (título, artista, BPM, duración) o **importar música real de tu computadora**, y manipular esa cola con seis operaciones clásicas de listas enlazadas — todo mientras eliges, con un simple radio button, cuál de tres estructuras de datos quieres usar por debajo:

| Modo | Estructura |
|---|---|
| **Lista Simple Propia** | Implementación propia con `Nodo<T>` y punteros, sin usar `List`/`LinkedList` internamente |
| **`.NET LinkedList<T>`** | Lista doblemente enlazada nativa de .NET |
| **`.NET List<T>`** | Arreglo dinámico nativo de .NET |

### Operaciones sobre la cola

- **➕ Encolar al Final** — agrega una pista al final de la cola (`O(n)` en la lista propia).
- **⏭ Reproducir Siguiente ("Up Next")** — inserta una pista justo después de la que está sonando (`O(1)`).
- **⏩ Avanzar Pista** — saca la pista actual de la cola (la "reproduce") y pasa a la siguiente.
- **⇅ Invertir Lista** — invierte el orden de la cola **in-place**, redirigiendo únicamente los punteros `Siguiente` (sin crear listas auxiliares).
- **⚡ Ordenar por Curva BPM** — reordena la cola de menor a mayor BPM, para armar una transición de tempo suave.
- **🧹 Purgar Duplicados** — elimina pistas repetidas (mismo título) sin usar estructuras auxiliares externas.

### Reproducción de audio real

- **📂 Importar Carpeta de Música** — escanea una carpeta de tu equipo (mp3, wav, wma, m4a, aac, flac) y agrega cada archivo como pista real a la cola, junto con las que ya hayas capturado a mano.
- **Doble clic en una fila del grid** — reproduce esa pista, sin sacarla de la cola (vista previa).
- El audio se reproduce **dentro del propio programa** mediante `winmm.dll` (la API multimedia de Windows, vía P/Invoke) — no se abre ninguna aplicación externa (ni Windows Media Player, ni iTunes) y no se usa ningún paquete NuGet ni librería de terceros.
- Cuando una pista termina de sonar sola, la cola **avanza automáticamente** a la siguiente (Windows notifica al programa con el mensaje `MM_MCINOTIFY`).

### Simulación de carga masiva / benchmark

El panel inferior mide cuánto tarda cada una de las tres estructuras en resolver miles de inserciones intermedias (tipo "Up Next"), y opcionalmente agrega esas mismas pistas simuladas a tu cola real, para poder ver cómo se comporta la interfaz con un volumen de datos grande.

---

## Cómo ejecutarlo

1. Requiere **Visual Studio 2022** (o más reciente) con el workload de desarrollo de escritorio de .NET, y el **SDK de .NET 8**.
2. Abre `SoundCore.sln`.
3. Verifica que **`SoundCore.UI`** esté marcado como proyecto de inicio (clic derecho sobre él → *Establecer como proyecto de inicio*).
4. Presiona `F5`.

---

## Arquitectura del proyecto

```
SoundCore.sln
├── SoundCore.Modelos/              → Modelo de datos
│   └── Pista.cs                    → record inmutable (Id, Título, Artista, BPM, Duración, RutaArchivo)
├── SoundCore.EstructurasPropias/   → Estructura de datos propia
│   ├── Nodo.cs                     → nodo genérico con puntero Siguiente
│   └── ListaSimpleEnlazada.cs      → lista enlazada construida a mano sobre punteros
└── SoundCore.UI/                   → Interfaz WinForms
    ├── Program.cs                  → punto de entrada
    ├── MainForm.cs / .Designer.cs  → lógica y layout de la ventana principal
    └── ReproductorMci.cs           → wrapper de winmm.dll para audio embebido
```

La regla de oro del proyecto: **`ListaSimpleEnlazada<T>` no usa `List<T>`, `LinkedList<T>` ni ninguna otra colección de la BCL por debajo** — todas sus operaciones trabajan directamente sobre `Nodo<T>.Siguiente`.

---

## Documentación adicional

- [`ENUNCIADO-ORIGINAL.md`](./ENUNCIADO-ORIGINAL.md) — especificación completa del proyecto entregada por el maestro (requisitos, rúbrica, casos de prueba).
- Video demostrativo: *(agrega aquí el link de YouTube una vez subido)*
