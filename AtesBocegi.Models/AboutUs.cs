using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtesBocegi.Models
{
    public class AboutUs
    {
        public int Id { get; set; }

        //leftbox
        [Required(ErrorMessage = "Lütfen sol kutu başlığını boş bırakmayınız")]
        public string LeftTitle { get; set; }
        [Required(ErrorMessage = "Lütfen sol kutu İçeriğini boş bırakmayınız")]
        public string LeftContent { get; set; }



        //rigtbox
        [Required(ErrorMessage = "Lütfen sağ kutu başlığını boş bırakmayınız")]
        public string RightTitle { get; set; }
        [Required(ErrorMessage = "Lütfen misyonumuz İçeriğini boş bırakmayınız")]
        public string Mission { get; set; }
        [Required(ErrorMessage = "Lütfen vizyonumuz İçeriğini boş bırakmayınız")]
        public string Vision { get; set; }
        public string Image { get; set; }

    }
}
