using System;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;

namespace TrunksCommander
{
    static class BeallitasKezelo
    {
        private static readonly string fajlUt = "beallitasok.json";

        public static Beallitasok Betolt()
        {
            Beallitasok alap = new Beallitasok
            {
                AlapKonyvtar = @"C:\",
                Tema = "vilagos"
            };

            if (!File.Exists(fajlUt))
            {
                Ment(alap);
                return alap;
            }

            try
            {
                string json = File.ReadAllText(fajlUt);
                Beallitasok olvasott = JsonConvert.DeserializeObject<Beallitasok>(json);

                //Ha olvasott: null, akkor alap; ha nem akkor olvasott
                return olvasott ?? alap;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a beállítások betöltésekor:\n" + ex.Message,
                                "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return alap;
            }
        }

        public static void Ment(Beallitasok beallitas)
        {
            try
            {
                string json = JsonConvert.SerializeObject(beallitas, Formatting.Indented);
                File.WriteAllText(fajlUt, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a beállítások mentésekor:\n" + ex.Message,
                                "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
