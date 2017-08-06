using System;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace editor
{
    public class EditorBuffer
    {
        private readonly ImmutableList<string> lines;

        public EditorBuffer(ImmutableList<string> lines)
        {
            this.lines = lines;
        }

        public IReadOnlyList<string> Lines => this.lines;

        public int LinesCount => this.lines.Count;

        internal EditorBuffer Insert(char keyChar, int row, int col)
        {
            var newLine = this.lines[row].Insert(col, $"{keyChar}");
            var newLines = this.lines.SetItem(row, newLine);
            return new EditorBuffer(newLines);
        }

        internal EditorBuffer InsertNewLine(int row, int col)
        {
            var line = this.lines[row];
            var splitLines = new[]{ line.Substring(0, col), line.Substring(col) };
            var newLines = this.lines.RemoveAt(row).InsertRange(row, splitLines);
            return new EditorBuffer(newLines);
        }
    }
}