using ConsoleUI_EMH;
using System;

ColumnContainer column = new();
column.AddChild(new Label("| ------------------- |"));
column.AddChild(new Label("| ID |  Navn          |"));
column.AddChild(new Label("| 1  |  Konrad Sommer |"));
column.AddChild(new Label("| 2  |  Anne Dam      |"));
column.AddChild(new Label("| 3  |  John Doe      |"));
column.AddChild(new Label("| 4  |  Hans Hansen   |"));
column.AddChild(new Label("| ------------------- |"));
column.AddChild(new Label(""));
column.AddChild(new Button("Save"));

column.Render();

Console.WriteLine("\nKlik på en tast for at afslutte...");
Console.ReadKey();