namespace PSO
{
    partial class FormPso
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
            this.panelMap = new System.Windows.Forms.PictureBox();
            this.buttonGenerate = new System.Windows.Forms.Button();
            this.buttonOptimal = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointsToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelGbest = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelBest = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelX = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelXval = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelYval = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.radioButtonSphere = new System.Windows.Forms.RadioButton();
            this.radioButtonGriewangk = new System.Windows.Forms.RadioButton();
            this.radioButtonRastrigin = new System.Windows.Forms.RadioButton();
            this.radioButtonRosenbock = new System.Windows.Forms.RadioButton();
            this.groupBoxFunction = new System.Windows.Forms.GroupBox();
            this.groupBoxAlgorithm = new System.Windows.Forms.GroupBox();
            this.radioButtonABase = new System.Windows.Forms.RadioButton();
            this.radioButtonAInit = new System.Windows.Forms.RadioButton();
            this.radioButtonAConstr = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonTFull = new System.Windows.Forms.RadioButton();
            this.radioButtonTRing = new System.Windows.Forms.RadioButton();
            this.radioButtonT4 = new System.Windows.Forms.RadioButton();
            this.labelFi1 = new System.Windows.Forms.Label();
            this.textBoxFi1 = new System.Windows.Forms.TextBox();
            this.textBoxFi2 = new System.Windows.Forms.TextBox();
            this.labelFi2 = new System.Windows.Forms.Label();
            this.textBoxFactor = new System.Windows.Forms.TextBox();
            this.labelFactor = new System.Windows.Forms.Label();
            this.buttonSim = new System.Windows.Forms.Button();
            this.Delay = new PSO.BarCounter();
            this.Population = new PSO.BarCounter();
            ((System.ComponentModel.ISupportInitialize)(this.panelMap)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.groupBoxFunction.SuspendLayout();
            this.groupBoxAlgorithm.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMap
            // 
            this.panelMap.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMap.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelMap.Location = new System.Drawing.Point(0, 25);
            this.panelMap.Name = "panelMap";
            this.panelMap.Size = new System.Drawing.Size(275, 271);
            this.panelMap.TabIndex = 0;
            this.panelMap.TabStop = false;
            this.panelMap.Paint += new System.Windows.Forms.PaintEventHandler(this.PanelMapPaint);
            // 
            // buttonGenerate
            // 
            this.buttonGenerate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGenerate.Location = new System.Drawing.Point(279, 244);
            this.buttonGenerate.Name = "buttonGenerate";
            this.buttonGenerate.Size = new System.Drawing.Size(75, 23);
            this.buttonGenerate.TabIndex = 4;
            this.buttonGenerate.Text = "Generate";
            this.buttonGenerate.UseVisualStyleBackColor = true;
            this.buttonGenerate.Click += new System.EventHandler(this.ButtonGenerateClick);
            // 
            // buttonOptimal
            // 
            this.buttonOptimal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOptimal.Enabled = false;
            this.buttonOptimal.Location = new System.Drawing.Point(279, 273);
            this.buttonOptimal.Name = "buttonOptimal";
            this.buttonOptimal.Size = new System.Drawing.Size(75, 23);
            this.buttonOptimal.TabIndex = 5;
            this.buttonOptimal.Text = "Run";
            this.buttonOptimal.UseVisualStyleBackColor = true;
            this.buttonOptimal.Click += new System.EventHandler(this.ButtonOptimalClick);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BackgroundWorkerDoWork);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BackgroundWorkerRunWorkerCompleted);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.Location = new System.Drawing.Point(360, 244);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 10;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancelClick);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(448, 24);
            this.menuStrip.TabIndex = 13;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointsToolStripMenuItem,
            this.imageToolStripMenuItem});
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // pointsToolStripMenuItem
            // 
            this.pointsToolStripMenuItem.Name = "pointsToolStripMenuItem";
            this.pointsToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.pointsToolStripMenuItem.Text = "Points";
            this.pointsToolStripMenuItem.Click += new System.EventHandler(this.PointsToolStripMenuItemClick);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.imageToolStripMenuItem.Text = "Image";
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.ImageToolStripMenuItemClick);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointsToolStripMenuItem1});
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.loadToolStripMenuItem.Text = "Load";
            // 
            // pointsToolStripMenuItem1
            // 
            this.pointsToolStripMenuItem1.Name = "pointsToolStripMenuItem1";
            this.pointsToolStripMenuItem1.Size = new System.Drawing.Size(107, 22);
            this.pointsToolStripMenuItem1.Text = "Points";
            this.pointsToolStripMenuItem1.Click += new System.EventHandler(this.PointsToolStripMenuItem1Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelGbest,
            this.toolStripStatusLabelBest,
            this.toolStripStatusLabelX,
            this.toolStripStatusLabelXval,
            this.toolStripStatusLabelY,
            this.toolStripStatusLabelYval});
            this.statusStrip.Location = new System.Drawing.Point(0, 299);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(448, 22);
            this.statusStrip.TabIndex = 17;
            // 
            // toolStripStatusLabelGbest
            // 
            this.toolStripStatusLabelGbest.Name = "toolStripStatusLabelGbest";
            this.toolStripStatusLabelGbest.Size = new System.Drawing.Size(66, 17);
            this.toolStripStatusLabelGbest.Text = "Global best";
            // 
            // toolStripStatusLabelBest
            // 
            this.toolStripStatusLabelBest.Name = "toolStripStatusLabelBest";
            this.toolStripStatusLabelBest.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelX
            // 
            this.toolStripStatusLabelX.Name = "toolStripStatusLabelX";
            this.toolStripStatusLabelX.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabelX.Text = "X";
            // 
            // toolStripStatusLabelXval
            // 
            this.toolStripStatusLabelXval.Name = "toolStripStatusLabelXval";
            this.toolStripStatusLabelXval.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelY
            // 
            this.toolStripStatusLabelY.Name = "toolStripStatusLabelY";
            this.toolStripStatusLabelY.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabelY.Text = "Y";
            // 
            // toolStripStatusLabelYval
            // 
            this.toolStripStatusLabelYval.Name = "toolStripStatusLabelYval";
            this.toolStripStatusLabelYval.Size = new System.Drawing.Size(0, 17);
            // 
            // radioButtonSphere
            // 
            this.radioButtonSphere.AutoSize = true;
            this.radioButtonSphere.Checked = true;
            this.radioButtonSphere.Location = new System.Drawing.Point(5, 10);
            this.radioButtonSphere.Name = "radioButtonSphere";
            this.radioButtonSphere.Size = new System.Drawing.Size(59, 17);
            this.radioButtonSphere.TabIndex = 25;
            this.radioButtonSphere.TabStop = true;
            this.radioButtonSphere.Text = "Sphere";
            this.radioButtonSphere.UseVisualStyleBackColor = true;
            this.radioButtonSphere.CheckedChanged += new System.EventHandler(this.radioButtonFunction_CheckedChanged);
            // 
            // radioButtonGriewangk
            // 
            this.radioButtonGriewangk.AutoSize = true;
            this.radioButtonGriewangk.Location = new System.Drawing.Point(5, 30);
            this.radioButtonGriewangk.Name = "radioButtonGriewangk";
            this.radioButtonGriewangk.Size = new System.Drawing.Size(76, 17);
            this.radioButtonGriewangk.TabIndex = 26;
            this.radioButtonGriewangk.Text = "Griewangk";
            this.radioButtonGriewangk.UseVisualStyleBackColor = true;
            this.radioButtonGriewangk.CheckedChanged += new System.EventHandler(this.radioButtonFunction_CheckedChanged);
            // 
            // radioButtonRastrigin
            // 
            this.radioButtonRastrigin.AutoSize = true;
            this.radioButtonRastrigin.Location = new System.Drawing.Point(5, 50);
            this.radioButtonRastrigin.Name = "radioButtonRastrigin";
            this.radioButtonRastrigin.Size = new System.Drawing.Size(66, 17);
            this.radioButtonRastrigin.TabIndex = 27;
            this.radioButtonRastrigin.Text = "Rastrigin";
            this.radioButtonRastrigin.UseVisualStyleBackColor = true;
            this.radioButtonRastrigin.CheckedChanged += new System.EventHandler(this.radioButtonFunction_CheckedChanged);
            // 
            // radioButtonRosenbock
            // 
            this.radioButtonRosenbock.AutoSize = true;
            this.radioButtonRosenbock.Location = new System.Drawing.Point(5, 70);
            this.radioButtonRosenbock.Name = "radioButtonRosenbock";
            this.radioButtonRosenbock.Size = new System.Drawing.Size(80, 17);
            this.radioButtonRosenbock.TabIndex = 28;
            this.radioButtonRosenbock.Text = "Rosenbock";
            this.radioButtonRosenbock.UseVisualStyleBackColor = true;
            this.radioButtonRosenbock.CheckedChanged += new System.EventHandler(this.radioButtonFunction_CheckedChanged);
            // 
            // groupBoxFunction
            // 
            this.groupBoxFunction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxFunction.Controls.Add(this.radioButtonSphere);
            this.groupBoxFunction.Controls.Add(this.radioButtonGriewangk);
            this.groupBoxFunction.Controls.Add(this.radioButtonRastrigin);
            this.groupBoxFunction.Controls.Add(this.radioButtonRosenbock);
            this.groupBoxFunction.Location = new System.Drawing.Point(274, 148);
            this.groupBoxFunction.Name = "groupBoxFunction";
            this.groupBoxFunction.Size = new System.Drawing.Size(80, 90);
            this.groupBoxFunction.TabIndex = 33;
            this.groupBoxFunction.TabStop = false;
            // 
            // groupBoxAlgorithm
            // 
            this.groupBoxAlgorithm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxAlgorithm.Controls.Add(this.radioButtonABase);
            this.groupBoxAlgorithm.Controls.Add(this.radioButtonAInit);
            this.groupBoxAlgorithm.Controls.Add(this.radioButtonAConstr);
            this.groupBoxAlgorithm.Location = new System.Drawing.Point(360, 25);
            this.groupBoxAlgorithm.Name = "groupBoxAlgorithm";
            this.groupBoxAlgorithm.Size = new System.Drawing.Size(88, 70);
            this.groupBoxAlgorithm.TabIndex = 35;
            this.groupBoxAlgorithm.TabStop = false;
            this.groupBoxAlgorithm.Text = "Algorithm";
            // 
            // radioButtonABase
            // 
            this.radioButtonABase.AutoSize = true;
            this.radioButtonABase.Checked = true;
            this.radioButtonABase.Location = new System.Drawing.Point(5, 11);
            this.radioButtonABase.Name = "radioButtonABase";
            this.radioButtonABase.Size = new System.Drawing.Size(49, 17);
            this.radioButtonABase.TabIndex = 25;
            this.radioButtonABase.TabStop = true;
            this.radioButtonABase.Text = "Base";
            this.radioButtonABase.UseVisualStyleBackColor = true;
            this.radioButtonABase.CheckedChanged += new System.EventHandler(this.radioButtonAlgorithm_CheckedChanged);
            // 
            // radioButtonAInit
            // 
            this.radioButtonAInit.AutoSize = true;
            this.radioButtonAInit.Location = new System.Drawing.Point(5, 31);
            this.radioButtonAInit.Name = "radioButtonAInit";
            this.radioButtonAInit.Size = new System.Drawing.Size(76, 17);
            this.radioButtonAInit.TabIndex = 26;
            this.radioButtonAInit.Text = "Init. weight";
            this.radioButtonAInit.UseVisualStyleBackColor = true;
            // 
            // radioButtonAConstr
            // 
            this.radioButtonAConstr.AutoSize = true;
            this.radioButtonAConstr.Location = new System.Drawing.Point(5, 51);
            this.radioButtonAConstr.Name = "radioButtonAConstr";
            this.radioButtonAConstr.Size = new System.Drawing.Size(88, 17);
            this.radioButtonAConstr.TabIndex = 27;
            this.radioButtonAConstr.Text = "Constr. factor";
            this.radioButtonAConstr.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.radioButtonTFull);
            this.groupBox1.Controls.Add(this.radioButtonTRing);
            this.groupBox1.Controls.Add(this.radioButtonT4);
            this.groupBox1.Location = new System.Drawing.Point(360, 99);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(88, 70);
            this.groupBox1.TabIndex = 36;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Topology";
            // 
            // radioButtonTFull
            // 
            this.radioButtonTFull.AutoSize = true;
            this.radioButtonTFull.Checked = true;
            this.radioButtonTFull.Location = new System.Drawing.Point(5, 11);
            this.radioButtonTFull.Name = "radioButtonTFull";
            this.radioButtonTFull.Size = new System.Drawing.Size(41, 17);
            this.radioButtonTFull.TabIndex = 25;
            this.radioButtonTFull.TabStop = true;
            this.radioButtonTFull.Text = "Full";
            this.radioButtonTFull.UseVisualStyleBackColor = true;
            this.radioButtonTFull.CheckedChanged += new System.EventHandler(this.radioButtonTopo_CheckedChanged);
            // 
            // radioButtonTRing
            // 
            this.radioButtonTRing.AutoSize = true;
            this.radioButtonTRing.Location = new System.Drawing.Point(5, 31);
            this.radioButtonTRing.Name = "radioButtonTRing";
            this.radioButtonTRing.Size = new System.Drawing.Size(47, 17);
            this.radioButtonTRing.TabIndex = 26;
            this.radioButtonTRing.Text = "Ring";
            this.radioButtonTRing.UseVisualStyleBackColor = true;
            this.radioButtonTRing.CheckedChanged += new System.EventHandler(this.radioButtonTopo_CheckedChanged);
            // 
            // radioButtonT4
            // 
            this.radioButtonT4.AutoSize = true;
            this.radioButtonT4.Location = new System.Drawing.Point(5, 51);
            this.radioButtonT4.Name = "radioButtonT4";
            this.radioButtonT4.Size = new System.Drawing.Size(86, 17);
            this.radioButtonT4.TabIndex = 27;
            this.radioButtonT4.Text = "4-neighbours";
            this.radioButtonT4.UseVisualStyleBackColor = true;
            this.radioButtonT4.CheckedChanged += new System.EventHandler(this.radioButtonTopo_CheckedChanged);
            // 
            // labelFi1
            // 
            this.labelFi1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFi1.AutoSize = true;
            this.labelFi1.Location = new System.Drawing.Point(362, 174);
            this.labelFi1.Name = "labelFi1";
            this.labelFi1.Size = new System.Drawing.Size(18, 13);
            this.labelFi1.TabIndex = 37;
            this.labelFi1.Text = "fi1";
            // 
            // textBoxFi1
            // 
            this.textBoxFi1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFi1.Location = new System.Drawing.Point(399, 171);
            this.textBoxFi1.Name = "textBoxFi1";
            this.textBoxFi1.Size = new System.Drawing.Size(36, 20);
            this.textBoxFi1.TabIndex = 38;
            this.textBoxFi1.Text = "0.001";
            // 
            // textBoxFi2
            // 
            this.textBoxFi2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFi2.Location = new System.Drawing.Point(399, 195);
            this.textBoxFi2.Name = "textBoxFi2";
            this.textBoxFi2.Size = new System.Drawing.Size(36, 20);
            this.textBoxFi2.TabIndex = 40;
            this.textBoxFi2.Text = "0.001";
            // 
            // labelFi2
            // 
            this.labelFi2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFi2.AutoSize = true;
            this.labelFi2.Location = new System.Drawing.Point(362, 198);
            this.labelFi2.Name = "labelFi2";
            this.labelFi2.Size = new System.Drawing.Size(18, 13);
            this.labelFi2.TabIndex = 39;
            this.labelFi2.Text = "fi2";
            // 
            // textBoxFactor
            // 
            this.textBoxFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxFactor.Location = new System.Drawing.Point(399, 219);
            this.textBoxFactor.Name = "textBoxFactor";
            this.textBoxFactor.Size = new System.Drawing.Size(36, 20);
            this.textBoxFactor.TabIndex = 42;
            this.textBoxFactor.Text = "1";
            // 
            // labelFactor
            // 
            this.labelFactor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelFactor.AutoSize = true;
            this.labelFactor.Location = new System.Drawing.Point(360, 220);
            this.labelFactor.Name = "labelFactor";
            this.labelFactor.Size = new System.Drawing.Size(33, 13);
            this.labelFactor.TabIndex = 41;
            this.labelFactor.Text = "w/psi";
            // 
            // buttonSim
            // 
            this.buttonSim.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSim.Location = new System.Drawing.Point(360, 273);
            this.buttonSim.Name = "buttonSim";
            this.buttonSim.Size = new System.Drawing.Size(75, 23);
            this.buttonSim.TabIndex = 43;
            this.buttonSim.Text = "Simulation";
            this.buttonSim.UseVisualStyleBackColor = true;
            this.buttonSim.Click += new System.EventHandler(this.buttonSim_Click);
            // 
            // Delay
            // 
            this.Delay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Delay.Location = new System.Drawing.Point(275, 91);
            this.Delay.Name = "Delay";
            this.Delay.Size = new System.Drawing.Size(90, 60);
            this.Delay.TabIndex = 15;
            this.Delay.Value = 0;
            // 
            // Population
            // 
            this.Population.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Population.Location = new System.Drawing.Point(273, 25);
            this.Population.Name = "Population";
            this.Population.Size = new System.Drawing.Size(90, 60);
            this.Population.TabIndex = 14;
            this.Population.Value = 0;
            // 
            // FormPso
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 321);
            this.Controls.Add(this.buttonSim);
            this.Controls.Add(this.textBoxFactor);
            this.Controls.Add(this.labelFactor);
            this.Controls.Add(this.textBoxFi2);
            this.Controls.Add(this.labelFi2);
            this.Controls.Add(this.textBoxFi1);
            this.Controls.Add(this.labelFi1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAlgorithm);
            this.Controls.Add(this.groupBoxFunction);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.Delay);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOptimal);
            this.Controls.Add(this.buttonGenerate);
            this.Controls.Add(this.panelMap);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.Population);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormPso";
            this.Text = "TSP";
            ((System.ComponentModel.ISupportInitialize)(this.panelMap)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.groupBoxFunction.ResumeLayout(false);
            this.groupBoxFunction.PerformLayout();
            this.groupBoxAlgorithm.ResumeLayout(false);
            this.groupBoxAlgorithm.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox panelMap;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonOptimal;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointsToolStripMenuItem1;
        private BarCounter Population;
        private BarCounter Delay;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelGbest;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelBest;
        private System.Windows.Forms.RadioButton radioButtonSphere;
        private System.Windows.Forms.RadioButton radioButtonGriewangk;
        private System.Windows.Forms.RadioButton radioButtonRastrigin;
        private System.Windows.Forms.RadioButton radioButtonRosenbock;
        private System.Windows.Forms.GroupBox groupBoxFunction;
        private System.Windows.Forms.GroupBox groupBoxAlgorithm;
        private System.Windows.Forms.RadioButton radioButtonABase;
        private System.Windows.Forms.RadioButton radioButtonAInit;
        private System.Windows.Forms.RadioButton radioButtonAConstr;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonTFull;
        private System.Windows.Forms.RadioButton radioButtonTRing;
        private System.Windows.Forms.RadioButton radioButtonT4;
        private System.Windows.Forms.Label labelFi1;
        private System.Windows.Forms.TextBox textBoxFi1;
        private System.Windows.Forms.TextBox textBoxFi2;
        private System.Windows.Forms.Label labelFi2;
        private System.Windows.Forms.TextBox textBoxFactor;
        private System.Windows.Forms.Label labelFactor;
        private System.Windows.Forms.Button buttonSim;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelX;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelXval;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelY;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelYval;
    }
}

