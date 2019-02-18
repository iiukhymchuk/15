using System;

namespace View
{
    class Layout5x5Creator : LayoutCreatorBase
    {
        private static ILayout layout;

        public Layout5x5Creator(EventHandler buttonHandler) : base(buttonHandler) { }

        public override ILayout CreateLayout()
        {
            return layout
                ?? (layout = new Layout.Builder()
                    .SetPanelSize(5)
                    .SetButtons(buttonHandler)
                    .SetPanel()
                    .Build());
        }
    }
}
