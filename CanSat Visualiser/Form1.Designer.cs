namespace CanSat_Visualiser
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            altGraph = new ScottPlot.WinForms.FormsPlot();
            pressureGraph = new ScottPlot.WinForms.FormsPlot();
            alt_graph_lbl = new Label();
            pressure_graph_lbl = new Label();
            tempGraph = new ScottPlot.WinForms.FormsPlot();
            temp_graph_lbl = new Label();
            alt_txt = new TextBox();
            pressure_txt = new TextBox();
            alt_lbl = new Label();
            pressure_lbl = new Label();
            gps_lbl = new Label();
            temp_lbl = new Label();
            gps_txt = new TextBox();
            temp_txt = new TextBox();
            imageList1 = new ImageList(components);
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            importToolStripMenuItem = new ToolStripMenuItem();
            gps_map_lbl = new Label();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // altGraph
            // 
            altGraph.DisplayScale = 1F;
            altGraph.Location = new Point(268, 59);
            altGraph.Name = "altGraph";
            altGraph.Size = new Size(250, 200);
            altGraph.TabIndex = 0;
            altGraph.Load += altGraph_Load;
            // 
            // pressureGraph
            // 
            pressureGraph.DisplayScale = 1F;
            pressureGraph.Location = new Point(524, 59);
            pressureGraph.Name = "pressureGraph";
            pressureGraph.Size = new Size(250, 200);
            pressureGraph.TabIndex = 1;
            // 
            // alt_graph_lbl
            // 
            alt_graph_lbl.AutoSize = true;
            alt_graph_lbl.Location = new Point(298, 41);
            alt_graph_lbl.Name = "alt_graph_lbl";
            alt_graph_lbl.Size = new Size(84, 15);
            alt_graph_lbl.TabIndex = 2;
            alt_graph_lbl.Text = "Altitude Graph";
            // 
            // pressure_graph_lbl
            // 
            pressure_graph_lbl.AutoSize = true;
            pressure_graph_lbl.Location = new Point(544, 41);
            pressure_graph_lbl.Name = "pressure_graph_lbl";
            pressure_graph_lbl.Size = new Size(86, 15);
            pressure_graph_lbl.TabIndex = 3;
            pressure_graph_lbl.Text = "Pressure Graph";
            // 
            // tempGraph
            // 
            tempGraph.DisplayScale = 1F;
            tempGraph.Location = new Point(268, 312);
            tempGraph.Name = "tempGraph";
            tempGraph.Size = new Size(250, 200);
            tempGraph.TabIndex = 4;
            // 
            // temp_graph_lbl
            // 
            temp_graph_lbl.AutoSize = true;
            temp_graph_lbl.Location = new Point(298, 294);
            temp_graph_lbl.Name = "temp_graph_lbl";
            temp_graph_lbl.Size = new Size(108, 15);
            temp_graph_lbl.TabIndex = 5;
            temp_graph_lbl.Text = "Temperature Graph";
            // 
            // alt_txt
            // 
            alt_txt.Location = new Point(544, 312);
            alt_txt.Name = "alt_txt";
            alt_txt.ReadOnly = true;
            alt_txt.Size = new Size(230, 23);
            alt_txt.TabIndex = 6;
            // 
            // pressure_txt
            // 
            pressure_txt.Location = new Point(544, 367);
            pressure_txt.Name = "pressure_txt";
            pressure_txt.ReadOnly = true;
            pressure_txt.Size = new Size(230, 23);
            pressure_txt.TabIndex = 7;
            // 
            // alt_lbl
            // 
            alt_lbl.AutoSize = true;
            alt_lbl.Location = new Point(544, 294);
            alt_lbl.Name = "alt_lbl";
            alt_lbl.Size = new Size(95, 15);
            alt_lbl.TabIndex = 8;
            alt_lbl.Text = "Current Altitude:";
            // 
            // pressure_lbl
            // 
            pressure_lbl.AutoSize = true;
            pressure_lbl.Location = new Point(544, 349);
            pressure_lbl.Name = "pressure_lbl";
            pressure_lbl.Size = new Size(94, 15);
            pressure_lbl.TabIndex = 9;
            pressure_lbl.Text = "Current Pressure";
            // 
            // gps_lbl
            // 
            gps_lbl.AutoSize = true;
            gps_lbl.Location = new Point(544, 467);
            gps_lbl.Name = "gps_lbl";
            gps_lbl.Size = new Size(108, 15);
            gps_lbl.TabIndex = 13;
            gps_lbl.Text = "Exact GPS location:";
            // 
            // temp_lbl
            // 
            temp_lbl.AutoSize = true;
            temp_lbl.Location = new Point(544, 412);
            temp_lbl.Name = "temp_lbl";
            temp_lbl.Size = new Size(119, 15);
            temp_lbl.TabIndex = 12;
            temp_lbl.Text = "Current Temperature:";
            // 
            // gps_txt
            // 
            gps_txt.Location = new Point(544, 485);
            gps_txt.Name = "gps_txt";
            gps_txt.ReadOnly = true;
            gps_txt.Size = new Size(230, 23);
            gps_txt.TabIndex = 11;
            // 
            // temp_txt
            // 
            temp_txt.Location = new Point(544, 430);
            temp_txt.Name = "temp_txt";
            temp_txt.ReadOnly = true;
            temp_txt.Size = new Size(230, 23);
            temp_txt.TabIndex = 10;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // webView21
            // 
            webView21.AllowExternalDrop = true;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.White;
            webView21.Location = new Point(14, 73);
            webView21.Name = "webView21";
            webView21.Size = new Size(248, 435);
            webView21.TabIndex = 15;
            webView21.ZoomFactor = 1D;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(784, 24);
            menuStrip1.TabIndex = 16;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { importToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // importToolStripMenuItem
            // 
            importToolStripMenuItem.Name = "importToolStripMenuItem";
            importToolStripMenuItem.Size = new Size(110, 22);
            importToolStripMenuItem.Text = "Import";
            importToolStripMenuItem.Click += importToolStripMenuItem_Click_1;
            // 
            // gps_map_lbl
            // 
            gps_map_lbl.AutoSize = true;
            gps_map_lbl.Location = new Point(14, 41);
            gps_map_lbl.Name = "gps_map_lbl";
            gps_map_lbl.Size = new Size(55, 15);
            gps_map_lbl.TabIndex = 17;
            gps_map_lbl.Text = "GPS Map";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(784, 542);
            Controls.Add(gps_map_lbl);
            Controls.Add(webView21);
            Controls.Add(gps_lbl);
            Controls.Add(temp_lbl);
            Controls.Add(gps_txt);
            Controls.Add(temp_txt);
            Controls.Add(pressure_lbl);
            Controls.Add(alt_lbl);
            Controls.Add(pressure_txt);
            Controls.Add(alt_txt);
            Controls.Add(temp_graph_lbl);
            Controls.Add(tempGraph);
            Controls.Add(pressure_graph_lbl);
            Controls.Add(alt_graph_lbl);
            Controls.Add(pressureGraph);
            Controls.Add(altGraph);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ScottPlot.WinForms.FormsPlot altGraph;
        private ScottPlot.WinForms.FormsPlot pressureGraph;
        private Label alt_graph_lbl;
        private Label pressure_graph_lbl;
        private ScottPlot.WinForms.FormsPlot tempGraph;
        private Label temp_graph_lbl;
        private TextBox alt_txt;
        private TextBox pressure_txt;
        private Label alt_lbl;
        private Label pressure_lbl;
        private Label gps_lbl;
        private Label temp_lbl;
        private TextBox gps_txt;
        private TextBox temp_txt;
        private ImageList imageList1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem importToolStripMenuItem;
        private Label gps_map_lbl;
    }
}