namespace LabirintoWin
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
            pctLabirinto = new PictureBox();
            lstSoluzioni = new ListBox();
            btnRisolvi = new Button();
            menuStrip1 = new MenuStrip();
            mnuSalva = new ToolStripMenuItem();
            mnuApri = new ToolStripMenuItem();
            cancellaToolStripMenuItem = new ToolStripMenuItem();
            mnuPenna = new ToolStripMenuItem();
            mnuGomma = new ToolStripMenuItem();
            dlgSalva = new SaveFileDialog();
            dlgApri = new OpenFileDialog();
            colorDialog1 = new ColorDialog();
            ((System.ComponentModel.ISupportInitialize)pctLabirinto).BeginInit();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // pctLabirinto
            // 
            pctLabirinto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pctLabirinto.Location = new Point(12, 40);
            pctLabirinto.Name = "pctLabirinto";
            pctLabirinto.Size = new Size(468, 447);
            pctLabirinto.TabIndex = 0;
            pctLabirinto.TabStop = false;
            pctLabirinto.MouseMove += pctLabirinto_MouseMove;
            // 
            // lstSoluzioni
            // 
            lstSoluzioni.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstSoluzioni.FormattingEnabled = true;
            lstSoluzioni.IntegralHeight = false;
            lstSoluzioni.ItemHeight = 15;
            lstSoluzioni.Location = new Point(497, 40);
            lstSoluzioni.Name = "lstSoluzioni";
            lstSoluzioni.Size = new Size(291, 447);
            lstSoluzioni.TabIndex = 1;
            // 
            // btnRisolvi
            // 
            btnRisolvi.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRisolvi.Location = new Point(12, 513);
            btnRisolvi.Name = "btnRisolvi";
            btnRisolvi.Size = new Size(776, 39);
            btnRisolvi.TabIndex = 2;
            btnRisolvi.Text = "Risolvi";
            btnRisolvi.UseVisualStyleBackColor = true;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { mnuSalva, mnuApri, cancellaToolStripMenuItem, mnuPenna, mnuGomma });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // mnuSalva
            // 
            mnuSalva.Name = "mnuSalva";
            mnuSalva.Size = new Size(46, 20);
            mnuSalva.Text = "Salva";
            mnuSalva.Click += mnuSalva_Click;
            // 
            // mnuApri
            // 
            mnuApri.Name = "mnuApri";
            mnuApri.Size = new Size(41, 20);
            mnuApri.Text = "Apri";
            mnuApri.Click += mnuApri_Click;
            // 
            // cancellaToolStripMenuItem
            // 
            cancellaToolStripMenuItem.Name = "cancellaToolStripMenuItem";
            cancellaToolStripMenuItem.Size = new Size(64, 20);
            cancellaToolStripMenuItem.Text = "Cancella";
            cancellaToolStripMenuItem.Click += cancellaToolStripMenuItem_Click;
            // 
            // mnuPenna
            // 
            mnuPenna.Name = "mnuPenna";
            mnuPenna.Size = new Size(52, 20);
            mnuPenna.Text = "Penna";
            mnuPenna.Click += mnuPenna_Click;
            // 
            // mnuGomma
            // 
            mnuGomma.Name = "mnuGomma";
            mnuGomma.Size = new Size(62, 20);
            mnuGomma.Text = "Gomma";
            mnuGomma.Click += mnuGomma_Click;
            // 
            // dlgSalva
            // 
            dlgSalva.Filter = "Immagine|*.jpg|Tutti i file|*.*";
            // 
            // dlgApri
            // 
            dlgApri.FileName = "openFileDialog1";
            dlgApri.Filter = "Immagine|*.jpg|Tutti i file|*.*";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 586);
            Controls.Add(btnRisolvi);
            Controls.Add(lstSoluzioni);
            Controls.Add(pctLabirinto);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pctLabirinto).EndInit();
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pctLabirinto;
        private ListBox lstSoluzioni;
        private Button btnRisolvi;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem mnuSalva;
        private ToolStripMenuItem mnuApri;
        private SaveFileDialog dlgSalva;
        private OpenFileDialog dlgApri;
        private ToolStripMenuItem cancellaToolStripMenuItem;
        private ToolStripMenuItem mnuPenna;
        private ToolStripMenuItem mnuGomma;
        private ColorDialog colorDialog1;
    }
}