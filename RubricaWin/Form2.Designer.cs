namespace RubricaWin
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtModNome = new TextBox();
            txtModCognome = new TextBox();
            txtModTelefono = new TextBox();
            lblNome = new Label();
            lblCognome = new Label();
            lblTelefono = new Label();
            btnModifica = new Button();
            SuspendLayout();
            // 
            // txtModNome
            // 
            txtModNome.Location = new Point(133, 53);
            txtModNome.Name = "txtModNome";
            txtModNome.Size = new Size(151, 23);
            txtModNome.TabIndex = 0;
            // 
            // txtModCognome
            // 
            txtModCognome.Location = new Point(133, 82);
            txtModCognome.Name = "txtModCognome";
            txtModCognome.Size = new Size(151, 23);
            txtModCognome.TabIndex = 1;
            // 
            // txtModTelefono
            // 
            txtModTelefono.Location = new Point(133, 111);
            txtModTelefono.Name = "txtModTelefono";
            txtModTelefono.Size = new Size(151, 23);
            txtModTelefono.TabIndex = 2;
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Location = new Point(64, 56);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(40, 15);
            lblNome.TabIndex = 3;
            lblNome.Text = "Nome";
            // 
            // lblCognome
            // 
            lblCognome.AutoSize = true;
            lblCognome.Location = new Point(64, 90);
            lblCognome.Name = "lblCognome";
            lblCognome.Size = new Size(60, 15);
            lblCognome.TabIndex = 4;
            lblCognome.Text = "Cognome";
            lblCognome.Click += txtCognome_Click;
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(64, 119);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(52, 15);
            lblTelefono.TabIndex = 5;
            lblTelefono.Text = "Telefono";
            // 
            // btnModifica
            // 
            btnModifica.Location = new Point(165, 167);
            btnModifica.Name = "btnModifica";
            btnModifica.Size = new Size(75, 23);
            btnModifica.TabIndex = 6;
            btnModifica.Text = "Modifica";
            btnModifica.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(370, 239);
            Controls.Add(btnModifica);
            Controls.Add(lblTelefono);
            Controls.Add(lblCognome);
            Controls.Add(lblNome);
            Controls.Add(txtModTelefono);
            Controls.Add(txtModCognome);
            Controls.Add(txtModNome);
            Name = "Form2";
            Text = "Form2";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtModNome;
        private TextBox txtModCognome;
        private TextBox txtModTelefono;
        private Label lblNome;
        private Label lblCognome;
        private Label lblTelefono;
        private Button btnModifica;
    }
}