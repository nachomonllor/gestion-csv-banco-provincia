namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lbl_importe_buscado = new System.Windows.Forms.Label();
            this.btn_sumatoria = new System.Windows.Forms.Button();
            this.txt_contiene = new System.Windows.Forms.TextBox();
            this.btn_carga_datagrid = new System.Windows.Forms.Button();
            this.btn_reset_datagrid = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnSeleccionarArchivo = new System.Windows.Forms.Button();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Importe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SaldoEnBanco = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Fecha,
            this.Descripcion,
            this.Importe,
            this.SaldoEnBanco});
            this.dataGridView1.Location = new System.Drawing.Point(37, 30);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(987, 400);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // lbl_importe_buscado
            // 
            this.lbl_importe_buscado.AutoSize = true;
            this.lbl_importe_buscado.Location = new System.Drawing.Point(361, 562);
            this.lbl_importe_buscado.Name = "lbl_importe_buscado";
            this.lbl_importe_buscado.Size = new System.Drawing.Size(133, 13);
            this.lbl_importe_buscado.TabIndex = 1;
            this.lbl_importe_buscado.Text = "sumatoria importe buscado";
            // 
            // btn_sumatoria
            // 
            this.btn_sumatoria.Location = new System.Drawing.Point(364, 519);
            this.btn_sumatoria.Name = "btn_sumatoria";
            this.btn_sumatoria.Size = new System.Drawing.Size(130, 23);
            this.btn_sumatoria.TabIndex = 2;
            this.btn_sumatoria.Text = "Buscar Sumatoria";
            this.btn_sumatoria.UseVisualStyleBackColor = true;
            this.btn_sumatoria.Click += new System.EventHandler(this.btn_sumatoria_Click);
            // 
            // txt_contiene
            // 
            this.txt_contiene.Location = new System.Drawing.Point(364, 480);
            this.txt_contiene.Name = "txt_contiene";
            this.txt_contiene.Size = new System.Drawing.Size(130, 20);
            this.txt_contiene.TabIndex = 3;
            this.txt_contiene.Text = "Buscar importe";
            // 
            // btn_carga_datagrid
            // 
            this.btn_carga_datagrid.Location = new System.Drawing.Point(527, 519);
            this.btn_carga_datagrid.Name = "btn_carga_datagrid";
            this.btn_carga_datagrid.Size = new System.Drawing.Size(232, 23);
            this.btn_carga_datagrid.TabIndex = 4;
            this.btn_carga_datagrid.Text = "Cargar datagrid Buscar";
            this.btn_carga_datagrid.UseVisualStyleBackColor = true;
            this.btn_carga_datagrid.Click += new System.EventHandler(this.btn_carga_datagrid_Click);
            // 
            // btn_reset_datagrid
            // 
            this.btn_reset_datagrid.Location = new System.Drawing.Point(37, 477);
            this.btn_reset_datagrid.Name = "btn_reset_datagrid";
            this.btn_reset_datagrid.Size = new System.Drawing.Size(171, 23);
            this.btn_reset_datagrid.TabIndex = 5;
            this.btn_reset_datagrid.Text = "Reset DataGrid";
            this.btn_reset_datagrid.UseVisualStyleBackColor = true;
            this.btn_reset_datagrid.Click += new System.EventHandler(this.btn_reset_datagrid_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"Archivos CSV (*.csv)|*.CSV|Todos los archivos (*.*)|*.*\"";
            // 
            // btnSeleccionarArchivo
            // 
            this.btnSeleccionarArchivo.Location = new System.Drawing.Point(860, 519);
            this.btnSeleccionarArchivo.Name = "btnSeleccionarArchivo";
            this.btnSeleccionarArchivo.Size = new System.Drawing.Size(164, 23);
            this.btnSeleccionarArchivo.TabIndex = 6;
            this.btnSeleccionarArchivo.Text = "Seleccionar Archivo";
            this.btnSeleccionarArchivo.UseVisualStyleBackColor = true;
            this.btnSeleccionarArchivo.Click += new System.EventHandler(this.btnSeleccionarArchivo_Click);
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Fecha.FillWeight = 162.4366F;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            this.Fecha.Width = 62;
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Descripcion.FillWeight = 192.2112F;
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            this.Descripcion.ReadOnly = true;
            this.Descripcion.Width = 88;
            // 
            // Importe
            // 
            this.Importe.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.Importe.FillWeight = 19.54571F;
            this.Importe.HeaderText = "Importe";
            this.Importe.Name = "Importe";
            this.Importe.ReadOnly = true;
            this.Importe.Width = 67;
            // 
            // SaldoEnBanco
            // 
            this.SaldoEnBanco.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.SaldoEnBanco.FillWeight = 25.80657F;
            this.SaldoEnBanco.HeaderText = "Saldo En Banco";
            this.SaldoEnBanco.Name = "SaldoEnBanco";
            this.SaldoEnBanco.ReadOnly = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(527, 480);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 609);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.btnSeleccionarArchivo);
            this.Controls.Add(this.btn_reset_datagrid);
            this.Controls.Add(this.btn_carga_datagrid);
            this.Controls.Add(this.txt_contiene);
            this.Controls.Add(this.btn_sumatoria);
            this.Controls.Add(this.lbl_importe_buscado);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_importe_buscado;
        private System.Windows.Forms.Button btn_sumatoria;
        private System.Windows.Forms.TextBox txt_contiene;
        private System.Windows.Forms.Button btn_carga_datagrid;
        private System.Windows.Forms.Button btn_reset_datagrid;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnSeleccionarArchivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Importe;
        private System.Windows.Forms.DataGridViewTextBoxColumn SaldoEnBanco;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
    }
}

