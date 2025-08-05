using ConsoleUI_EMH;
using System;

//Create some columns
ColumnContainer idColumn = new();      // Uden ramme
ColumnContainer namesColumn = new();   // Uden ramme
ColumnContainer actionColumn = new();  // Uden ramme

// Eller sæt det senere:
actionColumn.ShowBorder = true;

//Create some controls
NumberBox txtId = new NumberBox();
TextBox txtName = new TextBox();
Button btnSave = new Button("Save", AddPerson);
Button btnReset = new Button("Reset", ResetFields);

//Event handler as named function
void AddPerson()
{
    idColumn.AddChild(new Label(txtId.Content)); //Add label with number content
    namesColumn.AddChild(new Label(txtName.Content)); //Add name with textbox content
    txtId.Value = 0; // Clear numberbox
    txtName.Content = ""; // Clear textbox
}

//Reset function
void ResetFields()
{
    txtId.Value = 0;
    txtName.Content = "";
}

//Add some headers
idColumn.AddChild(new Header("ID"));
namesColumn.AddChild(new Header("NAME"));
actionColumn.AddChild(new Header("ACTIONS"));

//Add the controls
idColumn.AddChild(txtId);
namesColumn.AddChild(txtName);
actionColumn.AddChild(btnSave);
actionColumn.AddChild(btnReset);

// Opret en container med ramme for ID og NAME
RowContainer dataContainer = new(true);  // Med ramme
dataContainer.AddChild(idColumn);
dataContainer.AddChild(namesColumn);

RowContainer list = new();
list.AddChild(dataContainer);  // ID og NAME i samme ramme
list.AddChild(actionColumn);   // Actions i sin egen ramme

ConsoleKeyInfo keyInfo;
while (true)
{
    Console.Clear();
    Console.CursorLeft = 0;
    Console.CursorTop = 0;

    // Debug: Vis hvilken kontrol der er aktiv
    var activeControl = ControlBase.GetActiveControl();
    Console.WriteLine($"Active: {activeControl?.GetType().Name ?? "None"}");

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
            ControlBase? activeControl2 = ControlBase.GetActiveControl();
            activeControl2?.HandleKeyInfo(keyInfo);
            break;
    }
}