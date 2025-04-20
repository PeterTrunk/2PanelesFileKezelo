using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace TrunksCommander.Images
{
    internal class CustomFileManager : IFileManager
    {
        ListView BalLV;
        ListView JobbLV;
        ImageList IkonLista;
        TextBox BalTB;
        TextBox JobbTB;
        Label BalLabel;
        Label JobbLabel;
        Label BalMeretLabel;
        Label JobbMeretLabel;

        public enum PanelSide
        {
            Bal,
            Jobb
        }

        public CustomFileManager(ListView BalLV, ListView JobbLV, ImageList IkonLista, TextBox BalTB, TextBox JobbTB, Label BalLabel, Label JobbLabel, Label BalMeretLabel, Label JobbMeretLabel)
        {
            this.BalLV = BalLV;
            this.JobbLV = JobbLV;
            this.IkonLista = IkonLista;
            this.BalTB = BalTB;
            this.JobbTB = JobbTB;
            ListViewElokeszit(BalLV);
            ListViewElokeszit(JobbLV);
            this.BalLabel = BalLabel;
            this.JobbLabel = JobbLabel;
            this.BalMeretLabel = BalMeretLabel;
            this.JobbMeretLabel = JobbMeretLabel;
        }

        private void ListViewElokeszit(ListView lv)
        {
            lv.View = View.Details;
            lv.FullRowSelect = true;
            lv.GridLines = true;
            lv.SmallImageList = IkonLista;
        }

        public void BetoltKonyvtar(string eleres, PanelSide oldal,Label label)
        {
            ListView celListView = oldal == PanelSide.Bal ? BalLV : JobbLV;
            celListView.Items.Clear();
            try
            {
                DirectoryInfo teszt = new DirectoryInfo(eleres);
                if (teszt.Parent != null) //Root dir.-nek nincs Parentje
                {
                    var item = new ListViewItem();
                    item.ImageKey = "back.ico";
                    item.SubItems.Add("[..]");
                    item.SubItems.Add("Könyvtár");
                    item.SubItems.Add("");
                    item.SubItems.Add("");

                    celListView.Items.Add(item);
                }
                
                int mappaCount = Directory.GetDirectories(eleres).Length;
                foreach (string mappa in Directory.GetDirectories(eleres))
                {
                    DirectoryInfo info = new DirectoryInfo(mappa);
                    var item = new ListViewItem();
                    item.ImageKey = "folder.ico";
                    item.SubItems.Add(info.Name);
                    item.SubItems.Add("Könyvtár");
                    item.SubItems.Add("");
                    item.SubItems.Add(info.LastWriteTime.ToString("yyyy.MM.dd HH:mm"));

                    celListView.Items.Add(item);
                }
                
                int fajlCount = Directory.GetFiles(eleres).Length;
                foreach (string fajl in Directory.GetFiles(eleres))
                {
                    FileInfo info = new FileInfo(fajl);
                    string kiterjesztes = info.Extension.ToLower();
                    string ikon = GetIkonKey(kiterjesztes);

                    var item = new ListViewItem();
                    item.ImageKey = ikon;
                    item.SubItems.Add(info.Name);
                    item.SubItems.Add(kiterjesztes);
                    item.SubItems.Add((info.Length / 1024) + " KB");
                    item.SubItems.Add(info.LastWriteTime.ToString("yyyy.MM.dd HH:mm"));

                    celListView.Items.Add(item);
                }
                if (oldal == PanelSide.Bal)
                    BalTB.Text = eleres;
                else
                    JobbTB.Text = eleres;
                label.Text = string.Format("{0} könyvtár; {1} file",mappaCount,fajlCount);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hiba a könyvtár betöltésekor:\n{ex.Message}");
            }

            if (oldal == PanelSide.Bal)
                BalTB.Text = eleres;
            else
                JobbTB.Text = eleres;
        }

        #region Általábos segítő fgv-k

        private string GetEgyediFajlNev(string celKonyvtar, string fajlNev)
        {
            //Windowshoz hasonlóan írja oda: filenév másolata, filenév másolata (1)...
            string nev = Path.GetFileNameWithoutExtension(fajlNev);
            string kiterjesztes = Path.GetExtension(fajlNev);

            string elso = $"{nev} másolata{kiterjesztes}";
            string elsoPath = Path.Combine(celKonyvtar, elso);
            if (!File.Exists(elsoPath))
                return elso;

            int index = 1;
            string ujNev;
            do
            {
                ujNev = $"{nev} másolata ({index}){kiterjesztes}";
                index++;
            }
            while (File.Exists(Path.Combine(celKonyvtar, ujNev)));

            return ujNev;
        }

        private string GetEgyediMappaNev(string celSzulo, string mappaNev)
        {
            string elso = $"{mappaNev} másolata";
            string elsoPath = Path.Combine(celSzulo, elso);
            if (!Directory.Exists(elsoPath))
                return elso;

            int index = 1;
            string ujNev;
            do
            {
                ujNev = $"{mappaNev} másolata ({index})";
                index++;
            }
            while (Directory.Exists(Path.Combine(celSzulo, ujNev)));

            return ujNev;
        }

        private string GetIkonKey(string ext)
        {
            if (ext == ".jpg" || ext == ".png") return "image.ico";
            if (ext == ".mp4" || ext == ".avi") return "video.ico";
            if (ext == ".txt") return "text.ico";
            return "file.ico";
        }

        public string GetCurrentDirectory(PanelSide oldal)
        {
            return oldal == PanelSide.Bal ? BalTB.Text : JobbTB.Text;
        }
        #endregion

        #region Másolás

        public void MasolVagyMozgatFajlokat(PanelSide forras, PanelSide cel, bool mozgat)
        {
            ListView forrasLV = forras == PanelSide.Bal ? BalLV : JobbLV;
            string forrasUt = GetCurrentDirectory(forras);
            string celUt = GetCurrentDirectory(cel);

            foreach (ListViewItem item in forrasLV.SelectedItems)
            {
                string nev = item.SubItems[1].Text;
                string tipus = item.SubItems[2].Text;

                string forrasElem = Path.Combine(forrasUt, nev);
                string celElem = Path.Combine(celUt, nev);

                try
                {
                    if (tipus == "Könyvtár")
                    {
                        if (mozgat)
                            Directory.Move(forrasElem, celElem);
                        else
                        {
                            string egyediMappaNev = GetEgyediMappaNev(celUt, nev);
                            string ujCelMappa = Path.Combine(celUt, egyediMappaNev);
                            MasolMappat(forrasElem, ujCelMappa);
                        }
                    }
                    else
                    {
                        if (File.Exists(celElem))
                        {
                            DialogResult valasz = MessageBox.Show(
                                $"A fájl már létezik:\n{nev}\n\nFelülírja?",
                                "Megerősítés",
                                MessageBoxButtons.YesNoCancel,
                                MessageBoxIcon.Question
                            );

                            if (valasz == DialogResult.Cancel)
                                continue;
                            else if (valasz == DialogResult.No)
                            {
                                // új név
                                string ujNev = GetEgyediFajlNev(celUt, nev);
                                string ujCelFajl = Path.Combine(celUt, ujNev);
                                File.Copy(forrasElem, ujCelFajl);
                            }
                            else if (valasz == DialogResult.Yes)
                                File.Copy(forrasElem, celElem, overwrite: true);
                        }
                        else
                            File.Copy(forrasElem, celElem);
                    }
                }
                catch (Exception ex)
                {
                    string muvelet = mozgat ? "áthelyezni" : "másolni";
                    MessageBox.Show($"Nem sikerült {muvelet} a(z) {nev} elemet:\n{ex.Message}", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            Label celLabel = cel == PanelSide.Bal ? BalLabel : JobbLabel;
            BetoltKonyvtar(celUt, cel, celLabel);
            if (mozgat)
            {
                Label forrasLabel = forras == PanelSide.Bal ? BalLabel : JobbLabel;
                BetoltKonyvtar(forrasUt, forras, forrasLabel);
            }
        }

        //Másolás/Mozgazás segítő fgv ha mappárol van szó, rekurzív.
        private void MasolMappat(string forrasDir, string celDir)
        {
            Directory.CreateDirectory(celDir);
            foreach (string fajl in Directory.GetFiles(forrasDir))
            {
                string fajlNev = Path.GetFileName(fajl);
                string celFajl = Path.Combine(celDir, fajlNev);
                File.Copy(fajl, celFajl, overwrite: true);
            }

            foreach (string almappa in Directory.GetDirectories(forrasDir))
            {
                string mappaNev = Path.GetFileName(almappa);
                string ujCelMappa = Path.Combine(celDir, mappaNev);
                MasolMappat(almappa, ujCelMappa); //Rekurzió
            }
        }

        #endregion

        #region Új mappa

        public void LetrehozUjMappa(PanelSide oldal)
        {
            using (var dialog = new NewFolderForm())
            {
                if (dialog.ShowDialog() != DialogResult.OK)
                    return;

                string nev = dialog.FolderName;
                MessageBox.Show(nev);
                string aktualisUt = GetCurrentDirectory(oldal);
                string ujMappaUt = Path.Combine(aktualisUt, nev);
                Label celLabel = oldal == PanelSide.Bal ? BalLabel : JobbLabel;

                try
                {
                    Directory.CreateDirectory(ujMappaUt);
                    BetoltKonyvtar(aktualisUt, oldal, celLabel);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Nem sikerült létrehozni a mappát:\n{ex.Message}");
                }
            }
        }

        #endregion

        #region Törlés

        public void TorolKijelolteket(PanelSide oldal)
        {
            ListView lv = oldal == PanelSide.Bal ? BalLV : JobbLV;
            Label label = oldal == PanelSide.Bal ? BalLabel : JobbLabel;
            string aktualisUt = GetCurrentDirectory(oldal);

            if (lv.SelectedItems.Count == 0)
            {
                MessageBox.Show("Nincs kijelölt elem a törléshez.");
                return;
            }

            // Megerősítés
            DialogResult valasz = MessageBox.Show(
                $"Biztosan törölni szeretnéd a kijelölt {lv.SelectedItems.Count} elemet?",
                "Törlés megerősítése",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (valasz != DialogResult.Yes)
                return;

            foreach (ListViewItem item in lv.SelectedItems)
            {
                string nev = item.SubItems[1].Text;
                string tipus = item.SubItems[2].Text;
                string teljesUt = Path.Combine(aktualisUt, nev);

                try
                {
                    if (tipus == "Könyvtár" || tipus == "Dir")
                        Directory.Delete(teljesUt, recursive: true);
                    else
                        File.Delete(teljesUt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Nem sikerült törölni: {nev}\n{ex.Message}");
                }
            }

            // Frissítés
            BetoltKonyvtar(aktualisUt, oldal, label);
        }

        #endregion

        #region Kijelölt méret számítása

        public (int fajlDarab, long osszMeret) OsszKijeloltMeret(PanelSide oldal)
        {
            ListView lv = oldal == PanelSide.Bal ? BalLV : JobbLV;
            string aktualisUt = GetCurrentDirectory(oldal);

            int fajlSzam = 0;
            long meret = 0;

            foreach (ListViewItem item in lv.SelectedItems)
            {
                string nev = item.SubItems[1].Text;
                string tipus = item.SubItems[2].Text;
                string teljesUt = Path.Combine(aktualisUt, nev);

                if (tipus == "Könyvtár")
                {
                    (int db, long m) = OsszMappaMeret(teljesUt);
                    fajlSzam += db;
                    meret += m;
                }
                else
                {
                    try
                    {
                        FileInfo info = new FileInfo(teljesUt);
                        meret += info.Length;
                        fajlSzam += 1;
                    }
                    catch
                    {
                        //IOexception, UnauthorizedAccess, stb kezelés esetleg késöbb.
                    }
                }
            }

            return (fajlSzam, meret);
        }

        //Segédfüggvény mappákban lévő fileok méret összegzésére
        private (int fajlDb, long osszMeret) OsszMappaMeret(string mappaUt)
        {
            int db = 0;
            long meret = 0;

            try
            {
                foreach (string fajl in Directory.GetFiles(mappaUt, "*", SearchOption.AllDirectories))
                {
                    try
                    {
                        FileInfo info = new FileInfo(fajl);
                        meret += info.Length;
                        db++;
                    }
                    catch 
                    {
                        //IOexception, UnauthorizedAccess, stb kezelés esetleg késöbb.
                    }
                }
            }
            catch
            {
                
            }

            return (db, meret);
        }
        #endregion
    }
}
