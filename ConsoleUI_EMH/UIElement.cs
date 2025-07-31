namespace ConsoleUI_EMH;

public abstract class UIElement
{

    public abstract void Render();
    
    public abstract (int Width, int Height) GetSize();
}