using System;

namespace ConsoleUI_EMH
{
    public class GridContainer : ContainerBase
    {
        public GridContainer()
        {

        }
        public void AddChild(UIElement child, int rowIndex, int colIndex)
        {

        }
        public override void Render()
        {
            Render(int.MaxValue, int.MaxValue);
        }

        public override void Render(int maxWidth, int maxHeight)
        {
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor foreground = Console.ForegroundColor;

            // Grid rendering logic kan tilføjes her senere
            foreach (UIElement child in _children)
            {
                var size = child.GetSize();
                child.Render(size.Width, size.Height);
            }

            //Prepare cursor for next child
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
        }

        public override (int Width, int Height) GetSize()
        {
            return (0, 0);
        }
    }
}