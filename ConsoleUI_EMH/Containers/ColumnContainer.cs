namespace ConsoleUI_EMH;

public class ColumnContainer : ContainerBase
{
    public bool ShowBorder { get; set; } = false;

    public ColumnContainer()
    {
    }

    public ColumnContainer(bool showBorder)
    {
        ShowBorder = showBorder;
    }

    public override void Render()
    {
        Render(int.MaxValue, int.MaxValue);
    }

    public override void Render(int maxWidth, int maxHeight)
    {
        if (ShowBorder)
        {
            RenderWithBorder(maxWidth, maxHeight);
        }
        else
        {
            RenderWithoutBorder(maxWidth, maxHeight);
        }
    }

    private void RenderWithBorder(int maxWidth, int maxHeight)
    {
        var size = GetSize();
        int containerWidth = Math.Min(size.Width + 2, maxWidth);  // +2 for border
        int containerHeight = Math.Min(size.Height + 2, maxHeight); // +2 for border

        int startX = Console.CursorLeft;
        int startY = Console.CursorTop;

        // Tegn øverste ramme
        Console.SetCursorPosition(startX, startY);
        Console.Write("┌" + new string('─', containerWidth - 2) + "┐");

        // Tegn børn med venstre og højre ramme
        int offsetY = startY + 1;
        foreach (UIElement child in _children)
        {
            Console.SetCursorPosition(startX, offsetY);
            Console.Write("│");

            Console.SetCursorPosition(startX + 1, offsetY);
            var childSize = child.GetSize();
            child.Render(childSize.Width, childSize.Height);

            Console.SetCursorPosition(startX + containerWidth - 1, offsetY);
            Console.Write("│");

            offsetY += childSize.Height;
        }

        // Tegn nederste ramme
        Console.SetCursorPosition(startX, offsetY);
        Console.Write("└" + new string('─', containerWidth - 2) + "┘");
    }

    private void RenderWithoutBorder(int maxWidth, int maxHeight)
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
            height += childSize.Height;
            if (childSize.Width > width)
            {
                width = childSize.Width;
            }
        }

        if (ShowBorder)
        {
            width += 2;  // venstre + højre ramme
            height += 2; // øverste + nederste ramme
        }

        return (width, height);
    }
}