namespace BloccoNote
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
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            mnuApri = new ToolStripMenuItem();
            mnuSalva = new ToolStripMenuItem();
            mnuEsci = new ToolStripMenuItem();
            opzioniToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            txtCorpo = new TextBox();
            dlgApri = new OpenFileDialog();
            dlgSalva = new SaveFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, opzioniToolStripMenuItem, toolStripMenuItem1 });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(856, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuApri, mnuSalva, mnuEsci });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "File";
            // 
            // mnuApri
            // 
            mnuApri.Name = "mnuApri";
            mnuApri.Size = new Size(101, 22);
            mnuApri.Text = "Apri";
            mnuApri.Click += mnuApri_Click;
            // 
            // mnuSalva
            // 
            mnuSalva.Name = "mnuSalva";
            mnuSalva.Size = new Size(101, 22);
            mnuSalva.Text = "Salva";
            mnuSalva.Click += mnuSalva_Click;
            // 
            // mnuEsci
            // 
            mnuEsci.Name = "mnuEsci";
            mnuEsci.Size = new Size(101, 22);
            mnuEsci.Text = "Esci";
            mnuEsci.Click += mnuEsci_Click;
            // 
            // opzioniToolStripMenuItem
            // 
            opzioniToolStripMenuItem.Name = "opzioniToolStripMenuItem";
            opzioniToolStripMenuItem.Size = new Size(60, 20);
            opzioniToolStripMenuItem.Text = "Opzioni";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(24, 20);
            toolStripMenuItem1.Text = "?";
            // 
            // txtCorpo
            // 
            txtCorpo.Dock = DockStyle.Fill;
            txtCorpo.Location = new Point(0, 24);
            txtCorpo.Multiline = true;
            txtCorpo.Name = "txtCorpo";
            txtCorpo.ScrollBars = ScrollBars.Vertical;
            txtCorpo.Size = new Size(856, 536);
            txtCorpo.TabIndex = 1;
            // 
            // dlgApri
            // 
            dlgApri.FileName = "openFileDialog1";
            dlgApri.Filter = "File di testo|*.txt|Tutti i file|*.*";
            // 
            // dlgSalva
            // 
            dlgSalva.Filter = "File di testo|*.txt|Tutti i file|*.*";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(856, 560);
            Controls.Add(txtCorpo);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem mnuApri;
        private ToolStripMenuItem mnuSalva;
        private ToolStripMenuItem mnuEsci;
        private ToolStripMenuItem opzioniToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private TextBox txtCorpo;
        private OpenFileDialog dlgApri;
        private SaveFileDialog dlgSalva;
    }
}