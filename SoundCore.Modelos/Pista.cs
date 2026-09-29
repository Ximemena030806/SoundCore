// ============================================================================
// SoundCore Engine v2.0 - DJ Set Controller
// TecNM Campus Monclova - Ingeniería en Informática - Estructura de Datos
// Archivo: Pista.cs
// Autora: XIMENA SANCHEZ LUGO (Matrícula: I24050392)
// Proyecto individual
// Fecha / Versión: 2026-09-25 / v1.0
// ============================================================================

using System.IO;

namespace SoundCore.Modelos
{
    /// <summary>
    /// Representa una pista musical dentro del set del DJ.
    /// Es un record inmutable: cada operación de "edición" crea una copia nueva,
    /// lo cual es seguro para compartir la misma instancia entre las tres
    /// estructuras que se comparan en paralelo (propia, LinkedList y List).
    /// </summary>
    public record Pista(int Id, string Titulo, string Artista, int Bpm, int DuracionSegundos, string? RutaArchivo = null)
    {
        /// <summary>Indica si esta pista tiene un archivo de audio real asociado (importado de disco).</summary>
        public bool TieneAudioReal => !string.IsNullOrEmpty(RutaArchivo) && File.Exists(RutaArchivo);

        public override string ToString() =>
            $"[ID: {Id:D3}] {Titulo} - {Artista} | {Bpm} BPM ({DuracionSegundos}s)";
    }
}
