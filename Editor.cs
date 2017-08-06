using System;
using System.Collections.Generic;

namespace editor
{
    public class Editor
    {
        private EditorBuffer buffer;

        private Cursor cursor;

        public Editor()
        {
            this.buffer = new EditorBuffer(new List<string>
            {
                "One line",
                "Two lines",
                "",
                "Last line, maybe"
            });

            this.cursor = new Cursor(0, 0);
        }
        public void Run()
        {
            while (true)
            {
                this.Render();
                this.HandleInput();
            }
        }

        private void Render()
        {
            Console.Clear();
            foreach (var line in this.buffer.Lines)
            {
                Console.WriteLine(line);
            }
            Console.SetCursorPosition(this.cursor.Col, this.cursor.Row);
        }

        private void HandleInput()
        {
            var c = Console.ReadKey(true);

            // ctrl-q exits
            if (c.Key == ConsoleKey.Q && c.Modifiers.HasFlag(ConsoleModifiers.Control))
            {
                Environment.Exit(0);
            }

            if (c.Key == ConsoleKey.RightArrow)
            {
                cursor = cursor.MoveRight(buffer);
            }

            if (c.Key == ConsoleKey.LeftArrow)
            {
                cursor = cursor.MoveLeft(buffer);
            }

            if (c.Key == ConsoleKey.UpArrow)
            {
                cursor = cursor.MoveUp(buffer);
            }

            if (c.Key == ConsoleKey.DownArrow)
            {
                cursor = cursor.MoveDown(buffer);
            }
        }
    }
}