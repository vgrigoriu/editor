using System.Collections.Generic;

namespace editor
{
    public class EditorBuffer
    {
        private readonly List<string> lines;

        public EditorBuffer(List<string> lines)
        {
            this.lines = lines;
        }

        public IReadOnlyList<string> Lines => this.lines;

        public int LinesCount => this.lines.Count;
    }
}