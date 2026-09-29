// ============================================================================
// SoundCore Engine v2.0 - DJ Set Controller
// TecNM Campus Monclova - Ingeniería en Informática - Estructura de Datos
// Archivo: MainForm.cs
// Autora: XIMENA SANCHEZ LUGO (Matrícula: I24050392)
// Proyecto individual
// Fecha / Versión: 2026-09-25 / v1.0
// ============================================================================

using System.Diagnostics;
using System.IO;
using SoundCore.EstructurasPropias;
using SoundCore.Modelos;

namespace SoundCore.UI
{
    public partial class MainForm : Form
    {
        // Estructuras paralelas: las tres se mantienen sincronizadas con el
        // mismo contenido, cada una respaldada por su propia implementación.
        private readonly ListaSimpleEnlazada<Pista> _colaPropia = new();
        private readonly LinkedList<Pista> _colaLinkedList = new();
        private readonly List<Pista> _colaList = new();

        private int _contadorId = 1;
        private Pista? _pistaSonando;

        public MainForm()
        {
            InitializeComponent();
            ConfigurarColumnasGrid();
            CargarDatosSemilla();
            RefrescarVista();
        }

        private void ConfigurarColumnasGrid()
        {
            dgvCola.ColumnCount = 5;
            dgvCola.Columns[0].Name = "Pos";
            dgvCola.Columns[1].Name = "ID";
            dgvCola.Columns[2].Name = "Título / Artista";
            dgvCola.Columns[3].Name = "BPM";
            dgvCola.Columns[4].Name = "Duración";
        }

        private void CargarDatosSemilla()
        {
            var demo = new[]
            {
                new Pista(_contadorId++, "Strobe", "deadmau5", 128, 634),
                new Pista(_contadorId++, "Midnight City", "M83", 105, 243),
                new Pista(_contadorId++, "Animals", "Martin Garrix", 130, 304)
            };

            foreach (var p in demo)
            {
                _colaPropia.AgregarAlFinal(p);
                _colaLinkedList.AddLast(p);
                _colaList.Add(p);
            }
        }

        private Pista? CrearPistaDesdeFormulario()
        {
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El título de la pista es obligatorio.", "Datos incompletos",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitulo.Focus();
                return null;
            }

            string titulo = txtTitulo.Text.Trim();
            string artista = string.IsNullOrWhiteSpace(txtArtista.Text) ? "DJ Desconocido" : txtArtista.Text.Trim();
            int bpm = (int)numBpm.Value;
            int duracion = (int)numDuracion.Value;

            return new Pista(_contadorId++, titulo, artista, bpm, duracion);
        }

        /// <summary>
        /// Reproduce el archivo de audio real asociado a la pista (si lo tiene) DENTRO del
        /// propio programa, usando winmm.dll (sin abrir ninguna aplicación externa).
        /// </summary>
        private void ReproducirArchivoSiActivo(Pista? pista)
        {
            if (pista is null || !pista.TieneAudioReal)
            {
                ReproductorMci.Detener();
                return;
            }

            ReproductorMci.Reproducir(pista.RutaArchivo!, this.Handle);
        }

        /// <summary>
        /// Windows notifica aquí (mensaje MM_MCINOTIFY) cuando una pista termina de
        /// reproducirse por sí sola, para poder avanzar automáticamente la cola.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            const int MM_MCINOTIFY = 0x3B9;
            const int MCI_NOTIFY_SUCCESSFUL = 1;

            if (m.Msg == MM_MCINOTIFY && m.WParam.ToInt32() == MCI_NOTIFY_SUCCESSFUL)
            {
                AvanzarPistaInterna(mostrarAvisoSiVacia: false);
            }

            base.WndProc(ref m);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            ReproductorMci.Detener();
            base.OnFormClosing(e);
        }

        private void btnEncolarFinal_Click(object sender, EventArgs e)
        {
            var pista = CrearPistaDesdeFormulario();
            if (pista is null) return;

            if (rbPropia.Checked) _colaPropia.AgregarAlFinal(pista);
            else if (rbLinkedList.Checked) _colaLinkedList.AddLast(pista);
            else _colaList.Add(pista);

            LimpiarFormularioEntrada();
            RefrescarVista();
        }

        private void btnReproducirSiguiente_Click(object sender, EventArgs e)
        {
            var pista = CrearPistaDesdeFormulario();
            if (pista is null) return;

            if (rbPropia.Checked)
            {
                _colaPropia.ReproducirSiguiente(pista);
            }
            else if (rbLinkedList.Checked)
            {
                if (_colaLinkedList.First == null)
                    _colaLinkedList.AddFirst(pista);
                else
                    _colaLinkedList.AddAfter(_colaLinkedList.First, pista);
            }
            else
            {
                if (_colaList.Count <= 1) _colaList.Add(pista);
                else _colaList.Insert(1, pista);
            }

            LimpiarFormularioEntrada();
            RefrescarVista();
        }

        private void btnAvanzar_Click(object sender, EventArgs e)
        {
            AvanzarPistaInterna(mostrarAvisoSiVacia: true);
        }

        /// <summary>
        /// Lógica compartida de "avanzar pista": la usa tanto el botón como el auto-avance
        /// que dispara WndProc cuando una canción termina sola.
        /// </summary>
        private void AvanzarPistaInterna(bool mostrarAvisoSiVacia)
        {
            try
            {
                if (rbPropia.Checked)
                {
                    _pistaSonando = _colaPropia.AvanzarPista();
                }
                else if (rbLinkedList.Checked)
                {
                    if (_colaLinkedList.First == null) throw new InvalidOperationException();
                    _pistaSonando = _colaLinkedList.First.Value;
                    _colaLinkedList.RemoveFirst();
                }
                else
                {
                    if (_colaList.Count == 0) throw new InvalidOperationException();
                    _pistaSonando = _colaList[0];
                    _colaList.RemoveAt(0);
                }

                lblNowPlaying.Text = $"▶ Sonando: {_pistaSonando!.Titulo} - {_pistaSonando.Artista} ({_pistaSonando.Bpm} BPM)";
                lblNowPlaying.ForeColor = Color.DarkGreen;
                ReproducirArchivoSiActivo(_pistaSonando);
                RefrescarVista();
            }
            catch (InvalidOperationException)
            {
                ReproductorMci.Detener();
                lblNowPlaying.Text = "Estado Actual: (fin del setlist)";
                lblNowPlaying.ForeColor = Color.Black;

                if (mostrarAvisoSiVacia)
                {
                    MessageBox.Show("No hay pistas pendientes en la cola.", "Fin del Setlist",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnInvertir_Click(object sender, EventArgs e)
        {
            if (rbPropia.Checked)
            {
                // Inversión estrictamente in-place sobre los punteros Siguiente.
                _colaPropia.Invertir();
            }
            else if (rbLinkedList.Checked)
            {
                var listaTemporal = new List<Pista>(_colaLinkedList);
                listaTemporal.Reverse();
                _colaLinkedList.Clear();
                foreach (var item in listaTemporal) _colaLinkedList.AddLast(item);
            }
            else
            {
                _colaList.Reverse();
            }

            RefrescarVista();
        }

        private void btnOrdenarBpm_Click(object sender, EventArgs e)
        {
            if (rbPropia.Checked)
            {
                var temporal = new ListaSimpleEnlazada<Pista>();
                foreach (var pista in _colaPropia)
                {
                    temporal.InsertarOrdenado(pista, (a, b) => a.Bpm.CompareTo(b.Bpm));
                }
                _colaPropia.Limpiar();
                foreach (var p in temporal) _colaPropia.AgregarAlFinal(p);
            }
            else if (rbLinkedList.Checked)
            {
                var ordenadas = _colaLinkedList.OrderBy(p => p.Bpm).ToList();
                _colaLinkedList.Clear();
                foreach (var p in ordenadas) _colaLinkedList.AddLast(p);
            }
            else
            {
                _colaList.Sort((a, b) => a.Bpm.CompareTo(b.Bpm));
            }

            RefrescarVista();
        }

        private void btnPurgar_Click(object sender, EventArgs e)
        {
            if (rbPropia.Checked)
            {
                _colaPropia.DepurarDuplicados((a, b) => a.Titulo.Equals(b.Titulo, StringComparison.OrdinalIgnoreCase));
            }
            else if (rbLinkedList.Checked)
            {
                var unicos = _colaLinkedList.DistinctBy(p => p.Titulo).ToList();
                _colaLinkedList.Clear();
                foreach (var p in unicos) _colaLinkedList.AddLast(p);
            }
            else
            {
                var unicos = _colaList.DistinctBy(p => p.Titulo).ToList();
                _colaList.Clear();
                _colaList.AddRange(unicos);
            }

            RefrescarVista();
        }

        private void LimpiarFormularioEntrada()
        {
            txtTitulo.Clear();
            txtArtista.Clear();
            numBpm.Value = 124;
            numDuracion.Value = 210;
            txtTitulo.Focus();
        }

        /// <summary>
        /// Abre un explorador de carpetas, busca archivos de audio (mp3, wav, wma, m4a, aac, flac)
        /// y los agrega como pistas reales a la cola activa (modo seleccionado arriba), conservando
        /// las pistas que ya tenías capturadas.
        /// </summary>
        private void btnImportarCarpeta_Click(object sender, EventArgs e)
        {
            using var dialogo = new FolderBrowserDialog
            {
                Description = "Selecciona la carpeta donde tienes tu música"
            };

            if (dialogo.ShowDialog() != DialogResult.OK) return;

            string[] extensionesValidas = { ".mp3", ".wav", ".wma", ".m4a", ".aac", ".flac" };
            var archivos = Directory.EnumerateFiles(dialogo.SelectedPath, "*.*", SearchOption.TopDirectoryOnly)
                .Where(ruta => extensionesValidas.Contains(Path.GetExtension(ruta).ToLowerInvariant()))
                .OrderBy(ruta => ruta)
                .ToList();

            if (archivos.Count == 0)
            {
                MessageBox.Show("No se encontraron archivos de audio compatibles (mp3, wav, wma, m4a, aac, flac) en esa carpeta.",
                    "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var ruta in archivos)
            {
                string titulo = Path.GetFileNameWithoutExtension(ruta);
                // BPM y duración no se pueden leer sin una librería de metadatos, así que se
                // usan valores por defecto editables: el usuario puede reordenar con "Ordenar por BPM"
                // una vez que ajuste el valor manualmente si lo desea.
                var pista = new Pista(_contadorId++, titulo, "Mi Música", 120, 210, ruta);

                if (rbPropia.Checked) _colaPropia.AgregarAlFinal(pista);
                else if (rbLinkedList.Checked) _colaLinkedList.AddLast(pista);
                else _colaList.Add(pista);
            }

            lblCarpetaMusica.Text = $"Carpeta: {dialogo.SelectedPath}  ({archivos.Count} pista(s) importada(s))";
            RefrescarVista();

            MessageBox.Show($"Se importaron {archivos.Count} pista(s) de audio real desde:\n{dialogo.SelectedPath}",
                "Importación completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Doble clic sobre una fila del grid: reproduce esa pista sin sacarla de la cola
        /// (una vista previa), a diferencia de "Avanzar Pista" que sí la desencola.
        /// </summary>
        private void dgvCola_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            var celdaId = dgvCola.Rows[e.RowIndex].Cells[1].Value;
            if (celdaId is null || !int.TryParse(celdaId.ToString(), out int id)) return;

            IEnumerable<Pista> coleccion = rbPropia.Checked ? _colaPropia :
                                           rbLinkedList.Checked ? _colaLinkedList : _colaList;
            var pista = coleccion.FirstOrDefault(p => p.Id == id);
            if (pista is null) return;

            if (!pista.TieneAudioReal)
            {
                MessageBox.Show("Esta pista no tiene un archivo de audio real asociado (fue capturada manualmente o simulada). " +
                    "Usa \"Importar Carpeta de Música\" para agregar pistas reproducibles.",
                    "Sin audio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            lblNowPlaying.Text = $"👂 Vista previa: {pista.Titulo} - {pista.Artista} ({pista.Bpm} BPM)";
            lblNowPlaying.ForeColor = Color.SteelBlue;
            ReproducirArchivoSiActivo(pista);
        }

        private void btnDetener_Click(object sender, EventArgs e)
        {
            ReproductorMci.Detener();
            lblNowPlaying.Text = "Estado Actual: (reproducción detenida)";
            lblNowPlaying.ForeColor = Color.Black;
        }

        private void RefrescarVista()
        {
            // Con miles de filas (p. ej. tras la simulación de 25,000 pistas),
            // agregar una por una con Rows.Add es muy lento porque recalcula el
            // layout en cada llamada. AddRange + Suspend/ResumeLayout lo hace en un solo lote.
            dgvCola.SuspendLayout();
            dgvCola.Rows.Clear();

            IEnumerable<Pista> coleccion = rbPropia.Checked ? _colaPropia :
                                           rbLinkedList.Checked ? _colaLinkedList : _colaList;

            var filas = new List<DataGridViewRow>();
            int index = 1;
            int duracionTotal = 0;

            foreach (var p in coleccion)
            {
                var fila = new DataGridViewRow();
                fila.CreateCells(dgvCola, index, p.Id, $"{p.Titulo} — {p.Artista}", $"{p.Bpm} BPM", $"{p.DuracionSegundos}s");
                filas.Add(fila);
                index++;
                duracionTotal += p.DuracionSegundos;
            }

            dgvCola.Rows.AddRange(filas.ToArray());
            dgvCola.ResumeLayout();

            lblEstadisticas.Text = $"Total en cola: {index - 1} pista(s) | Tiempo total: {TimeSpan.FromSeconds(duracionTotal):mm\\:ss}";
        }

        private void btnBenchmark_Click(object sender, EventArgs e)
        {
            int n = (int)numCantidadPrueba.Value;
            var random = new Random(42);
            var sw = new Stopwatch();

            // 1. Test de inserción intermedia ("Up Next"): Lista Propia -> O(1) por reconexión de punteros
            var testPropia = new ListaSimpleEnlazada<Pista>();
            testPropia.AgregarAlFinal(new Pista(0, "Head", "DJ", 120, 200));
            sw.Start();
            for (int i = 0; i < n; i++)
            {
                testPropia.ReproducirSiguiente(new Pista(i, $"Pista {i}", "DJ", random.Next(100, 150), 180));
            }
            sw.Stop();
            long tiempoPropia = sw.ElapsedMilliseconds;

            // 2. Test de inserción intermedia: .NET LinkedList<T> -> O(1) con AddAfter
            var testLinkedList = new LinkedList<Pista>();
            testLinkedList.AddLast(new Pista(0, "Head", "DJ", 120, 200));
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                testLinkedList.AddAfter(testLinkedList.First!, new Pista(i, $"Pista {i}", "DJ", random.Next(100, 150), 180));
            }
            sw.Stop();
            long tiempoLinkedList = sw.ElapsedMilliseconds;

            // 3. Test de inserción intermedia: .NET List<T> -> O(n) por Array.Copy en cada Insert
            var testList = new List<Pista> { new Pista(0, "Head", "DJ", 120, 200) };
            sw.Restart();
            for (int i = 0; i < n; i++)
            {
                testList.Insert(1, new Pista(i, $"Pista {i}", "DJ", random.Next(100, 150), 180));
            }
            sw.Stop();
            long tiempoList = sw.ElapsedMilliseconds;

            string resumen =
                $"=== RESULTADOS DE ESTRÉS ({n:N0} INSERCIONES INTERMEDIAS) ===\r\n" +
                $"• Lista Enlazada Propia (Nodos):    {tiempoPropia,6} ms  [Reconexión O(1) de Nodo<T>.Siguiente]\r\n" +
                $"• .NET LinkedList<T>:                {tiempoLinkedList,6} ms  [AddAfter O(1), nodos doblemente enlazados]\r\n" +
                $"• .NET List<T> (Arreglo Dinámico):   {tiempoList,6} ms  [Insert(idx) O(n) por Array.Copy]\r\n\r\n" +
                $"Conclusión Técnica: en inserciones intermedias frecuentes, ambas listas enlazadas superan a " +
                $"List<T> porque solo redirigen referencias en memoria, sin desplazar ni copiar el resto del " +
                $"arreglo subyacente (Array.Copy / reasignación de búfer).";

            // Además de medir tiempos en estructuras temporales, si el usuario lo pidió,
            // las mismas n pistas simuladas se insertan en la cola REAL (modo seleccionado
            // arriba), sumándose a las que el usuario ya haya capturado a mano.
            if (chkCargarEnCola.Checked)
            {
                int totalAntes = rbPropia.Checked ? _colaPropia.Conteo :
                                  rbLinkedList.Checked ? _colaLinkedList.Count : _colaList.Count;

                var randomVisual = new Random(7);
                for (int i = 0; i < n; i++)
                {
                    var pistaSimulada = new Pista(_contadorId++, $"Pista Simulada {i + 1}", "Simulador de Carga",
                        randomVisual.Next(90, 180), randomVisual.Next(120, 360));

                    if (rbPropia.Checked)
                    {
                        _colaPropia.ReproducirSiguiente(pistaSimulada);
                    }
                    else if (rbLinkedList.Checked)
                    {
                        if (_colaLinkedList.First == null) _colaLinkedList.AddFirst(pistaSimulada);
                        else _colaLinkedList.AddAfter(_colaLinkedList.First, pistaSimulada);
                    }
                    else
                    {
                        if (_colaList.Count <= 1) _colaList.Add(pistaSimulada);
                        else _colaList.Insert(1, pistaSimulada);
                    }
                }

                int totalDespues = rbPropia.Checked ? _colaPropia.Conteo :
                                    rbLinkedList.Checked ? _colaLinkedList.Count : _colaList.Count;

                resumen += $"\r\n\r\nCola actual actualizada: tenías {totalAntes:N0} pista(s); se agregaron {n:N0} " +
                           $"simuladas, ahora hay {totalDespues:N0} pista(s) en total (visibles en el grid de arriba).";

                RefrescarVista();
            }

            txtResultadosBenchmark.Text = resumen;
        }
    }
}
