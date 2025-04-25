using System;
using System.Windows.Forms;

namespace TrunksCommander
{
    public partial class NewFolderForm : Form
    {
        public string FolderName => textBox1.Text;

        public NewFolderForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nev = textBox1.Text;
            if (string.IsNullOrWhiteSpace(FolderName))
            {
                MessageBox.Show("Adj meg érvényes mappanevet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
            DialogResult = DialogResult.OK;
            MessageBox.Show("Beírt név: " + textBox1.Text);
            Close();
        }

        private void NewFolderForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
    }
}
