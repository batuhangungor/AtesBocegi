using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AtesBocegi.Models
{
    public class Slider
    {
        public int Id { get; set; }
        
        public string Image { get; set; }

        public int ScreenOrder { get; set; }
    }
}
