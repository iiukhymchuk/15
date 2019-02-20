using System;

namespace View
{
    class LayoutCreators
    {
        private readonly LayoutCreatorBase layout3x3creator;
        private readonly LayoutCreatorBase layout4x4creator;
        private readonly LayoutCreatorBase layout5x5creator;

        public LayoutCreators(EventHandler buttonHandler)
        {
            layout3x3creator = new Layout3x3Creator(buttonHandler);
            layout4x4creator = new Layout4x4Creator(buttonHandler);
            layout5x5creator = new Layout5x5Creator(buttonHandler);
        }

        public LayoutCreatorBase this[int index]
        {
            get
            {
                switch (index)
                {
                    case 3: return layout3x3creator;
                    case 4: return layout4x4creator;
                    case 5: return layout5x5creator;
                    default: return null;
                }
            }
        }
    }
}