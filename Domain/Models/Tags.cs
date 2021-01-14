using System.Collections.Generic;
using System.Drawing;

namespace Domain.Models
{
    public class Tags
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Bitmap Image { get; set; }
        public ICollection<Book> Books { get; set; }

        

    
    }
}