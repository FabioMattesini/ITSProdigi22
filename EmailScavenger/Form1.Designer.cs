namespace EmailScavenger
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
            txtIndirizzo = new TextBox();
            btnAnalizza = new Button();
            lstRisultati = new ListBox();
            SuspendLayout();
            // 
            // txtIndirizzo
            // 
            txtIndirizzo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtIndirizzo.Location = new Point(12, 24);
            txtIndirizzo.Name = "txtIndirizzo";
            txtIndirizzo.PlaceholderText = "indirizzo...";
            txtIndirizzo.Size = new Size(462, 23);
            txtIndirizzo.TabIndex = 0;
            // 
            // btnAnalizza
            // 
            btnAnalizza.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAnalizza.Location = new Point(502, 23);
            btnAnalizza.Name = "btnAnalizza";
            btnAnalizza.Size = new Size(75, 23);
            btnAnalizza.TabIndex = 1;
            btnAnalizza.Text = "Analizza";
            btnAnalizza.UseVisualStyleBackColor = true;
            btnAnalizza.Click += btnAnalizza_Click;
            // 
            // lstRisultati
            // 
            lstRisultati.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstRisultati.FormattingEnabled = true;
            lstRisultati.IntegralHeight = false;
            lstRisultati.ItemHeight = 15;
            lstRisultati.Location = new Point(12, 66);
            lstRisultati.Name = "lstRisultati";
            lstRisultati.Size = new Size(565, 520);
            lstRisultati.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(615, 611);
            Controls.Add(lstRisultati);
            Controls.Add(btnAnalizza);
            Controls.Add(txtIndirizzo);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtIndirizzo;
        private Button btnAnalizza;
        private ListBox lstRisultati;
    }
}