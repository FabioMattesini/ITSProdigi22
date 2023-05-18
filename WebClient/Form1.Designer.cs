namespace WebClient
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
            txtURL = new TextBox();
            btnVai = new Button();
            lstParole = new ListBox();
            SuspendLayout();
            // 
            // txtURL
            // 
            txtURL.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtURL.Location = new Point(150, 67);
            txtURL.Name = "txtURL";
            txtURL.Size = new Size(437, 23);
            txtURL.TabIndex = 0;
            // 
            // btnVai
            // 
            btnVai.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnVai.Location = new Point(635, 67);
            btnVai.Name = "btnVai";
            btnVai.Size = new Size(107, 23);
            btnVai.TabIndex = 1;
            btnVai.Text = "Vai";
            btnVai.UseVisualStyleBackColor = true;
            btnVai.Click += btnVai_Click;
            // 
            // lstParole
            // 
            lstParole.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstParole.FormattingEnabled = true;
            lstParole.IntegralHeight = false;
            lstParole.ItemHeight = 15;
            lstParole.Location = new Point(150, 116);
            lstParole.Name = "lstParole";
            lstParole.Size = new Size(437, 298);
            lstParole.TabIndex = 2;
            lstParole.SelectedIndexChanged += listBox1_SelectedIndexChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(944, 450);
            Controls.Add(lstParole);
            Controls.Add(btnVai);
            Controls.Add(txtURL);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtURL;
        private Button btnVai;
        private ListBox lstParole;
    }
}