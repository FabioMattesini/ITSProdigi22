namespace WebServer
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
            btnAvvia = new Button();
            dlgCartella = new FolderBrowserDialog();
            txtPath = new TextBox();
            btnCartella = new Button();
            btnStop = new Button();
            SuspendLayout();
            // 
            // btnAvvia
            // 
            btnAvvia.Location = new Point(284, 179);
            btnAvvia.Name = "btnAvvia";
            btnAvvia.Size = new Size(97, 39);
            btnAvvia.TabIndex = 0;
            btnAvvia.Text = "Avvia";
            btnAvvia.UseVisualStyleBackColor = true;
            btnAvvia.Click += btnAvvia_Click;
            // 
            // txtPath
            // 
            txtPath.Location = new Point(244, 120);
            txtPath.Name = "txtPath";
            txtPath.ReadOnly = true;
            txtPath.Size = new Size(276, 23);
            txtPath.TabIndex = 1;
            // 
            // btnCartella
            // 
            btnCartella.Location = new Point(549, 120);
            btnCartella.Name = "btnCartella";
            btnCartella.Size = new Size(97, 23);
            btnCartella.TabIndex = 2;
            btnCartella.Text = "...";
            btnCartella.UseVisualStyleBackColor = true;
            btnCartella.Click += btnCartella_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(401, 179);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(97, 39);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnStop);
            Controls.Add(btnCartella);
            Controls.Add(txtPath);
            Controls.Add(btnAvvia);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAvvia;
        private FolderBrowserDialog dlgCartella;
        private TextBox txtPath;
        private Button btnCartella;
        private Button btnStop;
    }
}