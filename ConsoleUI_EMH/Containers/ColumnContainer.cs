namespace ConsoleUI_EMH;

public class ColumnContainer : ContainerBase
{
    public ColumnContainer()
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

        int offsetX = Console.CursorLeft;
        int offsetY = Console.CursorTop;
        foreach (UIElement child in _children)
        {
            Console.SetCursorPosition(offsetX, offsetY);
            var size = child.GetSize();
            child.Render(size.Width, size.Height);
            offsetY += size.Height;

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
            height += childSize.Height; //diff
            if (childSize.Width > width) //diff
            {
                width = childSize.Width; //diff
            }
        }
        return (width, height);
    }
}