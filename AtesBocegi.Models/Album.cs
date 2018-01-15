using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtesBocegi.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string AlbumPhoto { get; set; }

        [Required(ErrorMessage = "Lütfen albüm adı giriniz")]
        public string Name { get; set; }

        public virtual ICollection<AlbumItem> AlbumItems { get; set; }

        public int? ColorId { get; set; }
        public virtual ColorScale Color { get; set; }
    }
}
