namespace CompiB
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.abrirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guardarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tablasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.anaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tAASToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.grámaticaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuadruplosGrid = new System.Windows.Forms.DataGridView();
            this.tabsimGrid = new System.Windows.Forms.DataGridView();
            this.compilarB = new System.Windows.Forms.Button();
            this.ejecutaB = new System.Windows.Forms.Button();
            this.highLvlB = new System.Windows.Forms.Button();
            this.lowLvlB = new System.Windows.Forms.Button();
            this.programaText = new System.Windows.Forms.RichTextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cuadruplosGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabsimGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.abrirToolStripMenuItem,
            this.guardarToolStripMenuItem,
            this.tablasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1374, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(54, 24);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // tablasToolStripMenuItem
            // 
            this.tablasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anaToolStripMenuItem,
            this.tAASToolStripMenuItem,
            this.grámaticaToolStripMenuItem});
            this.tablasToolStripMenuItem.Name = "tablasToolStripMenuItem";
            this.tablasToolStripMenuItem.Size = new System.Drawing.Size(51, 24);
            this.tablasToolStripMenuItem.Text = "Ver...";
            // 
            // anaToolStripMenuItem
            // 
            this.anaToolStripMenuItem.Name = "anaToolStripMenuItem";
            this.anaToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.anaToolStripMenuItem.Text = "TAS";
            this.anaToolStripMenuItem.Click += new System.EventHandler(this.anaToolStripMenuItem_Click);
            // 
            // tAASToolStripMenuItem
            // 
            this.tAASToolStripMenuItem.Name = "tAASToolStripMenuItem";
            this.tAASToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.tAASToolStripMenuItem.Text = "TAAS";
            this.tAASToolStripMenuItem.Click += new System.EventHandler(this.tAASToolStripMenuItem_Click);
            // 
            // grámaticaToolStripMenuItem
            // 
            this.grámaticaToolStripMenuItem.Name = "grámaticaToolStripMenuItem";
            this.grámaticaToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.grámaticaToolStripMenuItem.Text = "Grámatica";
            this.grámaticaToolStripMenuItem.Click += new System.EventHandler(this.grámaticaToolStripMenuItem_Click);
            // 
            // cuadruplosGrid
            // 
            this.cuadruplosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cuadruplosGrid.Location = new System.Drawing.Point(783, 266);
            this.cuadruplosGrid.Name = "cuadruplosGrid";
            this.cuadruplosGrid.RowTemplate.Height = 24;
            this.cuadruplosGrid.Size = new System.Drawing.Size(556, 322);
            this.cuadruplosGrid.TabIndex = 2;
            // 
            // tabsimGrid
            // 
            this.tabsimGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabsimGrid.Location = new System.Drawing.Point(783, 31);
            this.tabsimGrid.Name = "tabsimGrid";
            this.tabsimGrid.RowTemplate.Height = 24;
            this.tabsimGrid.Size = new System.Drawing.Size(299, 229);
            this.tabsimGrid.TabIndex = 3;
            // 
            // compilarB
            // 
            this.compilarB.Location = new System.Drawing.Point(1110, 87);
            this.compilarB.Name = "compilarB";
            this.compilarB.Size = new System.Drawing.Size(98, 51);
            this.compilarB.TabIndex = 4;
            this.compilarB.Text = "Compilar";
            this.compilarB.UseVisualStyleBackColor = true;
            this.compilarB.Click += new System.EventHandler(this.compilarB_Click);
            // 
            // ejecutaB
            // 
            this.ejecutaB.Enabled = false;
            this.ejecutaB.Location = new System.Drawing.Point(1110, 145);
            this.ejecutaB.Name = "ejecutaB";
            this.ejecutaB.Size = new System.Drawing.Size(98, 51);
            this.ejecutaB.TabIndex = 5;
            this.ejecutaB.Text = "Ejecutar";
            this.ejecutaB.UseVisualStyleBackColor = true;
            // 
            // highLvlB
            // 
            this.highLvlB.Enabled = false;
            this.highLvlB.Location = new System.Drawing.Point(1213, 145);
            this.highLvlB.Name = "highLvlB";
            this.highLvlB.Size = new System.Drawing.Size(98, 51);
            this.highLvlB.TabIndex = 6;
            this.highLvlB.Text = "Paso a Paso (Alto lvl)";
            this.highLvlB.UseVisualStyleBackColor = true;
            // 
            // lowLvlB
            // 
            this.lowLvlB.Enabled = false;
            this.lowLvlB.Location = new System.Drawing.Point(1213, 87);
            this.lowLvlB.Name = "lowLvlB";
            this.lowLvlB.Size = new System.Drawing.Size(98, 51);
            this.lowLvlB.TabIndex = 7;
            this.lowLvlB.Text = "Paso a Paso (Bajo lvl)";
            this.lowLvlB.UseVisualStyleBackColor = true;
            // 
            // programaText
            // 
            this.programaText.AcceptsTab = true;
            this.programaText.BackColor = System.Drawing.Color.DarkGray;
            this.programaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programaText.ForeColor = System.Drawing.Color.White;
            this.programaText.Location = new System.Drawing.Point(67, 31);
            this.programaText.Name = "programaText";
            this.programaText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.programaText.Size = new System.Drawing.Size(710, 557);
            this.programaText.TabIndex = 8;
            this.programaText.Text = "";
            this.programaText.TextChanged += new System.EventHandler(this.programaText_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.Location = new System.Drawing.Point(12, 31);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 561);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 604);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.programaText);
            this.Controls.Add(this.lowLvlB);
            this.Controls.Add(this.highLvlB);
            this.Controls.Add(this.ejecutaB);
            this.Controls.Add(this.compilarB);
            this.Controls.Add(this.tabsimGrid);
            this.Controls.Add(this.cuadruplosGrid);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cuadruplosGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabsimGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem abrirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem guardarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tablasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem anaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tAASToolStripMenuItem;
        private System.Windows.Forms.DataGridView cuadruplosGrid;
        private System.Windows.Forms.DataGridView tabsimGrid;
        private System.Windows.Forms.Button compilarB;
        private System.Windows.Forms.Button ejecutaB;
        private System.Windows.Forms.Button highLvlB;
        private System.Windows.Forms.Button lowLvlB;
        private System.Windows.Forms.RichTextBox programaText;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem grámaticaToolStripMenuItem;
    }
}

