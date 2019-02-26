using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Weed
    {
        public int WeedId { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        [DataType(DataType.Date)]
        public DateTime PublishDate { get; set; }
        public WeedType WeedType { get; set; }
        public WeedKind WeedKind { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }
        [MinLength(20, ErrorMessage = "Long Description must be atleast 20 chars long!")]
        public string LongDescription { get; set; }

        [Range(0, 10, ErrorMessage = "Weed must be of minimum strength 0 and the most Powerfull weed of'em all is 10!")]
        public int WeedStrength { get; set; }

        [DataType(DataType.Currency)]
        [Range(0, 255, ErrorMessage = "Price must start from 0 up to 255 you expensive bastard!")]
        public int PriceForOunce { get; set; }

        public byte[] Pic { get; set; }
        public byte[] Pic2 { get; set; }
        public byte[] Pic3 { get; set; }
    }

    public enum WeedType
    {
        Sativa,
        Indica
    }

    public enum WeedKind
    {
        OgKush,
        WhiteWidow,
        LemonHaze,
        PurpleHaze,
        ThisIsPermanent,
        BlueCheese,
        UknownStrain,
        Tegridy
    }
}
