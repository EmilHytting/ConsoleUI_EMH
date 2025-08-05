namespace ConsoleUI_EMH;

public class RowContainer : ContainerBase
{
    public bool ShowBorder { get; set; } = false;

    public RowContainer()
    {
    }

    public RowContainer(bool showBorder)
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
        int containerWidth = Math.Min(size.Width + 2, maxWidth);
        int containerHeight = Math.Min(size.Height + 2, maxHeight);

        int startX = Console.CursorLeft;
        int startY = Console.CursorTop;

        // Tegn øverste ramme
        Console.SetCursorPosition(startX, startY);
        Console.Write("┌" + new string('─', containerWidth - 2) + "┐");

        // Tegn børn med ramme
        Console.SetCursorPosition(startX, startY + 1);
        Console.Write("│");

        int offsetX = startX + 1;
        foreach (UIElement child in _children)
        {
            Console.SetCursorPosition(offsetX, startY + 1);
            var childSize = child.GetSize();
            child.Render(childSize.Width, childSize.Height);
            offsetX += childSize.Width;
        }

        Console.SetCursorPosition(startX + containerWidth - 1, startY + 1);
        Console.Write("│");

        // Tegn nederste ramme
        Console.SetCursorPosition(startX, startY + 2);
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
            offsetX += size.Width;

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

        if (ShowBorder)
        {
            width += 2;
            height += 2;
        }

        return (width, height);
    }
}