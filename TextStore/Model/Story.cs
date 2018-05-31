using System;

namespace TextStore.Model
{
    public class Story : DbItem
    {
        public string Category { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public string Source { get; set; }
        public byte Rating { get; set; }        

        public Story() { }

        public Story(string category, string text)
        {
            Category = category;
            Text = text;
            Date = DateTime.Now;
            Rating = 0;
        }
    }
}
