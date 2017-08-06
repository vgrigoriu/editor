using System;

namespace editor
{
    public class Editor
    {
        private EditorBuffer buffer;

        private Cursor cursor;
        public Editor()
        {
            this.buffer = new EditorBuffer();
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
        }

        private void HandleInput()
        {
            var c = Console.ReadKey(true);

            // ctrl-q exits
            if (c.Key == ConsoleKey.Q && c.Modifiers.HasFlag(ConsoleModifiers.Control))
            {
                Environment.Exit(0);
            }
        }
    }
}