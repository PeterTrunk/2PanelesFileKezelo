using System;
using System.Drawing;
using System.Windows.Forms;

namespace TrunksCommander
{
    public partial class BeallitasokForm: Form
    {
        private Beallitasok Jelenlegi;

        public Beallitasok Mentett
        {
            get { return Jelenlegi;  }
        }

        public BeallitasokForm(Beallitasok Jelenlegi)
        {
            InitializeComponent();
            this.Jelenlegi = Jelenlegi;
            ControlKitolt();
            TemaErvenyesit(Jelenlegi.Tema);
        }
        public void ControlKitolt()
        {
            TemaComboBox.Items.Add("Világos");
            TemaComboBox.Items.Add("Sötét");

            if (Jelenlegi.Tema == "vilagos")
                TemaComboBox.SelectedIndex = 0;
            else
                TemaComboBox.SelectedIndex = 1;

            KonyvtarTextBox.Text = Jelenlegi.AlapKonyvtar;

        }

        private void TallozButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog Talloz = new FolderBrowserDialog();
            Talloz.Description = "Válassza ki az új kezdő könyvtárat!";
            string eleres;
            if (Talloz.ShowDialog() == DialogResult.OK)
            {
                eleres = Talloz.SelectedPath;
                KonyvtarTextBox.Text = eleres;
                Jelenlegi.AlapKonyvtar = eleres;
            }
        }

        private void MentesButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        #region Téma

        private void TemaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (TemaComboBox.SelectedIndex == 0)
                Jelenlegi.Tema = "vilagos";
            else
                Jelenlegi.Tema = "sotet";
            TemaErvenyesit(Jelenlegi.Tema);
        }

        private void TemaErvenyesit(string Tema)
        {
            if (Tema == "vilagos")
                Szinez(Color.White, Color.Black);
            else
                Szinez(Color.FromArgb(30, 30, 30), Color.White);
        }

        private void Szinez(Color Hatter, Color Betu)
        {
            BackColor = Hatter;

            foreach (Control ctrl in Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Hatter;
                    btn.ForeColor = Betu;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderColor = Color.Gray;
                }
                else if (ctrl is Label lbl)
                {
                    lbl.ForeColor = Betu;
                    lbl.BackColor = Color.Transparent;
                }
                else if (ctrl is TextBox tb)
                {
                    tb.BackColor = Hatter;
                    tb.ForeColor = Betu;
                    tb.BorderStyle = BorderStyle.FixedSingle;
                }
                else if (ctrl is ComboBox cb)
                {
                    cb.BackColor = Hatter;
                    cb.ForeColor = Betu;
                    cb.FlatStyle = FlatStyle.Flat;
                    cb.DropDownStyle = ComboBoxStyle.DropDownList;
                }
                else if (ctrl is ListView lv)
                {
                    lv.BackColor = Hatter;
                    lv.ForeColor = Betu;
                    lv.GridLines = true;
                    lv.FullRowSelect = true;

                }
                else if (ctrl is MenuStrip ms)
                {
                    ms.BackColor = Hatter;
                    ms.ForeColor = Betu;
                    ms.RenderMode = ToolStripRenderMode.System;
                }
                else if (ctrl is ToolStrip tool)
                {
                    tool.BackColor = Hatter;
                    tool.ForeColor = Betu;
                }
            }
        }

        #endregion
    }
}
