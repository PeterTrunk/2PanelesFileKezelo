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

        public enum PanelSide
        {
            Bal,
            Jobb
        }

        public CustomFileManager(ListView BalLV, ListView JobbLV, ImageList IkonLista, TextBox BalTB, TextBox JobbTB, Label BalLabel, Label JobbLabel)
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
                // Mappák
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

                // Fájlok
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

        #region Másolás
        //Egyenlőre csak file másolás / áthelyezés... (egyszerűség)
        public void MasolVagyMozgatFajlokat(PanelSide forras, PanelSide cel, bool mozgat)
        {
            ListView forrasLV = forras == PanelSide.Bal ? BalLV : JobbLV;
            string forrasUt = GetCurrentDirectory(forras);
            string celUt = GetCurrentDirectory(cel);

            foreach (ListViewItem item in forrasLV.SelectedItems)
            {
                string nev = item.SubItems[1].Text;
                string tipus = item.SubItems[2].Text;

                if (tipus != "Könyvtár") 
                {
                    string forrasFajl = Path.Combine(forrasUt, nev);
                    string celFajl = Path.Combine(celUt, nev);

                    try
                    {
                        if (mozgat)
                            File.Move(forrasFajl, celFajl);
                        else
                            File.Copy(forrasFajl, celFajl, overwrite: true);
                    }
                    catch (Exception ex)
                    {
                        string operation = "";
                        if (mozgat)
                            operation = "mozgatni";
                        else
                            operation = "másolni";
                        MessageBox.Show($"Nem sikerült "+operation+" a(z) "+nev+" fájlt:\n"+ex.Message,"Hiba",MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
            }

            BetoltKonyvtar(celUt, cel, cel == PanelSide.Bal ? BalLabel : JobbLabel);
            if (mozgat)
                BetoltKonyvtar(forrasUt, forras, forras == PanelSide.Bal ? BalLabel : JobbLabel);
        }


        
        #endregion

        //Új mappa
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

        //Törlés
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
    }
}
