using ConsoleUI_EMH;
using System;





ColumnContainer columnId = new();
columnId.AddChild(new Header("Id"));
columnId.AddChild(new Label("1"));
columnId.AddChild(new Label("2"));
var textBoxId = new TextBox();
columnId.AddChild(textBoxId);

ColumnContainer columnName = new();
columnName.AddChild(new Header("Name"));
columnName.AddChild(new Label("Konrad Sommer"));
columnName.AddChild(new Label("Anne Dam"));
var textBoxName = new TextBox();
columnName.AddChild(textBoxName);

RowContainer rowContainer = new();
rowContainer.AddChild(columnId);
rowContainer.AddChild(columnName);

// Eksempel på liste eller hovedkontrol
var list = rowContainer;

ConsoleKeyInfo keyInfo;
while (true)
{
    Console.Clear();
    Console.CursorLeft = 0;
    Console.CursorTop = 0;
    list.Render();

    keyInfo = Console.ReadKey(true);

    switch (keyInfo.Key)
    {
        case ConsoleKey.Escape:
            return;
        case ConsoleKey.Tab:
            if (keyInfo.Modifiers == ConsoleModifiers.Shift)
                ControlBase.PreviousControl();
            else
                ControlBase.NextControl();
            break;
        default:
            ControlBase? activeControl = ControlBase.GetActiveControl();
            activeControl?.HandleKeyInfo(keyInfo);
            break;
    }
}