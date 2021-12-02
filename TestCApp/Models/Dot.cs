using System.Collections.Generic;

namespace TestCApp.Models
{
    public class Dot
    {
        public int Id { get; set; }

        public double PositionX { get; set; }

        public double PositionY { get; set; }

        public double Radius { get; set; }

        public string Color { get; set; }

        public List<Post> Posts { get; set; }

    }
}