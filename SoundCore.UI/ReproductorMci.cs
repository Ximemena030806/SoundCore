// ============================================================================
// SoundCore Engine v2.0 - DJ Set Controller
// TecNM Campus Monclova - Ingeniería en Informática - Estructura de Datos
// Archivo: ReproductorMci.cs
// Autora: XIMENA SANCHEZ LUGO (Matrícula: I24050392)
// Proyecto individual
// Fecha / Versión: 2026-09-25 / v1.0
//
// Reproducción de audio real (mp3/wav/wma) EMBEBIDA dentro del programa,
// SIN abrir ninguna aplicación externa (ni Windows Media Player, ni iTunes)
// y SIN librerías externas ni paquetes NuGet: se invoca directamente
// winmm.dll (Windows Multimedia API), presente en cualquier instalación de
// Windows, mediante P/Invoke y el comando clásico mciSendString. El sonido
// se reproduce por el mezclador de audio del sistema de forma invisible;
// no se abre ninguna ventana ni proceso adicional.
// ============================================================================

using System.Runtime.InteropServices;
using System.Text;

namespace SoundCore.UI
{
    internal static class ReproductorMci
    {
        [DllImport("winmm.dll", CharSet = CharSet.Auto)]
        private static extern int mciSendString(string comando, StringBuilder? buffer, int tamanoBuffer, IntPtr hwndNotificacion);

        private const string Alias = "SoundCoreAudio";

        /// <summary>
        /// Abre y reproduce el archivo indicado dentro del propio programa (sin ventana externa).
        /// Si se pasa un handle de ventana (hwndNotificacion), Windows enviará el mensaje
        /// MM_MCINOTIFY a esa ventana cuando la pista termine sola, lo que permite
        /// implementar el auto-avance de la cola.
        /// </summary>
        public static void Reproducir(string rutaArchivo, IntPtr hwndNotificacion)
        {
            Detener();
            mciSendString($"open \"{rutaArchivo}\" alias {Alias}", null, 0, IntPtr.Zero);
            mciSendString($"play {Alias} notify", null, 0, hwndNotificacion);
        }

        public static void Detener()
        {
            mciSendString($"stop {Alias}", null, 0, IntPtr.Zero);
            mciSendString($"close {Alias}", null, 0, IntPtr.Zero);
        }
    }
}
