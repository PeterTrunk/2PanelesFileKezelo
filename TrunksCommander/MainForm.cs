using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using TrunksCommander.Images;
using static TrunksCommander.Images.CustomFileManager;

namespace TrunksCommander
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private CustomFileManager FileManager;
        private Beallitasok Beallitasok;

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            Beallitasok = BeallitasKezelo.Betolt();
            FileManager = new CustomFileManager(LeftSideList, RightSideList, IkonLista, LeftPathBox,RightPathBox,LeftLabel,RightLabel,LeftOsszegLabel,RightOsszegLabel);
            
            ControlInicializacio(Beallitasok.AlapKonyvtar);
            TemaErvenyesit(Beallitasok.Tema);
        }
        private void ControlInicializacio(string Ut)
        {
            FileManager.BetoltKonyvtar(Ut, CustomFileManager.PanelSide.Bal, LeftLabel);
            FileManager.BetoltKonyvtar(Ut, CustomFileManager.PanelSide.Jobb, RightLabel);
            FrissitsMeghajtokComboBox(LeftDrives);
            FrissitsMeghajtokComboBox(RightDrives);
            FrissitsKijeloltMeretet(PanelSide.Bal);
            FrissitsKijeloltMeretet(PanelSide.Jobb);

        }
        private void Frissit()
        {
            FileManager.BetoltKonyvtar(LeftPathBox.Text, CustomFileManager.PanelSide.Bal, LeftLabel);
            FileManager.BetoltKonyvtar(RightPathBox.Text, CustomFileManager.PanelSide.Jobb, RightLabel);
        }

        #region Téma

        private void beállításokToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeallitasokForm Form = new BeallitasokForm(Beallitasok);
            if (Form.ShowDialog() == DialogResult.OK)
            {
                Beallitasok Uj = Form.Mentett;
                Beallitasok = Uj;
                TemaErvenyesit(Uj.Tema);
                BeallitasKezelo.Ment(Beallitasok);
            }
        }

        private void TemaErvenyesit(string Tema)
        {
            if (Tema == "vilagos")
                Szinez(Color.White,Color.Black);
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

        private void FrissitsKijeloltMeretet(PanelSide oldal)
        {
            var (db, meret) = FileManager.OsszKijeloltMeret(oldal);

            string text = $"{db} fájl kijelölve, összesen {FormatMeret(meret)}";
            if (oldal == PanelSide.Bal)
                LeftOsszegLabel.Text = text;
            else
                RightOsszegLabel.Text = text;
        }

        private string FormatMeret(long bytes)
        {
            if (bytes >= 1024 * 1024 * 1024)
                return (bytes / (1024 * 1024 * 1024.0)).ToString("0.00") + " GB";
            else if (bytes >= 1024 * 1024)
                return (bytes / (1024 * 1024.0)).ToString("0.00") + " MB";
            else if (bytes >= 1024)
                return (bytes / 1024.0).ToString("0.00") + " KB";
            else
                return bytes + " B";
        }

        #region Navigacio

        //NAVIGÁCIÓ

        private void LeftSideList_DoubleClick(object sender, EventArgs e)
        {
            LVDoubleClick(LeftSideList, PanelSide.Bal,LeftLabel);
        }

        private void RightSideList_DoubleClick(object sender, EventArgs e)
        {
            LVDoubleClick(RightSideList, PanelSide.Jobb,RightLabel);
        }
        
        private void LVDoubleClick(ListView lv, PanelSide oldal,Label label)
        {
            Valasztas(lv, oldal, label);
        }
        private void LVEnteresValasztas(ListView lv, PanelSide oldal, Label label)
        {
            Valasztas(lv, oldal, label);
        }
        private void Valasztas(ListView lv, PanelSide oldal, Label label)
        {
            if (lv.SelectedItems.Count == 0)
                return;

            ListViewItem kivalasztott = lv.SelectedItems[0];
            string nev = kivalasztott.SubItems[1].Text;
            string tipus = kivalasztott.SubItems[2].Text;

            if (nev == "[..]")
            {
                string aktualisUt = FileManager.GetCurrentDirectory(oldal);
                //?. operátor: null conditional operator, ha nem null érték akkor Fullname
                string szuloUt = Directory.GetParent(aktualisUt)?.FullName;

                if (!string.IsNullOrEmpty(szuloUt))
                    FileManager.BetoltKonyvtar(szuloUt, oldal, label);

                return;
            }

            if (tipus == "Könyvtár")
            {
                string aktualisUt = FileManager.GetCurrentDirectory(oldal);
                string ujUt = Path.Combine(aktualisUt, nev);

                FileManager.BetoltKonyvtar(ujUt, oldal, label);

                return;
            }

            Megnez();

        }
        
        private void FrissitsMeghajtokComboBox(ComboBox combo)
        {
            combo.Items.Clear();
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady)
                {
                    combo.Items.Add(drive.Name);
                }
            }
            //combo.SelectedIndex = 0;
        }

        private void LeftDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriveKivalaszt(LeftDrives, PanelSide.Bal, LeftLabel);
        }

        private void RightDrives_SelectedIndexChanged(object sender, EventArgs e)
        {
            DriveKivalaszt(RightDrives, PanelSide.Jobb, RightLabel);
        }

        private void DriveKivalaszt(ComboBox cb,CustomFileManager.PanelSide oldal,Label label)
        {
            string valasztottUt = cb.SelectedItem.ToString();
            FileManager.BetoltKonyvtar(valasztottUt, oldal,label);
        }

        private void LeftSideList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LVEnteresValasztas(LeftSideList, PanelSide.Bal, LeftLabel);
                e.Handled = true;
            }
        }

        private void RightSideList_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LVEnteresValasztas(RightSideList, PanelSide.Jobb, RightLabel);
                e.Handled = true;
            }
        }
        #endregion
        
        //Tuple - csoportosított adat
        private (PanelSide forras, PanelSide cel) GetAktivPanelpar()
        {
            bool balKijelolt = LeftSideList.SelectedItems.Count > 0;
            bool jobbKijelolt = RightSideList.SelectedItems.Count > 0;

            // Csak egyik oldalon van kijelölés
            if (balKijelolt && !jobbKijelolt)
                return (PanelSide.Bal, PanelSide.Jobb);

            if (jobbKijelolt && !balKijelolt)
                return (PanelSide.Jobb, PanelSide.Bal);

            // Mindkét oldalon van kijelölés → döntés fókusz alapján
            if (LeftSideList.Focused)
                return (PanelSide.Bal, PanelSide.Jobb);

            if (RightSideList.Focused)
                return (PanelSide.Jobb, PanelSide.Bal);

            // Ha semmi nincs kijelölve, fallback
            return (PanelSide.Bal, PanelSide.Jobb);
        }


        private void Masolas()
        {
            if (LeftSideList.SelectedItems.Count == 0 && RightSideList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nincs kijelölt fájl.");
                return;
            }
            var (forras, cel) = GetAktivPanelpar();
            //MessageBox.Show($"Forrás: {forras}, Cél: {cel}");
            FileManager.MasolVagyMozgatFajlokat(forras, cel, false);
        }

        private void Mozgatas()
        {
            if (LeftSideList.SelectedItems.Count == 0 && RightSideList.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nincs kijelölt fájl.");
                return;
            }
            var (forras, cel) = GetAktivPanelpar();
            //MessageBox.Show($"Forrás: {forras}, Cél: {cel}");
            FileManager.MasolVagyMozgatFajlokat(forras, cel, true);
        }

        private void UjMappa()
        {
            var (oldal, _) = GetAktivPanelpar();
            FileManager.LetrehozUjMappa(oldal);
        }

        private void Torles()
        {
            var (oldal, _) = GetAktivPanelpar();
            FileManager.TorolKijelolteket(oldal);
        }

        private void Megnez()
        {
            var (oldal, _) = GetAktivPanelpar();
            FileManager.SzerkesztVagyMegnez(oldal, false);
        }

        private void Szerkeszt()
        {
            var (oldal, _) = GetAktivPanelpar();
            FileManager.SzerkesztVagyMegnez(oldal, true);
        }

        #region Gombok, Frissítések, F-key Eventhandlerek

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ViewButton_Click(object sender, EventArgs e)
        {
            Megnez();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            Szerkeszt();
        }

        private void CopyButton_Click(object sender, EventArgs e)
        {
            Masolas();
        }

        private void MozgatButton_Click(object sender, EventArgs e)
        {
            Mozgatas();
        }

        private void NewFolderButton_Click(object sender, EventArgs e)
        {
            UjMappa();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Torles();
        }

        private void LeftSideList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LeftSideList.Focus();
            RightSideList.SelectedItems.Clear();
            FrissitsKijeloltMeretet(PanelSide.Bal);
        }

        private void RightSideList_SelectedIndexChanged(object sender, EventArgs e)
        {
            RightSideList.Focus();
            LeftSideList.SelectedItems.Clear();
            FrissitsKijeloltMeretet(PanelSide.Jobb);
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                Megnez();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.F4)
            {
                Szerkeszt();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.F5)
            {
                Masolas();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.F6)
            {
                Mozgatas();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.F7)
            {
                UjMappa();
                e.Handled = true;
            }
            if (e.KeyCode == Keys.F8)
            {
                Torles();
                e.Handled = true;
            }
        }

        private void viewF3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Megnez();
        }

        private void editF4ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Szerkeszt();
        }

        private void újMappaF7ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UjMappa();
        }

        private void törlésF8ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Torles();
        }

        private void copyF5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Masolas();
        }

        private void moveF6ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Mozgatas();
        }

        private void frissítésToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frissit();
        }
        
        #endregion


    }
}
