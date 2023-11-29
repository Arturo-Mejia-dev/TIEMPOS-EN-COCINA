namespace TIEMPOS_RW
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.LISTACOCINABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DataSetDatos = new TIEMPOS_RW.DataSetDatos();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.labelConfigura = new System.Windows.Forms.Label();
            this.labelReconectando = new System.Windows.Forms.Label();
            this.pictureBoxReconectando = new System.Windows.Forms.PictureBox();
            this.buttonTodos = new System.Windows.Forms.Button();
            this.buttonHot = new System.Windows.Forms.Button();
            this.buttonDone = new System.Windows.Forms.Button();
            this.buttonWorking = new System.Windows.Forms.Button();
            this.MuestraDatos = new System.Windows.Forms.DataGridView();
            this.IDCOMANDA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SALA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MESA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MINUTOS = new DataGridViewProgress.DataGridViewProgressColumn();
            this.ESTATUS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.buttonBuscarR = new System.Windows.Forms.Button();
            this.dateTimeFecha2 = new System.Windows.Forms.DateTimePicker();
            this.dateTimeFecha1 = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.labelVersion = new System.Windows.Forms.Label();
            this.textBoxOrden = new System.Windows.Forms.TextBox();
            this.timerActualiza = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.labelTiempo = new System.Windows.Forms.Label();
            this.labelSucursal = new System.Windows.Forms.Label();
            this.chartSem = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.LISTACOCINATableAdapter = new TIEMPOS_RW.DataSetDatosTableAdapters.LISTACOCINATableAdapter();
            this.labelFecha = new System.Windows.Forms.Label();
            this.timerReconecta = new System.Windows.Forms.Timer(this.components);
            this.labelOK = new System.Windows.Forms.Label();
            this.labelERROR = new System.Windows.Forms.Label();
            this.dataGridViewProgressColumn1 = new DataGridViewProgress.DataGridViewProgressColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelComanda = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMesa = new System.Windows.Forms.Label();
            this.labelHora = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.LISTACOCINABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetDatos)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReconectando)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MuestraDatos)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartSem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // LISTACOCINABindingSource
            // 
            this.LISTACOCINABindingSource.DataMember = "LISTACOCINA";
            this.LISTACOCINABindingSource.DataSource = this.DataSetDatos;
            // 
            // DataSetDatos
            // 
            this.DataSetDatos.DataSetName = "DataSetDatos";
            this.DataSetDatos.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 73);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1240, 482);
            this.tabControl1.TabIndex = 7;
            this.tabControl1.Click += new System.EventHandler(this.TabControl1_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.labelConfigura);
            this.tabPage1.Controls.Add(this.labelReconectando);
            this.tabPage1.Controls.Add(this.pictureBoxReconectando);
            this.tabPage1.Controls.Add(this.buttonTodos);
            this.tabPage1.Controls.Add(this.buttonHot);
            this.tabPage1.Controls.Add(this.buttonDone);
            this.tabPage1.Controls.Add(this.buttonWorking);
            this.tabPage1.Controls.Add(this.MuestraDatos);
            this.tabPage1.Location = new System.Drawing.Point(4, 40);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1232, 438);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "TIEMPOS";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.PRINCIPAL_Click);
            // 
            // labelConfigura
            // 
            this.labelConfigura.AutoSize = true;
            this.labelConfigura.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelConfigura.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.labelConfigura.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelConfigura.Location = new System.Drawing.Point(366, 220);
            this.labelConfigura.Name = "labelConfigura";
            this.labelConfigura.Size = new System.Drawing.Size(463, 42);
            this.labelConfigura.TabIndex = 21;
            this.labelConfigura.Text = "CONFIGURA SERVIDOR";
            this.labelConfigura.Visible = false;
            // 
            // labelReconectando
            // 
            this.labelReconectando.AutoSize = true;
            this.labelReconectando.BackColor = System.Drawing.SystemColors.ControlDark;
            this.labelReconectando.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.labelReconectando.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelReconectando.Location = new System.Drawing.Point(437, 333);
            this.labelReconectando.Name = "labelReconectando";
            this.labelReconectando.Size = new System.Drawing.Size(348, 42);
            this.labelReconectando.TabIndex = 20;
            this.labelReconectando.Text = "RECONECTANDO";
            this.labelReconectando.Visible = false;
            // 
            // pictureBoxReconectando
            // 
            this.pictureBoxReconectando.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxReconectando.Image = global::TIEMPOS_RW.Properties.Resources.loading_loading_forever;
            this.pictureBoxReconectando.Location = new System.Drawing.Point(481, 76);
            this.pictureBoxReconectando.Name = "pictureBoxReconectando";
            this.pictureBoxReconectando.Size = new System.Drawing.Size(254, 254);
            this.pictureBoxReconectando.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxReconectando.TabIndex = 15;
            this.pictureBoxReconectando.TabStop = false;
            this.pictureBoxReconectando.Visible = false;
            // 
            // buttonTodos
            // 
            this.buttonTodos.BackColor = System.Drawing.Color.Black;
            this.buttonTodos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonTodos.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.buttonTodos.ForeColor = System.Drawing.Color.White;
            this.buttonTodos.Location = new System.Drawing.Point(1073, 73);
            this.buttonTodos.Name = "buttonTodos";
            this.buttonTodos.Size = new System.Drawing.Size(137, 59);
            this.buttonTodos.TabIndex = 14;
            this.buttonTodos.UseVisualStyleBackColor = false;
            this.buttonTodos.Click += new System.EventHandler(this.buttonTodos_Click);
            // 
            // buttonHot
            // 
            this.buttonHot.BackColor = System.Drawing.Color.Red;
            this.buttonHot.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHot.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.buttonHot.ForeColor = System.Drawing.Color.Black;
            this.buttonHot.Location = new System.Drawing.Point(1073, 262);
            this.buttonHot.Name = "buttonHot";
            this.buttonHot.Size = new System.Drawing.Size(137, 59);
            this.buttonHot.TabIndex = 10;
            this.buttonHot.UseVisualStyleBackColor = false;
            this.buttonHot.Click += new System.EventHandler(this.buttonHot_Click);
            // 
            // buttonDone
            // 
            this.buttonDone.BackColor = System.Drawing.Color.RoyalBlue;
            this.buttonDone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.buttonDone.Location = new System.Drawing.Point(1073, 354);
            this.buttonDone.Name = "buttonDone";
            this.buttonDone.Size = new System.Drawing.Size(137, 59);
            this.buttonDone.TabIndex = 9;
            this.buttonDone.UseVisualStyleBackColor = false;
            this.buttonDone.Click += new System.EventHandler(this.buttonDone_Click);
            // 
            // buttonWorking
            // 
            this.buttonWorking.BackColor = System.Drawing.Color.LimeGreen;
            this.buttonWorking.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonWorking.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonWorking.ForeColor = System.Drawing.Color.Black;
            this.buttonWorking.Location = new System.Drawing.Point(1073, 169);
            this.buttonWorking.Name = "buttonWorking";
            this.buttonWorking.Size = new System.Drawing.Size(137, 59);
            this.buttonWorking.TabIndex = 8;
            this.buttonWorking.UseVisualStyleBackColor = false;
            this.buttonWorking.Click += new System.EventHandler(this.buttonWorking_Click);
            // 
            // MuestraDatos
            // 
            this.MuestraDatos.AllowUserToAddRows = false;
            this.MuestraDatos.AllowUserToDeleteRows = false;
            this.MuestraDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MuestraDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MuestraDatos.BackgroundColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MuestraDatos.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.MuestraDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MuestraDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IDCOMANDA,
            this.SALA,
            this.MESA,
            this.MINUTOS,
            this.ESTATUS});
            this.MuestraDatos.EnableHeadersVisualStyles = false;
            this.MuestraDatos.Location = new System.Drawing.Point(15, 31);
            this.MuestraDatos.MultiSelect = false;
            this.MuestraDatos.Name = "MuestraDatos";
            this.MuestraDatos.ReadOnly = true;
            this.MuestraDatos.RowHeadersVisible = false;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MuestraDatos.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.MuestraDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MuestraDatos.Size = new System.Drawing.Size(1030, 382);
            this.MuestraDatos.TabIndex = 2;
            this.MuestraDatos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MuestraDatos_CellClick);
            this.MuestraDatos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MuestraDatos_CellDoubleClick);
            this.MuestraDatos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.MuestraDatos_CellFormatting);
            this.MuestraDatos.ColumnAdded += new System.Windows.Forms.DataGridViewColumnEventHandler(this.MuestraDatos_ColumnAdded);
            this.MuestraDatos.Click += new System.EventHandler(this.PRINCIPAL_Click);
            // 
            // IDCOMANDA
            // 
            this.IDCOMANDA.HeaderText = "IDCOMANDA";
            this.IDCOMANDA.Name = "IDCOMANDA";
            this.IDCOMANDA.ReadOnly = true;
            // 
            // SALA
            // 
            this.SALA.HeaderText = "SALA";
            this.SALA.Name = "SALA";
            this.SALA.ReadOnly = true;
            // 
            // MESA
            // 
            this.MESA.HeaderText = "MESA";
            this.MESA.Name = "MESA";
            this.MESA.ReadOnly = true;
            // 
            // MINUTOS
            // 
            this.MINUTOS.HeaderText = "MINUTOS";
            this.MINUTOS.Name = "MINUTOS";
            this.MINUTOS.ReadOnly = true;
            this.MINUTOS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ESTATUS
            // 
            this.ESTATUS.HeaderText = "ESTATUS";
            this.ESTATUS.Name = "ESTATUS";
            this.ESTATUS.ReadOnly = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.buttonBuscarR);
            this.tabPage2.Controls.Add(this.dateTimeFecha2);
            this.tabPage2.Controls.Add(this.dateTimeFecha1);
            this.tabPage2.Controls.Add(this.reportViewer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 40);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1232, 438);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "REPORTES";
            this.tabPage2.UseVisualStyleBackColor = true;
            this.tabPage2.Click += new System.EventHandler(this.PRINCIPAL_Click);
            // 
            // buttonBuscarR
            // 
            this.buttonBuscarR.BackgroundImage = global::TIEMPOS_RW.Properties.Resources.png_clipart_computer_icons_search_box_desktop_button_desktop_wallpaper_search_box;
            this.buttonBuscarR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBuscarR.Location = new System.Drawing.Point(423, 3);
            this.buttonBuscarR.Name = "buttonBuscarR";
            this.buttonBuscarR.Size = new System.Drawing.Size(48, 38);
            this.buttonBuscarR.TabIndex = 3;
            this.buttonBuscarR.UseVisualStyleBackColor = true;
            this.buttonBuscarR.Click += new System.EventHandler(this.ButtonBuscarR_Click);
            // 
            // dateTimeFecha2
            // 
            this.dateTimeFecha2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateTimeFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFecha2.Location = new System.Drawing.Point(217, 3);
            this.dateTimeFecha2.Name = "dateTimeFecha2";
            this.dateTimeFecha2.Size = new System.Drawing.Size(200, 38);
            this.dateTimeFecha2.TabIndex = 2;
            this.dateTimeFecha2.ValueChanged += new System.EventHandler(this.PRINCIPAL_Click);
            this.dateTimeFecha2.MouseCaptureChanged += new System.EventHandler(this.PRINCIPAL_Click);
            // 
            // dateTimeFecha1
            // 
            this.dateTimeFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFecha1.Location = new System.Drawing.Point(11, 3);
            this.dateTimeFecha1.Name = "dateTimeFecha1";
            this.dateTimeFecha1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dateTimeFecha1.Size = new System.Drawing.Size(200, 38);
            this.dateTimeFecha1.TabIndex = 1;
            this.dateTimeFecha1.ValueChanged += new System.EventHandler(this.PRINCIPAL_Click);
            this.dateTimeFecha1.MouseCaptureChanged += new System.EventHandler(this.PRINCIPAL_Click);
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.LISTACOCINABindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "TIEMPOS_RW.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(3, 47);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1223, 385);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Click += new System.EventHandler(this.PRINCIPAL_Click);
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.Location = new System.Drawing.Point(164, 9);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(60, 20);
            this.labelVersion.TabIndex = 20;
            this.labelVersion.Text = "V.8422";
            this.labelVersion.Click += new System.EventHandler(this.LabelVersion_Click);
            // 
            // textBoxOrden
            // 
            this.textBoxOrden.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxOrden.ForeColor = System.Drawing.Color.Red;
            this.textBoxOrden.Location = new System.Drawing.Point(699, 76);
            this.textBoxOrden.Name = "textBoxOrden";
            this.textBoxOrden.Size = new System.Drawing.Size(371, 35);
            this.textBoxOrden.TabIndex = 0;
            this.textBoxOrden.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxOrden.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxOrden_KeyPress);
            this.textBoxOrden.Validating += new System.ComponentModel.CancelEventHandler(this.TextBoxOrden_Validating);
            // 
            // timerActualiza
            // 
            this.timerActualiza.Enabled = true;
            this.timerActualiza.Interval = 7000;
            this.timerActualiza.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(528, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 37);
            this.label1.TabIndex = 10;
            this.label1.Text = " ";
            // 
            // labelTiempo
            // 
            this.labelTiempo.AutoSize = true;
            this.labelTiempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTiempo.ForeColor = System.Drawing.Color.Red;
            this.labelTiempo.Location = new System.Drawing.Point(508, 9);
            this.labelTiempo.Name = "labelTiempo";
            this.labelTiempo.Size = new System.Drawing.Size(185, 55);
            this.labelTiempo.TabIndex = 11;
            this.labelTiempo.Text = "00 MIN";
            // 
            // labelSucursal
            // 
            this.labelSucursal.AutoSize = true;
            this.labelSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelSucursal.Location = new System.Drawing.Point(57, 558);
            this.labelSucursal.Name = "labelSucursal";
            this.labelSucursal.Size = new System.Drawing.Size(177, 42);
            this.labelSucursal.TabIndex = 16;
            this.labelSucursal.Text = "RW UAQ";
            // 
            // chartSem
            // 
            this.chartSem.BackColor = System.Drawing.Color.Transparent;
            chartArea1.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chartSem.ChartAreas.Add(chartArea1);
            this.chartSem.Location = new System.Drawing.Point(1098, 2);
            this.chartSem.Name = "chartSem";
            this.chartSem.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chartSem.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.LimeGreen,
        System.Drawing.Color.Red};
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series1.Name = "Comandas";
            this.chartSem.Series.Add(series1);
            this.chartSem.Size = new System.Drawing.Size(119, 108);
            this.chartSem.TabIndex = 17;
            this.chartSem.Text = "chart1";
            // 
            // LISTACOCINATableAdapter
            // 
            this.LISTACOCINATableAdapter.ClearBeforeFill = true;
            // 
            // labelFecha
            // 
            this.labelFecha.AutoSize = true;
            this.labelFecha.BackColor = System.Drawing.SystemColors.Control;
            this.labelFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFecha.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelFecha.Location = new System.Drawing.Point(1046, 557);
            this.labelFecha.Name = "labelFecha";
            this.labelFecha.Size = new System.Drawing.Size(118, 33);
            this.labelFecha.TabIndex = 19;
            this.labelFecha.Text = "FECHA";
            // 
            // timerReconecta
            // 
            this.timerReconecta.Interval = 60000;
            this.timerReconecta.Tick += new System.EventHandler(this.TimerReconecta_Tick);
            // 
            // labelOK
            // 
            this.labelOK.AutoSize = true;
            this.labelOK.BackColor = System.Drawing.SystemColors.Control;
            this.labelOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.labelOK.ForeColor = System.Drawing.Color.LimeGreen;
            this.labelOK.Location = new System.Drawing.Point(528, 562);
            this.labelOK.Name = "labelOK";
            this.labelOK.Size = new System.Drawing.Size(74, 42);
            this.labelOK.TabIndex = 21;
            this.labelOK.Text = "OK";
            this.labelOK.Visible = false;
            // 
            // labelERROR
            // 
            this.labelERROR.AutoSize = true;
            this.labelERROR.BackColor = System.Drawing.SystemColors.Control;
            this.labelERROR.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.labelERROR.ForeColor = System.Drawing.Color.Red;
            this.labelERROR.Location = new System.Drawing.Point(476, 562);
            this.labelERROR.Name = "labelERROR";
            this.labelERROR.Size = new System.Drawing.Size(158, 42);
            this.labelERROR.TabIndex = 22;
            this.labelERROR.Text = "ERROR";
            this.labelERROR.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelERROR.Visible = false;
            // 
            // dataGridViewProgressColumn1
            // 
            this.dataGridViewProgressColumn1.HeaderText = "MINUTOS";
            this.dataGridViewProgressColumn1.Name = "dataGridViewProgressColumn1";
            this.dataGridViewProgressColumn1.Width = 206;
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::TIEMPOS_RW.Properties.Resources.engrane;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Location = new System.Drawing.Point(16, 562);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 18;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::TIEMPOS_RW.Properties.Resources.RW_LogoWEB;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(12, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(146, 68);
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(24, 632);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(380, 42);
            this.label2.TabIndex = 23;
            this.label2.Text = "ULTIMA COMANDA:";
            // 
            // labelComanda
            // 
            this.labelComanda.AutoSize = true;
            this.labelComanda.BackColor = System.Drawing.SystemColors.Control;
            this.labelComanda.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.labelComanda.ForeColor = System.Drawing.Color.Black;
            this.labelComanda.Location = new System.Drawing.Point(399, 632);
            this.labelComanda.Name = "labelComanda";
            this.labelComanda.Size = new System.Drawing.Size(128, 42);
            this.labelComanda.TabIndex = 24;
            this.labelComanda.Text = "00000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(541, 632);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(183, 42);
            this.label4.TabIndex = 25;
            this.label4.Text = "/   MESA:";
            // 
            // labelMesa
            // 
            this.labelMesa.AutoSize = true;
            this.labelMesa.BackColor = System.Drawing.SystemColors.Control;
            this.labelMesa.Font = new System.Drawing.Font("Microsoft Sans Serif", 27.75F, System.Drawing.FontStyle.Bold);
            this.labelMesa.ForeColor = System.Drawing.Color.Black;
            this.labelMesa.Location = new System.Drawing.Point(719, 632);
            this.labelMesa.Name = "labelMesa";
            this.labelMesa.Size = new System.Drawing.Size(128, 42);
            this.labelMesa.TabIndex = 26;
            this.labelMesa.Text = "00000";
            // 
            // labelHora
            // 
            this.labelHora.AutoSize = true;
            this.labelHora.BackColor = System.Drawing.SystemColors.Control;
            this.labelHora.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHora.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.labelHora.Location = new System.Drawing.Point(1046, 591);
            this.labelHora.Name = "labelHora";
            this.labelHora.Size = new System.Drawing.Size(103, 33);
            this.labelHora.TabIndex = 27;
            this.labelHora.Text = "HORA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(933, 632);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(327, 33);
            this.label3.TabIndex = 28;
            this.label3.Text = "PRECOCCION: 40 KG";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelHora);
            this.Controls.Add(this.labelMesa);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.labelComanda);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelERROR);
            this.Controls.Add(this.labelOK);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelFecha);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.chartSem);
            this.Controls.Add(this.labelSucursal);
            this.Controls.Add(this.labelTiempo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.textBoxOrden);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TIEMPOS COCINA";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Form1_Activated);
            this.Deactivate += new System.EventHandler(this.Form1_Deactivate);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Click += new System.EventHandler(this.PRINCIPAL_Click);
            this.Enter += new System.EventHandler(this.Form1_Enter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.Validating += new System.ComponentModel.CancelEventHandler(this.Form1_Validating);
            ((System.ComponentModel.ISupportInitialize)(this.LISTACOCINABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataSetDatos)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxReconectando)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MuestraDatos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartSem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button buttonTodos;
        private System.Windows.Forms.Button buttonHot;
        private System.Windows.Forms.Button buttonDone;
        private System.Windows.Forms.Button buttonWorking;
        private System.Windows.Forms.TextBox textBoxOrden;
        private System.Windows.Forms.DataGridView MuestraDatos;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Timer timerActualiza;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button buttonBuscarR;
        private System.Windows.Forms.DateTimePicker dateTimeFecha2;
        private System.Windows.Forms.DateTimePicker dateTimeFecha1;
        private System.Windows.Forms.BindingSource LISTACOCINABindingSource;
        private DataSetDatos DataSetDatos;
        private DataSetDatosTableAdapters.LISTACOCINATableAdapter LISTACOCINATableAdapter;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelTiempo;
        private System.Windows.Forms.Label labelSucursal;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartSem;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelFecha;
        private System.Windows.Forms.Label labelVersion;
        private System.Windows.Forms.PictureBox pictureBoxReconectando;
        private System.Windows.Forms.Label labelReconectando;
        private System.Windows.Forms.Timer timerReconecta;
        private System.Windows.Forms.Label labelOK;
        private System.Windows.Forms.Label labelERROR;
        private System.Windows.Forms.Label labelConfigura;
        private System.Windows.Forms.DataGridViewTextBoxColumn IDCOMANDA;
        private System.Windows.Forms.DataGridViewTextBoxColumn SALA;
        private System.Windows.Forms.DataGridViewTextBoxColumn MESA;
        private DataGridViewProgress.DataGridViewProgressColumn MINUTOS;
        private System.Windows.Forms.DataGridViewTextBoxColumn ESTATUS;
        private DataGridViewProgress.DataGridViewProgressColumn dataGridViewProgressColumn1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelComanda;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label labelMesa;
        private System.Windows.Forms.Label labelHora;
        private System.Windows.Forms.Label label3;
    }
}

