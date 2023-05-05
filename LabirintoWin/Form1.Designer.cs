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
            ((System.ComponentModel.ISupportInitialize)pctLabirinto).BeginInit();
            SuspendLayout();
            // 
            // pctLabirinto
            // 
            pctLabirinto.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            pctLabirinto.Location = new Point(12, 12);
            pctLabirinto.Name = "pctLabirinto";
            pctLabirinto.Size = new Size(468, 439);
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
            lstSoluzioni.Location = new Point(497, 12);
            lstSoluzioni.Name = "lstSoluzioni";
            lstSoluzioni.Size = new Size(291, 439);
            lstSoluzioni.TabIndex = 1;
            // 
            // btnRisolvi
            // 
            btnRisolvi.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRisolvi.Location = new Point(12, 477);
            btnRisolvi.Name = "btnRisolvi";
            btnRisolvi.Size = new Size(776, 39);
            btnRisolvi.TabIndex = 2;
            btnRisolvi.Text = "Risolvi";
            btnRisolvi.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 550);
            Controls.Add(btnRisolvi);
            Controls.Add(lstSoluzioni);
            Controls.Add(pctLabirinto);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pctLabirinto).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pctLabirinto;
        private ListBox lstSoluzioni;
        private Button btnRisolvi;
    }
}