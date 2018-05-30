using System;

namespace TextStore.Model
{
    public class Story
    {
        public int Id { get; set; }
        public string Category { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public int Rating { get; set; }
    }
}
