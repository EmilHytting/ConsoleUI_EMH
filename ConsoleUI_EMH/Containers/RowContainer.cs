namespace ConsoleUI_EMH;

public class RowContainer : ContainerBase
{
    public RowContainer()
    {

    }
    public new int GetWidth()
    {
        return Console.BufferWidth;
    }
    public override void Render()
    {
        Render(int.MaxValue, int.MaxValue);
    }

    public override void Render(int maxWidth, int maxHeight)
    {
        ConsoleColor background = Console.BackgroundColor;
        ConsoleColor foreground = Console.ForegroundColor;

        int offsetX = Console.CursorLeft;
        int offsetY = Console.CursorTop;
        foreach (UIElement child in _children)
        {
            Console.SetCursorPosition(offsetX, offsetY);
            var size = child.GetSize();
            child.Render(size.Width, size.Height);
            offsetX += size.Width;

            //Prepare cursor for next child
            Console.BackgroundColor = background;
            Console.ForegroundColor = foreground;
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