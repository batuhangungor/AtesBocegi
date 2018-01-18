using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtesBocegi.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string Image { get; set; }

        [Required(ErrorMessage = "Lütfen İsim giriniz")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Lütfen Kısa Bilgi Giriniz")]
        public string Info { get; set; }

        [Required(ErrorMessage = "Lütfen Uzun Bilgi Giriniz")]
        public string Detail { get; set; }
        
        public string Role { get; set; }

        public int ScreenOrder { get; set; }

        public int ColorId { get; set; }
        public virtual ColorScale Color { get; set; }
    }
}
