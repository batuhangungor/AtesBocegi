using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtesBocegi.Models
{
    public class Contact
    {
        public int Id { get; set; }


        [Required(ErrorMessage = "Lütfen Ad Soyad bilgisi ekleyiniz")]
        public string Sender { get; set; }

        [Required(ErrorMessage = "Lütfen E-Mail adresinizi ekleyiniz")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Lütfen Konu ekleyiniz")]
        public string Subject { get; set; }

        [Required(ErrorMessage = "Lütfen Mesajınızı ekleyiniz")]
        public string Message { get; set; }
        
        public DateTime SendDate { get; set; }

        public bool IsReaded { get; set; }
    }
}
