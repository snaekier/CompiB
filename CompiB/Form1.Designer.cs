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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
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
            this.LineNumberTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cuadruplosGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabsimGrid)).BeginInit();
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
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1371, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // abrirToolStripMenuItem
            // 
            this.abrirToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("abrirToolStripMenuItem.Image")));
            this.abrirToolStripMenuItem.Name = "abrirToolStripMenuItem";
            this.abrirToolStripMenuItem.Size = new System.Drawing.Size(74, 24);
            this.abrirToolStripMenuItem.Text = "Abrir";
            this.abrirToolStripMenuItem.Click += new System.EventHandler(this.abrirToolStripMenuItem_Click);
            // 
            // guardarToolStripMenuItem
            // 
            this.guardarToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("guardarToolStripMenuItem.Image")));
            this.guardarToolStripMenuItem.Name = "guardarToolStripMenuItem";
            this.guardarToolStripMenuItem.Size = new System.Drawing.Size(94, 24);
            this.guardarToolStripMenuItem.Text = "Guardar";
            this.guardarToolStripMenuItem.Click += new System.EventHandler(this.guardarToolStripMenuItem_Click);
            // 
            // tablasToolStripMenuItem
            // 
            this.tablasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.anaToolStripMenuItem,
            this.tAASToolStripMenuItem,
            this.grámaticaToolStripMenuItem});
            this.tablasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tablasToolStripMenuItem.Image")));
            this.tablasToolStripMenuItem.Name = "tablasToolStripMenuItem";
            this.tablasToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.tablasToolStripMenuItem.Text = "Ver...";
            // 
            // anaToolStripMenuItem
            // 
            this.anaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("anaToolStripMenuItem.Image")));
            this.anaToolStripMenuItem.Name = "anaToolStripMenuItem";
            this.anaToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.anaToolStripMenuItem.Text = "TAS";
            this.anaToolStripMenuItem.Click += new System.EventHandler(this.anaToolStripMenuItem_Click);
            // 
            // tAASToolStripMenuItem
            // 
            this.tAASToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("tAASToolStripMenuItem.Image")));
            this.tAASToolStripMenuItem.Name = "tAASToolStripMenuItem";
            this.tAASToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.tAASToolStripMenuItem.Text = "TAAS";
            this.tAASToolStripMenuItem.Click += new System.EventHandler(this.tAASToolStripMenuItem_Click);
            // 
            // grámaticaToolStripMenuItem
            // 
            this.grámaticaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("grámaticaToolStripMenuItem.Image")));
            this.grámaticaToolStripMenuItem.Name = "grámaticaToolStripMenuItem";
            this.grámaticaToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.grámaticaToolStripMenuItem.Text = "Grámatica";
            this.grámaticaToolStripMenuItem.Click += new System.EventHandler(this.grámaticaToolStripMenuItem_Click);
            // 
            // cuadruplosGrid
            // 
            this.cuadruplosGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.cuadruplosGrid.Location = new System.Drawing.Point(783, 266);
            this.cuadruplosGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cuadruplosGrid.MultiSelect = false;
            this.cuadruplosGrid.Name = "cuadruplosGrid";
            this.cuadruplosGrid.ReadOnly = true;
            this.cuadruplosGrid.RowTemplate.Height = 24;
            this.cuadruplosGrid.Size = new System.Drawing.Size(556, 322);
            this.cuadruplosGrid.TabIndex = 2;
            // 
            // tabsimGrid
            // 
            this.tabsimGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabsimGrid.Location = new System.Drawing.Point(783, 31);
            this.tabsimGrid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tabsimGrid.Name = "tabsimGrid";
            this.tabsimGrid.ReadOnly = true;
            this.tabsimGrid.RowTemplate.Height = 24;
            this.tabsimGrid.Size = new System.Drawing.Size(299, 229);
            this.tabsimGrid.TabIndex = 3;
            // 
            // compilarB
            // 
            this.compilarB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.compilarB.Image = ((System.Drawing.Image)(resources.GetObject("compilarB.Image")));
            this.compilarB.Location = new System.Drawing.Point(1108, 31);
            this.compilarB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.compilarB.Name = "compilarB";
            this.compilarB.Size = new System.Drawing.Size(104, 57);
            this.compilarB.TabIndex = 4;
            this.compilarB.UseVisualStyleBackColor = false;
            this.compilarB.Click += new System.EventHandler(this.compilarB_Click);
            // 
            // ejecutaB
            // 
            this.ejecutaB.BackColor = System.Drawing.Color.Orange;
            this.ejecutaB.Enabled = false;
            this.ejecutaB.Image = ((System.Drawing.Image)(resources.GetObject("ejecutaB.Image")));
            this.ejecutaB.Location = new System.Drawing.Point(1108, 89);
            this.ejecutaB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ejecutaB.Name = "ejecutaB";
            this.ejecutaB.Size = new System.Drawing.Size(104, 57);
            this.ejecutaB.TabIndex = 5;
            this.ejecutaB.Tag = "Ejecuta";
            this.ejecutaB.UseVisualStyleBackColor = false;
            this.ejecutaB.Click += new System.EventHandler(this.ejecutaB_Click);
            // 
            // highLvlB
            // 
            this.highLvlB.BackColor = System.Drawing.Color.LightCoral;
            this.highLvlB.Enabled = false;
            this.highLvlB.Image = ((System.Drawing.Image)(resources.GetObject("highLvlB.Image")));
            this.highLvlB.Location = new System.Drawing.Point(1108, 204);
            this.highLvlB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.highLvlB.Name = "highLvlB";
            this.highLvlB.Size = new System.Drawing.Size(104, 57);
            this.highLvlB.TabIndex = 6;
            this.highLvlB.UseVisualStyleBackColor = false;
            this.highLvlB.Click += new System.EventHandler(this.highLvlB_Click);
            // 
            // lowLvlB
            // 
            this.lowLvlB.BackColor = System.Drawing.Color.LightYellow;
            this.lowLvlB.Enabled = false;
            this.lowLvlB.Image = ((System.Drawing.Image)(resources.GetObject("lowLvlB.Image")));
            this.lowLvlB.Location = new System.Drawing.Point(1108, 146);
            this.lowLvlB.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lowLvlB.Name = "lowLvlB";
            this.lowLvlB.Size = new System.Drawing.Size(104, 57);
            this.lowLvlB.TabIndex = 7;
            this.lowLvlB.UseVisualStyleBackColor = false;
            this.lowLvlB.Click += new System.EventHandler(this.lowLvlB_Click);
            // 
            // programaText
            // 
            this.programaText.AcceptsTab = true;
            this.programaText.BackColor = System.Drawing.Color.DarkGray;
            this.programaText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.programaText.ForeColor = System.Drawing.Color.White;
            this.programaText.Location = new System.Drawing.Point(67, 31);
            this.programaText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.programaText.Name = "programaText";
            this.programaText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.programaText.Size = new System.Drawing.Size(711, 557);
            this.programaText.TabIndex = 8;
            this.programaText.Text = "";
            this.programaText.SelectionChanged += new System.EventHandler(this.programaText_SelectionChanged_1);
            this.programaText.VScroll += new System.EventHandler(this.programaText_VScroll);
            this.programaText.TextChanged += new System.EventHandler(this.programaText_TextChanged);
            this.programaText.Resize += new System.EventHandler(this.programaText_Resize);
            // 
            // LineNumberTextBox
            // 
            this.LineNumberTextBox.Location = new System.Drawing.Point(14, 31);
            this.LineNumberTextBox.Name = "LineNumberTextBox";
            this.LineNumberTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LineNumberTextBox.Size = new System.Drawing.Size(47, 557);
            this.LineNumberTextBox.TabIndex = 10;
            this.LineNumberTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1233, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Ejecutar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1233, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Compilar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1234, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(0, 17);
            this.label3.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1220, 217);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "Paso a Paso";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1234, 234);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "(Alto lvl)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1234, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 17);
            this.label6.TabIndex = 17;
            this.label6.Text = "(Bajo lvl)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1220, 160);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 17);
            this.label7.TabIndex = 16;
            this.label7.Text = "Paso a Paso";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1371, 604);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.programaText);
            this.Controls.Add(this.lowLvlB);
            this.Controls.Add(this.highLvlB);
            this.Controls.Add(this.ejecutaB);
            this.Controls.Add(this.compilarB);
            this.Controls.Add(this.tabsimGrid);
            this.Controls.Add(this.cuadruplosGrid);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.LineNumberTextBox);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Compilador 2018-2019 II";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cuadruplosGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabsimGrid)).EndInit();
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
        private System.Windows.Forms.ToolStripMenuItem grámaticaToolStripMenuItem;
        private System.Windows.Forms.RichTextBox LineNumberTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
    }
}

