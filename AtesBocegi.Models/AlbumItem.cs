using System.ComponentModel.DataAnnotations;

namespace AtesBocegi.Models
{
    public class AlbumItem
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Resim Eklemelisiniz")]
        public string Image { get; set; }

        public int AlbumId { get; set; }

        public virtual Album Album { get; set; }
    }
}
