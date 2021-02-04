using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string EngName { get; set; }
        public string AsianName { get; set; }
        public string Description { get; set; }
        public int Сhapters { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Tag> Tags { get; set; }
        public string Autor { get; set; }
        public ICollection<Bitmap> Images { get; set; }
        public int Cost { get; set; }
    
    }
}
