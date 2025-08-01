namespace ConsoleUI_EMH;

public class RowContainer : ContainerBase
{
    public override void Render()
    {
        ConsoleColor background = Console.BackgroundColor;
        ConsoleColor foreground = Console.ForegroundColor;
        int offsetX = Console.CursorLeft;
        int offsetY = Console.CursorTop;
        foreach (UIElement child in _children)
        {
            child.Render();
            var size = child.GetSize();
            offsetX += size.Width;
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
            Console.CursorLeft = offsetX;
            if (offsetY < Console.BufferHeight)
            {
                Console.CursorTop = offsetY;
            }
        }
    }

    public override (int Width, int Height) GetSize()
    {
        int width = 0;
        int height = 0;
        foreach (UIElement child in _children)
        {
            var childSize = child.GetSize();
            width += childSize.Width;
            if (childSize.Height > height)
            {
                height = childSize.Height;
            }
        }
        return (width, height);
    }
}