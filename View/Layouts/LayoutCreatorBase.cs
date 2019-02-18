using System;

namespace View
{
    abstract class LayoutCreatorBase
    {
        protected readonly EventHandler buttonHandler;

        public LayoutCreatorBase(EventHandler buttonHandler)
        {
            this.buttonHandler = buttonHandler;
        }

        public abstract ILayout CreateLayout();
    }
}