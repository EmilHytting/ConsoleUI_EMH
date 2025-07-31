namespace ConsoleUI_EMH;

public class RowContainer : ContainerBase
{
    public override void Render()
    {
        int startLeft = Console.CursorLeft;
        foreach (var child in _children)
        {
            child.Render();
            var (width, _) = child.GetSize();
            Console.CursorLeft += width;
        }
        Console.CursorTop += 1;
        Console.CursorLeft = startLeft;
    }

    public override (int Width, int Height) GetSize()
    {
        int width = 0;
        int height = 0;
        foreach (var child in _children)
        {
            var (w, h) = child.GetSize();
            width += w;
            if (h > height) height = h;
        }
        return (width, height);
    }
}