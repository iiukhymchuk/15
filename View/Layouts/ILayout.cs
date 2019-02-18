using System.Collections.Generic;
using System.Windows.Forms;

namespace View
{
    interface ILayout
    {
        int Size { get; }
        TableLayoutPanel Panel { get; }
        List<Button> Buttons { get; }
    }
}