﻿namespace RubricaWin
{
    partial class Rubrica
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
            txtNome = new TextBox();
            txtCognome = new TextBox();
            txtTelefono = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            btnInserisci = new Button();
            lstContatti = new ListBox();
            btnModifica = new Button();
            SuspendLayout();
            // 
            // txtNome
            // 
            txtNome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtNome.Location = new Point(106, 48);
            txtNome.Name = "txtNome";
            txtNome.Size = new Size(300, 23);
            txtNome.TabIndex = 0;
            // 
            // txtCognome
            // 
            txtCognome.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtCognome.Location = new Point(106, 77);
            txtCognome.Name = "txtCognome";
            txtCognome.Size = new Size(300, 23);
            txtCognome.TabIndex = 1;
            // 
            // txtTelefono
            // 
            txtTelefono.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtTelefono.Location = new Point(106, 106);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(300, 23);
            txtTelefono.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 51);
            label1.Name = "label1";
            label1.Size = new Size(40, 15);
            label1.TabIndex = 3;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Cognome";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 106);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 5;
            label3.Text = "Telefono";
            // 
            // btnInserisci
            // 
            btnInserisci.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnInserisci.BackColor = Color.Turquoise;
            btnInserisci.Location = new Point(106, 153);
            btnInserisci.Name = "btnInserisci";
            btnInserisci.Size = new Size(300, 23);
            btnInserisci.TabIndex = 6;
            btnInserisci.Text = "Inserisci";
            btnInserisci.UseVisualStyleBackColor = false;
            btnInserisci.Click += btnInserisci_Click;
            // 
            // lstContatti
            // 
            lstContatti.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lstContatti.FormattingEnabled = true;
            lstContatti.ItemHeight = 15;
            lstContatti.Location = new Point(106, 229);
            lstContatti.Name = "lstContatti";
            lstContatti.Size = new Size(300, 364);
            lstContatti.TabIndex = 7;
            lstContatti.SelectedIndexChanged += lstContatti_SelectedIndexChanged;
            lstContatti.KeyPress += lstContatti_KeyPress;
            // 
            // btnModifica
            // 
            btnModifica.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnModifica.Location = new Point(106, 182);
            btnModifica.Name = "btnModifica";
            btnModifica.Size = new Size(300, 23);
            btnModifica.TabIndex = 8;
            btnModifica.Text = "Modifica";
            btnModifica.UseVisualStyleBackColor = true;
            btnModifica.Click += btnModifica_Click;
            // 
            // Rubrica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 631);
            Controls.Add(btnModifica);
            Controls.Add(lstContatti);
            Controls.Add(btnInserisci);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtTelefono);
            Controls.Add(txtCognome);
            Controls.Add(txtNome);
            Name = "Rubrica";
            Text = "Rubrica";
            Activated += Rubrica_Activated;
            FormClosed += Rubrica_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtNome;
        private TextBox txtCognome;
        private TextBox txtTelefono;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button btnInserisci;
        private ListBox lstContatti;
        private Button btnModifica;
    }
}