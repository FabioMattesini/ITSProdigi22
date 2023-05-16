namespace NetServer
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
            numPorta = new NumericUpDown();
            btnAvvia = new Button();
            lstRichieste = new ListBox();
            txtPath = new TextBox();
            btnCartella = new Button();
            dlgCartella = new FolderBrowserDialog();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)numPorta).BeginInit();
            SuspendLayout();
            // 
            // numPorta
            // 
            numPorta.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numPorta.Location = new Point(668, 30);
            numPorta.Maximum = new decimal(new int[] { 65536, 0, 0, 0 });
            numPorta.Minimum = new decimal(new int[] { 80, 0, 0, 0 });
            numPorta.Name = "numPorta";
            numPorta.Size = new Size(120, 23);
            numPorta.TabIndex = 0;
            numPorta.Value = new decimal(new int[] { 80, 0, 0, 0 });
            // 
            // btnAvvia
            // 
            btnAvvia.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnAvvia.Location = new Point(12, 30);
            btnAvvia.Name = "btnAvvia";
            btnAvvia.Size = new Size(633, 23);
            btnAvvia.TabIndex = 1;
            btnAvvia.Text = "Avvia servizio";
            btnAvvia.UseVisualStyleBackColor = true;
            btnAvvia.Click += btnAvvia_Click;
            // 
            // lstRichieste
            // 
            lstRichieste.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstRichieste.FormattingEnabled = true;
            lstRichieste.IntegralHeight = false;
            lstRichieste.ItemHeight = 15;
            lstRichieste.Location = new Point(12, 164);
            lstRichieste.Name = "lstRichieste";
            lstRichieste.Size = new Size(776, 424);
            lstRichieste.TabIndex = 2;
            // 
            // txtPath
            // 
            txtPath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtPath.Location = new Point(12, 92);
            txtPath.Name = "txtPath";
            txtPath.ReadOnly = true;
            txtPath.Size = new Size(633, 23);
            txtPath.TabIndex = 3;
            // 
            // btnCartella
            // 
            btnCartella.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnCartella.Location = new Point(668, 92);
            btnCartella.Name = "btnCartella";
            btnCartella.Size = new Size(120, 23);
            btnCartella.TabIndex = 4;
            btnCartella.Text = "...";
            btnCartella.UseVisualStyleBackColor = true;
            btnCartella.Click += btnCartella_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 638);
            Controls.Add(btnCartella);
            Controls.Add(txtPath);
            Controls.Add(lstRichieste);
            Controls.Add(btnAvvia);
            Controls.Add(numPorta);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)numPorta).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown numPorta;
        private Button btnAvvia;
        private ListBox lstRichieste;
        private TextBox txtPath;
        private Button btnCartella;
        private FolderBrowserDialog dlgCartella;
        private System.Windows.Forms.Timer timer1;
    }
}