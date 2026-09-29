// ============================================================================
// SoundCore Engine v2.0 - DJ Set Controller
// TecNM Campus Monclova - Ingeniería en Informática - Estructura de Datos
// Archivo: Nodo.cs
// Autora: XIMENA SANCHEZ LUGO (Matrícula: I24050392)
// Proyecto individual
// Fecha / Versión: 2026-09-25 / v1.0
// ============================================================================

namespace SoundCore.EstructurasPropias
{
    /// <summary>
    /// Nodo genérico de una lista simplemente enlazada. Solo conoce su valor
    /// y una referencia al siguiente nodo; no existe puntero al anterior.
    /// </summary>
    public class Nodo<T>
    {
        public T Valor { get; set; }
        public Nodo<T>? Siguiente { get; set; }

        public Nodo(T valor)
        {
            Valor = valor;
            Siguiente = null;
        }
    }
}
