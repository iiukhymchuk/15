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

        internal static (int, int) IndexToCoords(int index, int size)
        {
            var x = index % size;
            var y = index / size;
            return (x, y);
        }
    }
}