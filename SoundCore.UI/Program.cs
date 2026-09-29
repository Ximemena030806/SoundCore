// ============================================================================
// SoundCore Engine v2.0 - DJ Set Controller
// TecNM Campus Monclova - Ingeniería en Informática - Estructura de Datos
// Archivo: Program.cs
// Autora: XIMENA SANCHEZ LUGO (Matrícula: I24050392)
// Proyecto individual
// Fecha / Versión: 2026-09-25 / v1.0
// ============================================================================

namespace SoundCore.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}
