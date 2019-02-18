using System;

namespace View
{
    class Layout3x3Creator : LayoutCreatorBase
    {
        private static ILayout layout;

        public Layout3x3Creator(EventHandler buttonHandler) : base(buttonHandler) { }

        public override ILayout CreateLayout()
        {
            return layout
                ?? (layout = new Layout.Builder()
                    .SetPanelSize(3)
                    .SetButtons(buttonHandler)
                    .SetPanel()
                    .Build());
        }
    }
}