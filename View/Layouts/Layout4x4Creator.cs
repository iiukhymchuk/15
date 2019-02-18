using System;

namespace View
{
    class Layout4x4Creator : LayoutCreatorBase
    {
        private static ILayout layout;

        public Layout4x4Creator(EventHandler buttonHandler) : base(buttonHandler) { }

        public override ILayout CreateLayout()
        {
            return layout
                ?? (layout = new Layout.Builder()
                    .SetPanelSize(4)
                    .SetButtons(buttonHandler)
                    .SetPanel()
                    .Build());
        }
    }
}
