namespace ConsoleUI_EMH;


public abstract class ContainerBase : UIElement
{
    protected List<UIElement> _children = new();
    public ContainerBase()
    {

    }
    public int GetWidth()
    {
        return 50;
    }

    public void AddChild(UIElement element)
    {
        if (element is ControlBase)
        {
            ControlBase.AllControls.Add((ControlBase)element);
        }
        _children.Add(element);
    }
} //ContainerBase.cs