// ============================================================================
// SoundCore Engine v2.0 - DJ Set Controller
// TecNM Campus Monclova - Ingeniería en Informática - Estructura de Datos
// Archivo: MainForm.Designer.cs (código generado por el diseñador)
// Autora: XIMENA SANCHEZ LUGO (Matrícula: I24050392)
// Proyecto individual
// ============================================================================

#nullable disable

namespace SoundCore.UI
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        // --- Panel superior: registro de pista ---
        private System.Windows.Forms.Panel pnlRegistro;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtTitulo;
        private System.Windows.Forms.Label lblArtista;
        private System.Windows.Forms.TextBox txtArtista;
        private System.Windows.Forms.Label lblBpm;
        private System.Windows.Forms.NumericUpDown numBpm;
        private System.Windows.Forms.Label lblDuracion;
        private System.Windows.Forms.NumericUpDown numDuracion;
        private System.Windows.Forms.Label lblModoEstructura;
        private System.Windows.Forms.RadioButton rbPropia;
        private System.Windows.Forms.RadioButton rbLinkedList;
        private System.Windows.Forms.RadioButton rbList;
        private System.Windows.Forms.Button btnImportarCarpeta;
        private System.Windows.Forms.Label lblCarpetaMusica;

        // --- Panel izquierdo: acciones de cola ---
        private System.Windows.Forms.Panel pnlAcciones;
        private System.Windows.Forms.Button btnEncolarFinal;
        private System.Windows.Forms.Button btnReproducirSiguiente;
        private System.Windows.Forms.Button btnAvanzar;
        private System.Windows.Forms.Button btnInvertir;
        private System.Windows.Forms.Button btnOrdenarBpm;
        private System.Windows.Forms.Button btnPurgar;
        private System.Windows.Forms.Button btnDetener;

        // --- Panel derecho: playlist visual / cola en vivo ---
        private System.Windows.Forms.Panel pnlPlaylist;
        private System.Windows.Forms.Label lblNowPlaying;
        private System.Windows.Forms.DataGridView dgvCola;
        private System.Windows.Forms.Label lblEstadisticas;

        // --- Panel inferior: benchmark y telemetría ---
        private System.Windows.Forms.Panel pnlBenchmark;
        private System.Windows.Forms.Label lblCantidadPrueba;
        private System.Windows.Forms.NumericUpDown numCantidadPrueba;
        private System.Windows.Forms.Button btnBenchmark;
        private System.Windows.Forms.CheckBox chkCargarEnCola;
        private System.Windows.Forms.TextBox txtResultadosBenchmark;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlRegistro = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtTitulo = new System.Windows.Forms.TextBox();
            this.lblArtista = new System.Windows.Forms.Label();
            this.txtArtista = new System.Windows.Forms.TextBox();
            this.lblBpm = new System.Windows.Forms.Label();
            this.numBpm = new System.Windows.Forms.NumericUpDown();
            this.lblDuracion = new System.Windows.Forms.Label();
            this.numDuracion = new System.Windows.Forms.NumericUpDown();
            this.lblModoEstructura = new System.Windows.Forms.Label();
            this.rbPropia = new System.Windows.Forms.RadioButton();
            this.rbLinkedList = new System.Windows.Forms.RadioButton();
            this.rbList = new System.Windows.Forms.RadioButton();
            this.btnImportarCarpeta = new System.Windows.Forms.Button();
            this.lblCarpetaMusica = new System.Windows.Forms.Label();

            this.pnlAcciones = new System.Windows.Forms.Panel();
            this.btnEncolarFinal = new System.Windows.Forms.Button();
            this.btnReproducirSiguiente = new System.Windows.Forms.Button();
            this.btnAvanzar = new System.Windows.Forms.Button();
            this.btnInvertir = new System.Windows.Forms.Button();
            this.btnOrdenarBpm = new System.Windows.Forms.Button();
            this.btnPurgar = new System.Windows.Forms.Button();
            this.btnDetener = new System.Windows.Forms.Button();

            this.pnlPlaylist = new System.Windows.Forms.Panel();
            this.lblNowPlaying = new System.Windows.Forms.Label();
            this.dgvCola = new System.Windows.Forms.DataGridView();
            this.lblEstadisticas = new System.Windows.Forms.Label();

            this.pnlBenchmark = new System.Windows.Forms.Panel();
            this.lblCantidadPrueba = new System.Windows.Forms.Label();
            this.numCantidadPrueba = new System.Windows.Forms.NumericUpDown();
            this.btnBenchmark = new System.Windows.Forms.Button();
            this.chkCargarEnCola = new System.Windows.Forms.CheckBox();
            this.txtResultadosBenchmark = new System.Windows.Forms.TextBox();

            ((System.ComponentModel.ISupportInitialize)(this.numBpm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuracion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCola)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadPrueba)).BeginInit();
            this.SuspendLayout();

            // ---------------------------------------------------------------
            // pnlRegistro (PANEL SUPERIOR)
            // ---------------------------------------------------------------
            this.pnlRegistro.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlRegistro.Height = 130;
            this.pnlRegistro.Padding = new System.Windows.Forms.Padding(12);
            this.pnlRegistro.Controls.Add(this.lblTitulo);
            this.pnlRegistro.Controls.Add(this.txtTitulo);
            this.pnlRegistro.Controls.Add(this.lblArtista);
            this.pnlRegistro.Controls.Add(this.txtArtista);
            this.pnlRegistro.Controls.Add(this.lblBpm);
            this.pnlRegistro.Controls.Add(this.numBpm);
            this.pnlRegistro.Controls.Add(this.lblDuracion);
            this.pnlRegistro.Controls.Add(this.numDuracion);
            this.pnlRegistro.Controls.Add(this.lblModoEstructura);
            this.pnlRegistro.Controls.Add(this.rbPropia);
            this.pnlRegistro.Controls.Add(this.rbLinkedList);
            this.pnlRegistro.Controls.Add(this.rbList);
            this.pnlRegistro.Controls.Add(this.btnImportarCarpeta);
            this.pnlRegistro.Controls.Add(this.lblCarpetaMusica);

            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Location = new System.Drawing.Point(15, 18);
            this.lblTitulo.Text = "Título:";

            this.txtTitulo.Location = new System.Drawing.Point(65, 15);
            this.txtTitulo.Size = new System.Drawing.Size(180, 23);

            this.lblArtista.AutoSize = true;
            this.lblArtista.Location = new System.Drawing.Point(260, 18);
            this.lblArtista.Text = "Artista:";

            this.txtArtista.Location = new System.Drawing.Point(315, 15);
            this.txtArtista.Size = new System.Drawing.Size(180, 23);

            this.lblBpm.AutoSize = true;
            this.lblBpm.Location = new System.Drawing.Point(510, 18);
            this.lblBpm.Text = "BPM:";

            this.numBpm.Location = new System.Drawing.Point(555, 15);
            this.numBpm.Size = new System.Drawing.Size(70, 23);
            this.numBpm.Minimum = 60;
            this.numBpm.Maximum = 220;
            this.numBpm.Value = 124;

            this.lblDuracion.AutoSize = true;
            this.lblDuracion.Location = new System.Drawing.Point(640, 18);
            this.lblDuracion.Text = "Duración (s):";

            this.numDuracion.Location = new System.Drawing.Point(725, 15);
            this.numDuracion.Size = new System.Drawing.Size(80, 23);
            this.numDuracion.Minimum = 1;
            this.numDuracion.Maximum = 3600;
            this.numDuracion.Value = 210;

            this.lblModoEstructura.AutoSize = true;
            this.lblModoEstructura.Location = new System.Drawing.Point(15, 58);
            this.lblModoEstructura.Text = "Modo de Estructura:";

            this.rbPropia.AutoSize = true;
            this.rbPropia.Checked = true;
            this.rbPropia.TabStop = true;
            this.rbPropia.Location = new System.Drawing.Point(160, 57);
            this.rbPropia.Text = "Lista Simple Propia (Nodos)";

            this.rbLinkedList.AutoSize = true;
            this.rbLinkedList.Location = new System.Drawing.Point(380, 57);
            this.rbLinkedList.Text = ".NET LinkedList<T>";

            this.rbList.AutoSize = true;
            this.rbList.Location = new System.Drawing.Point(540, 57);
            this.rbList.Text = ".NET List<T>";

            this.btnImportarCarpeta.Location = new System.Drawing.Point(15, 90);
            this.btnImportarCarpeta.Size = new System.Drawing.Size(240, 30);
            this.btnImportarCarpeta.Text = "📂 Importar Carpeta de Música";
            this.btnImportarCarpeta.UseVisualStyleBackColor = true;
            this.btnImportarCarpeta.Click += new System.EventHandler(this.btnImportarCarpeta_Click);

            this.lblCarpetaMusica.AutoSize = true;
            this.lblCarpetaMusica.Location = new System.Drawing.Point(265, 98);
            this.lblCarpetaMusica.ForeColor = System.Drawing.Color.DimGray;
            this.lblCarpetaMusica.Text = "Ninguna carpeta importada todavía (doble clic en una fila del grid reproduce esa pista).";

            // ---------------------------------------------------------------
            // pnlAcciones (ACCIONES DE COLA)
            // ---------------------------------------------------------------
            this.pnlAcciones.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlAcciones.Width = 230;
            this.pnlAcciones.Padding = new System.Windows.Forms.Padding(12);
            this.pnlAcciones.Controls.Add(this.btnEncolarFinal);
            this.pnlAcciones.Controls.Add(this.btnReproducirSiguiente);
            this.pnlAcciones.Controls.Add(this.btnAvanzar);
            this.pnlAcciones.Controls.Add(this.btnInvertir);
            this.pnlAcciones.Controls.Add(this.btnOrdenarBpm);
            this.pnlAcciones.Controls.Add(this.btnPurgar);
            this.pnlAcciones.Controls.Add(this.btnDetener);

            this.btnEncolarFinal.Location = new System.Drawing.Point(15, 15);
            this.btnEncolarFinal.Size = new System.Drawing.Size(195, 36);
            this.btnEncolarFinal.Text = "+ Encolar al Final";
            this.btnEncolarFinal.UseVisualStyleBackColor = true;
            this.btnEncolarFinal.Click += new System.EventHandler(this.btnEncolarFinal_Click);

            this.btnReproducirSiguiente.Location = new System.Drawing.Point(15, 60);
            this.btnReproducirSiguiente.Size = new System.Drawing.Size(195, 36);
            this.btnReproducirSiguiente.Text = "⏭ Reproducir Siguiente";
            this.btnReproducirSiguiente.UseVisualStyleBackColor = true;
            this.btnReproducirSiguiente.Click += new System.EventHandler(this.btnReproducirSiguiente_Click);

            this.btnAvanzar.Location = new System.Drawing.Point(15, 105);
            this.btnAvanzar.Size = new System.Drawing.Size(195, 36);
            this.btnAvanzar.Text = "⏩ Avanzar Pista";
            this.btnAvanzar.UseVisualStyleBackColor = true;
            this.btnAvanzar.Click += new System.EventHandler(this.btnAvanzar_Click);

            this.btnInvertir.Location = new System.Drawing.Point(15, 150);
            this.btnInvertir.Size = new System.Drawing.Size(195, 36);
            this.btnInvertir.Text = "⇅ Invertir Lista (In-Place)";
            this.btnInvertir.UseVisualStyleBackColor = true;
            this.btnInvertir.Click += new System.EventHandler(this.btnInvertir_Click);

            this.btnOrdenarBpm.Location = new System.Drawing.Point(15, 195);
            this.btnOrdenarBpm.Size = new System.Drawing.Size(195, 36);
            this.btnOrdenarBpm.Text = "⚡ Ordenar por Curva BPM";
            this.btnOrdenarBpm.UseVisualStyleBackColor = true;
            this.btnOrdenarBpm.Click += new System.EventHandler(this.btnOrdenarBpm_Click);

            this.btnPurgar.Location = new System.Drawing.Point(15, 240);
            this.btnPurgar.Size = new System.Drawing.Size(195, 36);
            this.btnPurgar.Text = "🧹 Purgar Duplicados";
            this.btnPurgar.UseVisualStyleBackColor = true;
            this.btnPurgar.Click += new System.EventHandler(this.btnPurgar_Click);

            this.btnDetener.Location = new System.Drawing.Point(15, 290);
            this.btnDetener.Size = new System.Drawing.Size(195, 36);
            this.btnDetener.Text = "⏹ Detener Reproducción";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);

            // ---------------------------------------------------------------
            // pnlPlaylist (PLAYLIST VISUAL / COLA EN VIVO)
            // ---------------------------------------------------------------
            this.pnlPlaylist.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPlaylist.Padding = new System.Windows.Forms.Padding(12);
            this.pnlPlaylist.Controls.Add(this.dgvCola);
            this.pnlPlaylist.Controls.Add(this.lblEstadisticas);
            this.pnlPlaylist.Controls.Add(this.lblNowPlaying);

            this.lblNowPlaying.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblNowPlaying.Height = 32;
            this.lblNowPlaying.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblNowPlaying.Text = "Estado Actual: (sin reproducción)";
            this.lblNowPlaying.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.lblEstadisticas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblEstadisticas.Height = 26;
            this.lblEstadisticas.Text = "Total en cola: 0 | Tiempo total: 00:00";
            this.lblEstadisticas.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            this.dgvCola.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCola.AllowUserToAddRows = false;
            this.dgvCola.AllowUserToDeleteRows = false;
            this.dgvCola.ReadOnly = true;
            this.dgvCola.RowHeadersVisible = false;
            this.dgvCola.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCola.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCola.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCola_CellDoubleClick);

            // ---------------------------------------------------------------
            // pnlBenchmark (PANEL DE BENCHMARK Y TELEMETRÍA)
            // ---------------------------------------------------------------
            this.pnlBenchmark.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBenchmark.Height = 180;
            this.pnlBenchmark.Padding = new System.Windows.Forms.Padding(12);
            this.pnlBenchmark.Controls.Add(this.txtResultadosBenchmark);
            this.pnlBenchmark.Controls.Add(this.chkCargarEnCola);
            this.pnlBenchmark.Controls.Add(this.btnBenchmark);
            this.pnlBenchmark.Controls.Add(this.numCantidadPrueba);
            this.pnlBenchmark.Controls.Add(this.lblCantidadPrueba);

            this.lblCantidadPrueba.AutoSize = true;
            this.lblCantidadPrueba.Location = new System.Drawing.Point(15, 15);
            this.lblCantidadPrueba.Text = "Cantidad de pistas para test de estrés:";

            this.numCantidadPrueba.Location = new System.Drawing.Point(260, 12);
            this.numCantidadPrueba.Size = new System.Drawing.Size(100, 23);
            this.numCantidadPrueba.Minimum = 100;
            this.numCantidadPrueba.Maximum = 200000;
            this.numCantidadPrueba.Increment = 1000;
            this.numCantidadPrueba.ThousandsSeparator = true;
            this.numCantidadPrueba.Value = 25000;

            this.btnBenchmark.Location = new System.Drawing.Point(375, 10);
            this.btnBenchmark.Size = new System.Drawing.Size(230, 30);
            this.btnBenchmark.Text = "🚀 Iniciar Prueba de Rendimiento";
            this.btnBenchmark.UseVisualStyleBackColor = true;
            this.btnBenchmark.Click += new System.EventHandler(this.btnBenchmark_Click);

            this.chkCargarEnCola.AutoSize = true;
            this.chkCargarEnCola.Checked = true;
            this.chkCargarEnCola.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCargarEnCola.Location = new System.Drawing.Point(620, 16);
            this.chkCargarEnCola.Text = "Agregar estas pistas a mi cola actual (modo seleccionado arriba)";

            this.txtResultadosBenchmark.Location = new System.Drawing.Point(15, 50);
            this.txtResultadosBenchmark.Size = new System.Drawing.Size(1090, 115);
            this.txtResultadosBenchmark.Multiline = true;
            this.txtResultadosBenchmark.ReadOnly = true;
            this.txtResultadosBenchmark.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtResultadosBenchmark.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtResultadosBenchmark.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));

            // ---------------------------------------------------------------
            // MainForm
            // ---------------------------------------------------------------
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 750);
            this.MinimumSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.pnlPlaylist);
            this.Controls.Add(this.pnlAcciones);
            this.Controls.Add(this.pnlBenchmark);
            this.Controls.Add(this.pnlRegistro);
            this.Text = "SoundCore Engine v2.0 - DJ Set Controller [TecNM Monclova]";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

            ((System.ComponentModel.ISupportInitialize)(this.numBpm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuracion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCola)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCantidadPrueba)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
