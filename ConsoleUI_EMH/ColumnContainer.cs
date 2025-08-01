namespace ConsoleUI_EMH;

public class ColumnContainer : ContainerBase
{
    public ColumnContainer()
    {

    }
    public override void Render()
    {
        try
        {
            ConsoleColor background = Console.BackgroundColor;
            ConsoleColor foreground = Console.ForegroundColor;
            int offsetX = Console.CursorLeft;
            int offsetY = Console.CursorTop;
            foreach (UIElement child in _children)
            {
                child.Render();
                var size = child.GetSize();
                offsetY += size.Height;
                Console.BackgroundColor = background;
                Console.ForegroundColor = foreground;
                Console.CursorLeft = offsetX;
                if (offsetY < Console.BufferHeight)
                {
                    Console.CursorTop = offsetY;
                }
            }
        }
        catch (Exception)
        {
            // Ignorer fejl hvis der ikke er adgang til konsollen
        }
    }
    public override (int Width, int Height) GetSize()
    {
        int width = 0;
        int height = 0;
        foreach (UIElement child in _children)
        {
            var childSize = child.GetSize();
            height += childSize.Height;
            if (childSize.Width > width)
            {
                width = childSize.Width;
            }
        }
        return (width, height);
    }
}