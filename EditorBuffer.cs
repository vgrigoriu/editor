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
    }
}