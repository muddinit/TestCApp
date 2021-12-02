namespace TestCApp.Models
{
    public class Post
    {
        public int Id { get; set; }

        public int DotId { get; set; }

        public Dot Dot { get; set; }

        public string Text { get; set; }

        public string BackgroundColor { get; set; }

    }
}