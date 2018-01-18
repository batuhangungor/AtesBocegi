using System.ComponentModel.DataAnnotations;

namespace AtesBocegi.Models.FormModels
{
    public class AlbumItemFormModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Resim Eklemelisiniz")]
        public string Image { get; set; }

        public int AlbumId { get; set; }

        public virtual AlbumFormModel Album { get; set; }
    }
}
