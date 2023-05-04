namespace RubricaWin
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
            btnCarica = new Button();
            btnVisualizza = new Button();
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
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 77);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Cognome";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 106);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 5;
            label3.Text = "Telefono";
            label3.Click += label3_Click;
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
            lstContatti.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstContatti.FormattingEnabled = true;
            lstContatti.ItemHeight = 15;
            lstContatti.Location = new Point(106, 314);
            lstContatti.Name = "lstContatti";
            lstContatti.Size = new Size(300, 184);
            lstContatti.TabIndex = 7;
            // 
            // btnCarica
            // 
            btnCarica.Location = new Point(106, 182);
            btnCarica.Name = "btnCarica";
            btnCarica.Size = new Size(224, 23);
            btnCarica.TabIndex = 8;
            btnCarica.Text = "Carica";
            btnCarica.UseVisualStyleBackColor = true;
            btnCarica.Click += btnCarica_Click;
            // 
            // btnVisualizza
            // 
            btnVisualizza.Location = new Point(106, 211);
            btnVisualizza.Name = "btnVisualizza";
            btnVisualizza.Size = new Size(224, 23);
            btnVisualizza.TabIndex = 9;
            btnVisualizza.Text = "Visualizza contatti";
            btnVisualizza.UseVisualStyleBackColor = true;
            btnVisualizza.Click += btnVisualizza_Click;
            // 
            // Rubrica
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(440, 631);
            Controls.Add(btnVisualizza);
            Controls.Add(btnCarica);
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
            FormClosed += Rubrica_FormClosed;
            Load += Form1_Load;
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
        private Button btnCarica;
        private Button btnVisualizza;
    }
}