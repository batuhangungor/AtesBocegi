using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtesBocegi.Models.FormModels
{
    public class FAQFormModel
    {
        public int? Id { get; set; }


        [Required(ErrorMessage = "Lütfen Soru ekleyiniz")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Lütfen cevap ekleyiniz")]
        public string Answer { get; set; }

        public bool IsVisible { get; set; }

        public int ScreenOrder { get; set; }
    }
}
