namespace ConsoleUI_EMH;


public abstract class ContainerBase: UIElement
{
    protected List<UIElement> _children = new();
    public ContainerBase()
    {

    }
    public void AddChild(UIElement element)
    {
        _children.Add(element);
    }
} 