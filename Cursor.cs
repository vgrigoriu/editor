using System;
using System.Diagnostics;

namespace editor
{
    public class Cursor
    {
        private readonly int row;

        private readonly int col;

        public Cursor(int row, int col)
        {
            this.row = row;
            this.col = col;
        }

        public int Row => this.row;

        public int Col => this.col;

        public Cursor MoveRight(EditorBuffer buffer)
        {
            return new Cursor(this.Row, this.Col + 1).Clamp(buffer);
        }

        public Cursor MoveLeft(EditorBuffer buffer)
        {
            return new Cursor(this.Row, this.Col - 1).Clamp(buffer);
        }

        public Cursor MoveUp(EditorBuffer buffer)
        {
            return new Cursor(this.Row - 1, this.Col).Clamp(buffer);
        }

        public Cursor MoveDown(EditorBuffer buffer)
        {
            return new Cursor(this.Row + 1, this.Col).Clamp(buffer);
        }

        private Cursor Clamp(EditorBuffer buffer)
        {
            var row = this.row.Clamp(0, buffer.LinesCount - 1);
            var col = this.col.Clamp(0, buffer.Lines[row].Length);

            return new Cursor(row, col);
        }
    }

    public static class Int32Extensions
    {
        public static int Clamp(this int n, int min, int max)
        {
            Debug.Assert(min <= max, "min cannot be greater than max");
            if (n < min)
            {
                return min;
            }
            if (max < n)
            {
                return max;
            }
            return n;
        }
    }
}