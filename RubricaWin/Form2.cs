using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RubricaWin
{
    public partial class FormModifica : Form
    {
        Contatto daModificare;
        Rubrica rubrica;
        public FormModifica(Contatto daModificare, Rubrica rubrica)
        {
            InitializeComponent();
            this.daModificare = daModificare;
            this.rubrica = rubrica;
            txtModNome.Text = daModificare.nome;
            txtModCognome.Text = daModificare.cognome;
            txtModTelefono.Text = daModificare.telefono;
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            daModificare.nome = txtModNome.Text;
            daModificare.cognome = txtModCognome.Text;
            daModificare.telefono = txtModTelefono.Text;
            this.Close();
        }
    }
}
