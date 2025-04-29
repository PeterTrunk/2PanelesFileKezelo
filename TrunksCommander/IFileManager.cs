using System.Windows.Forms;
using TrunksCommander.Images;
using static TrunksCommander.Images.CustomFileManager;

namespace TrunksCommander
{
    internal interface IFileManager
    {
        void BetoltKonyvtar(string eleres, PanelSide oldal, Label label);
        string GetCurrentDirectory(PanelSide oldal);

        void MasolVagyMozgatFajlokat(PanelSide forras, PanelSide cel, bool mozgat);
        void LetrehozUjMappa(PanelSide oldal);
        void TorolKijelolteket(PanelSide oldal);
        void SzerkesztVagyMegnez(PanelSide oldal, bool szerkesztes);
    }
}
