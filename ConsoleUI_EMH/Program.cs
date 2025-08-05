using ConsoleUI_EMH;
using System;

//Create some columns
ColumnContainer idColumn = new();
ColumnContainer namesColumn = new();
ColumnContainer actionColumn = new();

//Create some controls
TextBox txtId = new TextBox();
TextBox txtName = new TextBox();
Button btnSave = new Button("Save", AddPerson);

//Event handler as named function
void AddPerson()
{
    idColumn.AddChild(new Label(txtId.Content)); //Add label with textbox content
    namesColumn.AddChild(new Label(txtName.Content)); //Add name with textbox content
    txtId.Content = ""; // Clear textbox
    txtName.Content = ""; // Clear textbox
}

//Add some headers
idColumn.AddChild(new Header("ID"));
namesColumn.AddChild(new Header("NAME"));
actionColumn.AddChild(new Header("ACTIONS"));

//Add the controls
idColumn.AddChild(txtId);
namesColumn.AddChild(txtName);
actionColumn.AddChild(btnSave);

RowContainer list = new();
list.AddChild(idColumn);
list.AddChild(namesColumn);
list.AddChild(actionColumn);

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