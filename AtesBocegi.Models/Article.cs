using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtesBocegi.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Başlık Eklemelisiniz")]
        public string Title { get; set; }

        public string SubTitle { get; set; }

        [Required(ErrorMessage = "Kısa detay Eklemelisiniz")]
        public string Detail { get; set; }

        public string LongDetail { get; set; }

        public string Image { get; set; }

        public string PageName { get; set; }

        public int ScreenOrder { get; set; }

        public int ColorId { get; set; }
        public virtual ColorScale Color { get; set; }
    }
}
