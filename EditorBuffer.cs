using System.Collections.Generic;

namespace editor
{
    public class EditorBuffer
    {
        private List<string> lines;

        public EditorBuffer()
        {
            this.lines = new List<string>
            {
                "One line",
                "Two lines",
                "",
                "Last line, maybe"
            };
        }

        public IEnumerable<string> Lines => this.lines;
    }
}