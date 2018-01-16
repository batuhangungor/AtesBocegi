using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtesBocegi.Models
{
    public class Blog
    {
        public int Id { get; set; }

        public string SmallImage { get; set; }

        public string BigImage { get; set; }

        [Required(ErrorMessage = "Lütfen tanıtım yazısı giriniz")]
        public string info { get; set; }

        [Required(ErrorMessage = "Lütfen Başlık giriniz")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Lütfen Detay giriniz")]
        public string Detail { get; set; }

        public int ColorId { get; set; }
        public virtual ColorScale Color { get; set; }

    }
}