using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace View
{
    internal static class Helpers
    {
        internal static void UncheckOtherMenuItems(this List<ToolStripMenuItem> items,
            ToolStripMenuItem selectedItem)
        {
            items.Where(m => m.Name != selectedItem.Name).ToList()
                .ForEach(m => m.Checked = false);
        }

        internal static int GetModeNumber(string mode)
        {
            switch (mode)
            {
                case "easy": return 0;
                case "normal": return 1;
                case "hard": return 2;
                default: throw new ArgumentOutOfRangeException("mode parameter is invalid");
            }
        }

        internal static bool IsValidMode(string mode)
        {
            return mode == "easy"
                || mode == "normal"
                || mode == "hard";
        }

        internal static bool IsValidSize(int size)
        {
            return size == 3 || size == 4 || size == 5;
        }
    }
}